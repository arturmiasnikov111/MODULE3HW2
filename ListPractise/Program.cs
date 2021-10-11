using ListPractise.Collections;
using ListPractise.Collections.Abstractions;
using ListPractise.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ListPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICultureResolver, CultureResolver>()
                .AddTransient<IPhoneBook<Contact>, PhoneBook<Contact>>()
                .AddTransient<Starter>()
                .BuildServiceProvider();
            var starter = serviceProvider.GetService<Starter>();
            starter.Run();
        }
    }
}
