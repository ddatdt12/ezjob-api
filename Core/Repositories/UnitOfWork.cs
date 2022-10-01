﻿using EzjobApi.Core.Contracts;
using EzjobApi.Models;

namespace EzjobApi.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }
        public IAuthRepository Auth { get; private set; }

        public UnitOfWork(DataContext context, ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(context, _logger);
            Auth = new AuthRepository(configuration, context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
