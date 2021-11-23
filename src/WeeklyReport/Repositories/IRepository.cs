using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyReport.Repositories
{
    interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);

        TEntity Read(int entityId);

        TEntity Update(TEntity entity);

        TEntity Delete(int entityId);


    }
}
