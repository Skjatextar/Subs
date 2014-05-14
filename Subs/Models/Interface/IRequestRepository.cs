using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subs.Models.Entity;

namespace Subs.Models.Interface
{
    public interface IRequestRepository
    {
        IQueryable<Request> GetRequests();
        DbSet<Request> GetRequestsByCategory();

    }

}
