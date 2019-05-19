using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkServices.Services
{
    public class BaseServiceWithMapping
    {
        protected IMapper _mapper;
        public BaseServiceWithMapping(IMapper mapper)
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<Mapping.MappingProfile>(); });
            _mapper = new Mapper(config);
        }

    }
}
