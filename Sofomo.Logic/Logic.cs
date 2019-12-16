using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AutoMapper;
using Sofomo.Data.IRepositories;
using Sofomo.DTO;
using Sofomo.Models;

namespace Sofomo.Logic
{
    public class Logic : ILogic
    {
        private IRepository _repo;
        private IMapper _mapper;
        public Logic(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public int Add(IpInfoDTO ipInfoDto)
        {
            var dbValue = _mapper.Map<IpInfo>(ipInfoDto);
          return _repo.Add(dbValue);
        }

        public HttpStatusCode Delete(string address)
        {
            return _repo.Remove(address);
        }

        public IpInfoDTO Get(string address)
        {
            var dbEntity = _repo.Get(address);
            return (_mapper.Map<IpInfoDTO>(dbEntity));
        }
   
    }
}
