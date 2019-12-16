using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using Sofomo.Models;

namespace Sofomo.Data.IRepositories
{
    public interface IRepository 
    {
        IpInfo Get(string address);
        IEnumerable<IpInfo> GetAll();
        int Add(IpInfo entity);
        HttpStatusCode Remove(string address);
    }
}
