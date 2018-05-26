using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweetsAPI.Controllers;
using TweetsAPI.Models;
using TweetsAPI.Service;

namespace TweetsAPI.Tests.Controllers
{
    [TestClass]
    public class TweetsControllerTest
    {
       
        

        [TestMethod]
        public void GetTweets_check_isDuplicate_Tweets_remove()
        {
            // Arrange
            TweetService tweetService = new TweetService();
            TweetsController controller = new TweetsController(tweetService);
            TweetModel viewModel = new TweetModel()
            {
                EndDate = "2016-01-20T04:07:56.271Z",
                StartDate = "2017-01-20T04:07:56.271Z",
                TweetsData = Enumerable.Empty<TweetsData>()
            };


            // Act
            //var viewresult = tweetService.GetTweetsAsync(viewModel).Result;
            var testResult = controller.ViewTweets(viewModel).Result;
            viewModel = (TweetModel)((ViewResult)testResult).Model;


            // Assert
            Assert.IsTrue(viewModel.TweetsData.Count() < 100, $"Duplicate records removed");


           
        }
    }
}
