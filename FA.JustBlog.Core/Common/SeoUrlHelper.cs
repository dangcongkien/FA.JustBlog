using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Common
{
    public static class SeoUrlHelper
    {
        /// <summary>
        /// Function Generate Url Slug
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string GenerateSlug(string phrase)
        {
            string str = phrase.ToLower();

            // Remove any invalid characters
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // Convert multiple spaces/hyphens into a single hyphen
            str = Regex.Replace(str, @"\s+", " ").Trim();
            str = Regex.Replace(str, @"\s", "-");

            return str;
        }
    }
}
