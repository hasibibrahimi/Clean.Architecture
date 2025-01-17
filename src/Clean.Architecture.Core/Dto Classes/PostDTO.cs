﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.Core.Dto_Classes
{
    public class PostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
        public List<int> CategorysId { get; set; }
        public int UserId { get; set; }

    }
    public class PostwithCategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }
        public List<string> Category_Posts { get; set; }
        public string UserName { get; set; }
    }
}
