using System;
using Volo.Abp.Domain.Entities;

namespace blog03.HotNews
{
    public class HotNews : Entity<Guid>
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public int SourceId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
