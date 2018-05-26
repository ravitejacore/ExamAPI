using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using TweetsAPI.Models;
using TweetsAPI.Service;

namespace TweetsAPI.Controllers
{
    [HandleError] // Error handling at controller level
    public class TweetsController : Controller
    {
        private const string ApiUrl = "https://badapi.iqvia.io/api/v1/Tweets";

        private readonly ITweetService _IServiceTweets;

        public TweetsController() //: this(new ServiceTweets())
        {
           
        }
        public TweetsController(ITweetService IServiceTweets)
        {
            this._IServiceTweets = IServiceTweets;
        }


       

        [HttpGet]
        public ActionResult ViewTweets()
        {
            TweetModel viewModel = new TweetModel();
            viewModel.TweetsData = Enumerable.Empty<TweetsData>();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> ViewTweets(TweetModel viewModel)
        {
            TweetModel modelAsync = await _IServiceTweets.GetTweetsAsync(viewModel);
            // Sending data to View
            return View(modelAsync);
        }

    }
}