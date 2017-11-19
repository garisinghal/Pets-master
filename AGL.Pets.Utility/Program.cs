using Pets.Common.Interfaces;
using Pets.Domain;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.Utility
{
    class Program
    {
        private static IWindsorContainer di = new WindsorContainer();

        static void Main(string[] args)
        {
            di.Install(FromAssembly.This());

            var repository = di.Resolve<IPersonRepository>();

            var persons = repository.GetCatsByOwnerGender();

            WritePets(persons);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            di.Dispose();
        }

        private static void WritePets(Dictionary<string, List<Pet>> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine("{0}", item.Key);
                foreach (var pet in item.Value)
                {
                    Console.WriteLine("\t{0}", pet.Name);
                }
            }
        }
    }
}
