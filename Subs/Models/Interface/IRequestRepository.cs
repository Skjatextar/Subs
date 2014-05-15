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
        // Saekja lista af beidnum
        IQueryable<Request> GetRequests();
        // Saekja bunka af stokum beidnum
        DbSet<Request> GetRequestsByCategory();
        // Saekja eina beidni eftir ID
        Request GetRequestById(int? id);
        // Setja beidnir a gagnagrunn
        void InsertRequest(Request request);
        // Vista breytingar i gagnagrunn
        void SaveChanges();
    }
}
