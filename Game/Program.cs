using System;
using Microsoft.Extensions.DependencyInjection;
using BLL;
using Services;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddSingleton<IBll, Bll>().AddSingleton<IService, Service>()
            .BuildServiceProvider();

            var service = serviceProvider.GetService<IService>();
            var bll = serviceProvider.GetService<IBll>();
            Player a = new Player();
            Player b = new Player();
            Game game = new Game(service, bll,a,b);


        }
    }
}
