using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class FeedOrganizacao
    {
        public int FeedOrganizacaoID { get; set; }

        [DisplayName("Feed")]
        public int FeedID { get; set; }
        public Feed Feed { get; set; }

        [DisplayName("Organização")]
        public int OrganizacaoID { get; set; }

    }
}