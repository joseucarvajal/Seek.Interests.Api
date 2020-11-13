using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SeekQ.Interests.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeekQ.MyInterestLevels.Api.Test
{
    public class SimpleIntegrationTest : IDisposable
    {
        public InterestsDbContext _interestsDbContext;
        // private readonly DemoRepository _repository;
        public string _databaseName;

        public SimpleIntegrationTest()
        {
            _databaseName = Guid.NewGuid().ToString();

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<InterestsDbContext>();

            builder.UseSqlServer($"Server=127.0.0.1,1433;Database=SeekQ.Interests.{_databaseName};User Id=sa;Password=Password123")
                    .UseInternalServiceProvider(serviceProvider);

            _interestsDbContext = new InterestsDbContext(builder.Options);
            _interestsDbContext.Database.Migrate();

            // _repository = new DemoRepository(_dbContext);
        }

        // [Obsolete]
        [Obsolete]
        public void Dispose()
        {
            int count = _interestsDbContext.Database.ExecuteSqlCommand((string)$"DROP DATABASE [{_databaseName}]");
            _interestsDbContext.Database.EnsureDeleted();
        }
    }
}
