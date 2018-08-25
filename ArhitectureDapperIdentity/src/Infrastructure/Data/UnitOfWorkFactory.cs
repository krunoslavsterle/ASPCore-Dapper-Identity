using System;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public UnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUnitOfWork Create()
        {
            return _serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
        }
    }
}
