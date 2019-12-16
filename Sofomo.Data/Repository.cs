using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sofomo.Data.IRepositories;
using Sofomo.Models;

namespace Sofomo.Data
{
    public class Repository : IRepository
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(IpInfo entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
                return entity.Id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public IpInfo Get(string address)
        {
            return _context.IpInfos
                .Include(p => p.Location)
                .ThenInclude(p => p.Languages)
                .FirstOrDefault(p => p.SearchAddress == address);
        }

        public IEnumerable<IpInfo> GetAll()
        {
            return _context.IpInfos;
        }

        public HttpStatusCode Remove(string address)
        {
            try
            {
                var entity = Get(address);
                if (entity == null)
                {
                    return HttpStatusCode.NotFound;
                }
                _context.Remove(entity);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.InternalServerError;
            }

           
        }
    }
}
