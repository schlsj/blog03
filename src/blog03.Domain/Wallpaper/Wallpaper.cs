using System;
using Volo.Abp.Domain.Entities;

namespace blog03.Wallpaper
{
    public class Wallpaper : Entity<Guid>
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
