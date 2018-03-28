﻿using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddSingleton<IService, Service>().BuildServiceProvider();
            var service = serviceProvider.GetService<IService>();       
            Player a = new Player();
            Player b = new Player();
            Game game = new Game(service,a,b);
            string input, output;
            Console.WriteLine("Insert input path");
            input = Console.ReadLine();
            if (CheckFile(input) & checkLetters(input))
            {
                Console.WriteLine("Insert output path");
                output = Console.ReadLine();
                if(CheckFile(output))
                {
                   service.readfile(input);
                }else
                {
                    Console.WriteLine("File doesnt exists");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("File doesn't exists or doesn't contains letters A or B");
                Console.ReadKey();
                Environment.Exit(0);
            }
          
        }

        public static bool CheckFile(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
                     
        }

        public static bool checkLetters(string path)
        {
            if (!File.ReadAllText(path).Contains("A") | !File.ReadAllText(path).Contains("B"))
            {
                return false;
            }
            return true;
        } 
    }
}
