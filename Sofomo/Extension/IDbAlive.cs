using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sofomo.Extension
{
   public interface IDbAlive
   {
       bool CheckDbConnection(string address);
   }
}
