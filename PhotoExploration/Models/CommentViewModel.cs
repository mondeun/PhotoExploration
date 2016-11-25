using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoExploration.Models
{
    public class CommentViewModel
    {
        public string Commenter { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}