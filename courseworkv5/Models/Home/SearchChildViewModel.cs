using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace courseworkv5.Models.Home
{
    public class SearchChildViewModel
    {
        public int RequestedCount { get; set; }
        public List<Workers> Workers { get; set; }

        public SearchChildViewModel()
        {
            Workers = new List<Workers>();

        }
    }
}