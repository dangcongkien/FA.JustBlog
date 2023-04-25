  using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Posts
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }
        public int CategoryId { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public decimal Rate
        {
            get
            {
                if (RateCount == 0)
                {
                    return 0; // avoid divide by zero error
                }
                return (decimal)TotalRate / RateCount;
            }
        }
        public Categories Categories { get; set; }
        public ICollection<PostTagMap> PostTagMaps { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public override string ToString()
        {
            return $"{PostId}, {Title}, {ShortDescription}, {PostContent}, {UrlSlug}, {Published}, {PostedOn}, {Modified}, {CategoryId}";
        }
    }
}
