using Volo.Abp.Domain.Entities;

namespace blog03.blog
{
    public class PostTag : Entity<int>
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
