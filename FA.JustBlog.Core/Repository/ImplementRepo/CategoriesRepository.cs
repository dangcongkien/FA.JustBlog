﻿using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.GenericRepo;
using FA.JustBlog.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.ImplementRepo
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoryRepository
    {
        public CategoriesRepository(JustBlogContext context = null) : base(context)
        {
        }
    } 
}
