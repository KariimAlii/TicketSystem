using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Persistance.Context
{
    public partial class TicketAppDbContext
    {
        public int DBSaveChanges()
        {
            return this.SaveChanges();
        }

        public async Task<int> DBSaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
        }
    }
}
