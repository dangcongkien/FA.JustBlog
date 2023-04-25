﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Comments
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PostId { get; set; }
        public Posts Posts { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
