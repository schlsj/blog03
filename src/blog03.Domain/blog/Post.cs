using System;
using Volo.Abp.Domain.Entities;

namespace blog03.blog
{
    public class Post : Entity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public string Html { get; set; }
        public string Markdown { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
