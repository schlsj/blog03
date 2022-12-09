using Volo.Abp.Domain.Entities;

namespace blog03.blog
{
    public class Tag : Entity<int>
    {
        public string TagName { get; set; }
        public string DisplayName { get; set; }
    }
}
