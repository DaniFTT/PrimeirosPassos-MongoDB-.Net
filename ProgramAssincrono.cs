using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExemplosMongoDB
{
    class ProgramAssincrono
    {
        static void Main(string[] args)
        {
            Task T = MainASync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainASync(string[] args)
        {
            Console.WriteLine("Esperando 10 segundos .......");
            await Task.Delay(10000);
            Console.WriteLine("Esperei 10 segundos!");
        }
    }
}
