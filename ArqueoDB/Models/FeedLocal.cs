using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class FeedLocal
    {
        public int FeedLocalID { get; set; }

        [DisplayName("Feed")]
        public int FeedID { get; set; }
        public virtual Feed Feed { get; set; }

        [DisplayName("Local")]
        public int LocalID { get; set; }
        public virtual Local Local { get; set; }

    }
}