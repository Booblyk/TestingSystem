using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DataBaseConfigurations.Infrastructure
{
    public class DbProvide: MyDisposable, IDbProvide
    {
        TestingSystemContext context;

        public TestingSystemContext Init()
        {
            return context ?? (context = new TestingSystemContext());
        }

        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }

    }
}
