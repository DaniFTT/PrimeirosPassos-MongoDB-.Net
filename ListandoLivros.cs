using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class ListandoLivros
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

            await conexao.Livros.Find(new BsonDocument()).ForEachAsync(X => Console.WriteLine(X.ToJson()));

            //Console.WriteLine(listaLivros.ToJson<Livro>());

            //foreach (var doc in listaLivros)
            //{
            //    Console.WriteLine(doc.ToJson<Livro>());

            //}

            Console.WriteLine("Listados");
        }
    }
}
