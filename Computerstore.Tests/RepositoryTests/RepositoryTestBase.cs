using Computerstore.Tests.Data;
using ComputerStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computerstore.Tests.RepositoryTests
{
    public class RepositoryTestBase : IDisposable 
    {
        protected readonly DataContext _context;

        public RepositoryTestBase()
        {
            // context options 
            var optionBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging();

            // context & seed in memory db
            _context = new DataContext(optionBuilder.Options);

            _context.Database.EnsureCreated();

            DataContextInitializer.Initialize(_context);
           

        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
