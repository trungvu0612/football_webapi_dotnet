using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json.Serialization;

namespace WebApplicationFootBall.Common
{
    public static class FluentValidationService
    {
        public static IServiceCollection AddFluentService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            return services;
        }
        public static IMvcBuilder AddMvcControllers(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            return services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidationFilterAttribute));
            }).AddJsonOptions(x =>
                 x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        }
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            // Lấy tất cả các lớp Validator trong assembly hiện tại
            Assembly assembly = Assembly.GetExecutingAssembly();
            var validatorTypes = assembly.GetTypes()
                .Where(t => t.BaseType != null &&
                            t.BaseType.IsGenericType &&
                            t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

            // Đăng ký các lớp Validator với DI Container
            foreach (var validatorType in validatorTypes)
            {
                var interfaceType = validatorType.GetInterface($"IValidator`1");
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, validatorType);
                }
            }
            return services;
        }
    }
}
