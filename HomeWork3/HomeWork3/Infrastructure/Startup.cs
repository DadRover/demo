using HomeWork3.Services.Basket.Handlers.Commands;
using HomeWork3.Services.Basket.Handlers.Queries;
using HomeWork3.Services.Basket.Repository;
using HomeWork3.Services.Basket.Services;
using HomeWork3.Services.Display;
using HomeWork3.Services.Orders.Handlers.Commands;
using HomeWork3.Services.Orders.Handlers.Queries;
using HomeWork3.Services.Orders.Repository;
using HomeWork3.Services.Orders.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HomeWork3.Infrastructure
{
    internal class Startup
    {
        private static Startup _instance;
        private static readonly object LockObj = new object();

        private static IServiceProvider _serviceProvider;
        private readonly Runner _runner;

        private Startup()
        {
            ServiceCollectionInit();
            _runner = new Runner(_serviceProvider);
        }
        public static Startup GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (LockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new Startup();
                        }
                    }
                }
                return _instance;
            }
        }

        private static void ServiceCollectionInit()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDisplayService, DisplayService>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrdersCommandHandler, OrdersCommandHandler>();
            services.AddScoped<IOrdersQueryHandler, OrdersQueryHandler>();
            services.AddScoped<IEventOrdersRepository, EventOrdersRepository>();

            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketCommandsHandler, BasketCommandsHandler>();
            services.AddScoped<IBasketQueriesHandler, BasketQueriesHandler>();
            services.AddScoped<IBasketRepository, BasketRepository>();

            _serviceProvider = services.BuildServiceProvider();

        }
        public void Start() => _runner.Run();

    }
}
