using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DataBaseConfigurations.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbProvide DbProvide;

        private TestingSystemContext Context;

        public UnitOfWork(IDbProvide DbProvide)
        {
            this.DbProvide = DbProvide;
        }
        public TestingSystemContext DbContext
        {
            get { return Context ?? (Context = DbProvide.Init()); }
        }
        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
