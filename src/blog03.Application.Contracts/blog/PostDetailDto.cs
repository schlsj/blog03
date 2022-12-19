﻿using System.Collections.Generic;

namespace blog03.blog
{
    public class PostDetailDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string Html { get; set; }
        public string Markdown { get; set; }
        public string CreationTime { get; set; }
        public CategoryDto Category { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }
        public PostForPagedDto Previous { get; set; }
        public PostForPagedDto Next { get; set; }
    }
}
