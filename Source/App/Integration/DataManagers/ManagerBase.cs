using System.Data.Entity;

namespace Greedy.Integration.DataManagers
{
    public class ManagerBase : IDisposable
    {
        protected DbContext context;

        public ManagerBase(DbContext context)
        {
            this.context = context;
        }

        public virtual void Dispose() => context.Dispose();
    }
}