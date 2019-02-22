using Autofac;
using RedPet.Core.Auth;

namespace RedPet.API.Infrastructure.DI
{
    public class AuthModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JwtFactory>().As<IJwtFactory>();
        }
    }
}
