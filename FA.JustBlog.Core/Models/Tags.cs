﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Tags
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public ICollection<PostTagMap> PostTagMaps { get; set; }

        public override string ToString()
        {
            return $"{TagId}, {Name}, {UrlSlug}, {Description}, {Count}";
        }
    }
}
