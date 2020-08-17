using System;
using System.Collections.Generic;
using System.Text;
using Fixer.CQRS.Commands.Dispatchers;
using Microsoft.Extensions.DependencyInjection;

namespace Fixer.CQRS.Commands
{
    public static class Extensions
    {
        public static IFixerBuilder AddCommandHandlers(this IFixerBuilder builder)
        {
            builder.Services.Scan(s =>
                s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return builder;
        }

        public static IFixerBuilder AddInMemoryCommandDispatcher(this IFixerBuilder builder)
        {
            builder.Services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            return builder;
        }
    }
}
