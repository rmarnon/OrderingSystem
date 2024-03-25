using FluentValidation;
using Ordering.System.Api.Models;
using Ordering.System.Api.Repositories;
using Ordering.System.Api.Repositories.Interfaces;
using Ordering.System.Api.Services;
using Ordering.System.Api.Services.Interfaces;
using Ordering.System.Api.Validators;

namespace Ordering.System.Api.Extensions
{
    public static class DI
    {
        public static IServiceCollection IoC(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();

            services.AddTransient<IValidator<OrderInputModel>, OrderValidator>();
            services.AddTransient<IValidator<ProductInputModel>, ProductValidator>();
            services.AddTransient<IValidator<SupplierInputModel>, SupplierValidator>();

            return services;
        }
    }
}
