using System;

namespace TestingSystem.DataBaseConfigurations.Infrastructure
{
    public interface IDbProvide : IDisposable
    {
        TestingSystemContext Init();
    }
}
