using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DataBaseConfigurations.Infrastructure
{
    public class MyDisposable: IDisposable
    {
        private bool IsDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool dispos)
        {
            if (!IsDisposed && dispos)
            {
                DisposeCore();
            }
            IsDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        } 

        ~MyDisposable()
        {
            Dispose(false);
        }

        
    }
}
