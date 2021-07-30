using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class ListandoDocumentosFiltros
    {
        static void Main(string[] args)
        {
            Task T = MainASync(args);
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainASync(string[] args)
        {
            var conexao = new ConectandoMongoDB();
            Console.WriteLine("Listando Arquivos");

            var Filtro = new BsonDocument();

            await conexao.Livros.Find(Filtro).ForEachAsync(X => Console.WriteLine(X.ToJson()));
            Console.WriteLine();

            Console.WriteLine("Listados");
            Console.WriteLine("------------------------------");


            Console.WriteLine("Listando Livros Machado de Assis");

            Filtro = new BsonDocument
            {
                { "Autor", "Machado de Assis" }
            };

            await conexao.Livros.Find(Filtro).ForEachAsync(X => Console.WriteLine(X.ToJson()));


        }
    }
}
