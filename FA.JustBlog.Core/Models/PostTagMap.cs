using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class PostTagMap
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public Posts Posts { get; set; }
        public Tags Tags { get; set; }
    }
}
