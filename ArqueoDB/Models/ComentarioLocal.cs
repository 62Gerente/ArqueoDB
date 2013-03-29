using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class ComentarioLocal
    {
        public int ComentarioLocalID { get; set; }

        [DisplayName("Comentário")]
        public int ComentarioID { get; set; }
        public Comentario Comentario { get; set; }

        [DisplayName("Local")]
        public int LocalID { get; set; }
        public Local Local { get; set; }
    }
}