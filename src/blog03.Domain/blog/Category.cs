using Volo.Abp.Domain.Entities;

namespace blog03.blog
{
    public class Category : Entity<int>
    {
        public string CategoryName { get; set; }
        public string DisplayName { get; set; }
    }
}
