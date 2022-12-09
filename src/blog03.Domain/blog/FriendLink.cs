using Volo.Abp.Domain.Entities;

namespace blog03.blog
{
    public class FriendLink:Entity<int>
    {
        public string Title { get; set; }
        public string LinkUrl { get; set; }
    }
}
