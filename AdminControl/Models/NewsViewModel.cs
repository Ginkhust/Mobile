using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

namespace AdminControl.Models
{
    public class NewsViewModel
    {
        public NewsViewModel() {  }
        
        public NewsViewModel(ParseObject p)
        {
            newsId = p.ObjectId;
            title = p.Get<string>("title");
            content = p.Get<string>("content");
            imageUrl = p.Get<string>("imageUrl");
        }
        public string newsId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string imageUrl { get; set; }
    }
}