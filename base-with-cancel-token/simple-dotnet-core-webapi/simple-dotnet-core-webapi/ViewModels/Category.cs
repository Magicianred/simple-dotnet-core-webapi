﻿using System;
using System.Collections.Generic;

namespace simple_dotnet_core_webapi.ViewModels
{
    /// <summary>
    /// Model for Category
    /// </summary>
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostsCount { get; set; }
        public List<Post> Posts { get; set; }
    }
}
