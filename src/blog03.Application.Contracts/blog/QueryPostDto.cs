using System.Collections.Generic;

namespace blog03.blog
{
    public class QueryPostDto
    {
        public int Year { get; set; }
        public IEnumerable<PostBriefDto> Posts { get; set; }
    }
}
