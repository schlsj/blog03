using System;
using System.ComponentModel.DataAnnotations;

namespace blog03
{
    public class PagingInput
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
        [Range(10, 30)]
        public int Limit { get; set; } = 10;
    }
}
