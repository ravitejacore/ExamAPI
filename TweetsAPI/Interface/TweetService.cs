using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TweetsAPI.Models;

namespace TweetsAPI.Service
{
    public class TweetService : ITweetService
    {
        private const string ApiUrl = "https://badapi.iqvia.io/api/v1/Tweets";


        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public async Task<TweetModel> GetTweetsAsync(TweetModel viewModel)
        {
            TweetModel resultModel = new TweetModel();
            try
            {
                // HttpClient is used for sending HTTP requests and receiving HTTP responses from a resource identified by a URI
                using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
                {
                    // Building url by appending input parameters from viewmodel
                    string queryParams = ApiUrl + $"?startDate={viewModel.StartDate}&endDate={viewModel.EndDate}";

                    client.BaseAddress = new Uri(ApiUrl);

                    // Clearing Accept headers for the Http Request 
                    client.DefaultRequestHeaders.Accept.Clear();

                    // Adding Header to  Http Request Accept: 'application/json'
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


                    System.Net.Http.HttpResponseMessage response = await client.GetAsync(queryParams);

                    // When http respose StatusCode is 500
                    if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        resultModel.StatusMessage = "Something went wrong!";
                    }

                    // When http respose StatusCode is 400
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        resultModel.StatusMessage = "Invalid startDate and/or endDate";
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        // Sets the collection to Empty.
                        resultModel.TweetsData = Enumerable.Empty<TweetsData>();

                        var twitterList = await response.Content.ReadAsAsync<IEnumerable<TweetsData>>();

                        resultModel.TotalCount = twitterList.Count();

                        // EqualityComparer used to remove duplicate enteries from collection.
                        resultModel.TweetsData = twitterList.Distinct(new EqualityComparer());

                        resultModel.CurrentCount = resultModel.TweetsData.Count();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultModel;
        }



    }
}