using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Hoff.Application.Common.Interfaces;
using Hoff.Infrastructure.CbRf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Hoff.Infrastructure.Integration.Test
{
    public class CbRfRepositoryTest
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CbRfRepositoryTest()
        {
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            (new CbRfInstaller()).Install(serviceCollection, configuration);

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            _scopeFactory = serviceCollection.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [Fact]
        public async Task GetCursOnDateAsync_NotBeNullOrEmpty()
        {
            var scope = _scopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetService<IGetCursOnDate>();
            var cources = await repository.GetCursOnDateAsync(new DateTime(2020,11,27), default);
            cources.Should().NotBeNullOrEmpty();
        }
    }
}
