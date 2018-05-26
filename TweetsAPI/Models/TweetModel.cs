using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TweetsAPI.Models
{
    #region Models
    public class TweetModel
    {
        public TweetModel()
        {

        }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        public string StatusMessage { get; set; } = string.Empty;

        public int TotalCount { get; set; }
        public int CurrentCount { get; set; }


        public IEnumerable<TweetsData> TweetsData { get; set; }

    }

    public class TweetsData
    {
        public string Id { get; set; }
        public string Stamp { get; set; }
        public string Text { get; set; }
    }

    #endregion Models


    #region Custom Modification classes

    public class EqualityComparer : IEqualityComparer<TweetsData>
    {
        public bool Equals(TweetsData x, TweetsData y)
        {
            // Two items are equal if their keys are equal.
            return x.Text == y.Text;
        }

        public int GetHashCode(TweetsData obj)
        {
            return obj.Text.GetHashCode();
        }
    }
    #endregion


}