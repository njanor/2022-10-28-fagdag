using Clippers.Core.EventStore;
using Clippers.Core.Haircut.Repository;
using Clippers.Core.Haircut.Services;
using Clippers.Infrastructure.EventStore;
using Clippers.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Savorboard.CAP.InMemoryMessageQueue;

namespace Clippers.Test.Integration
{
    [TestClass]
    public class OutboxEventStoreTests
    {
        private readonly IServiceProvider _serviceProvider;

        public OutboxEventStoreTests()
        {
            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"))
                .AddCap(x =>
                        {
                            //x.UseInMemoryStorage();
                            x.UseMongoDB("localhost:27017");
                            x.UseInMemoryMessageQueue();
                        }).Services
                .AddSingleton<IEventStore, OutboxEventStore>()
                .AddScoped<IHaircutRepository, HaircutRepository>()
                //.AddScoped<ICreateHaircutService, CreateHaircutService>()
                .BuildServiceProvider();
        }
    }
}