using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Tandem.Models.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //map from postcontact to contact
            CreateMap<PostContact, Contact>();
        }
    }
}
