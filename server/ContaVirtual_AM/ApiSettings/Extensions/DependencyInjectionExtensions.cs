using AutoMapper;
using ContaVirtual_AM.Domain.v1.Accounts;
using ContaVirtual_AM.Domain.v1.Transactions;
using ContaVirtual_AM.Repository.Accounts;
using ContaVirtual_AM.Repository.Transactions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ContaVirtual_AM.ApiSettings.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            AddMediatr(services);
            AddAutoMapper(services);

            AddAccountFeature(services);
            AddTransactionFeature(services);
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }

        private static void AddAccountFeature(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
        }

        private static void AddTransactionFeature(this IServiceCollection services)
        {
            services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
        }
    }
}
