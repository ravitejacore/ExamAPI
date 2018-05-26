using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TweetsAPI.Models;

namespace TweetsAPI.Service
{
    public interface ITweetService
    {
         Task<TweetModel> GetTweetsAsync(TweetModel tweetModel);
    }
}