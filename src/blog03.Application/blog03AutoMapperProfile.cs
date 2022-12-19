using AutoMapper;
using blog03.blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog03
{
    public class blog03AutoMapperProfile:Profile
    {
        public blog03AutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
