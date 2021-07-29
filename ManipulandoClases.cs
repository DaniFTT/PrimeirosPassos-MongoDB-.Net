using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosMongoDB
{
    class ManipulandoClases
    {
        static void Main(string[] args)
        {
            Task T = MainASync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainASync(string[] args)
        {
            //  {
            //      "Título":"Guerra dos Tronos",
            //      "Autor":"George R R Martin",
            //      "Ano":1999,
            //      "Páginas":856
            //      "Assunto": [
            //        "Fantasia",
            //        "Ação"
            //      ]
            //  }

            var doc = new BsonDocument
            {
                {"Titulo", "Guerra dos Tronos" }
            };
            doc.Add("Autor", "George R. R. Martim");
            doc.Add("Ano", 1999);
            doc.Add("Paginas", 856);

            doc.Add("Assunto", new BsonArray(new string[] { "fantasia", "Ação" }));

            Console.WriteLine(doc);

            // acesso ao servidor MongoDB
            string stringConnection = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConnection);

            // acesso ao banco de dados
            IMongoDatabase bancoDeDados = cliente.GetDatabase("Biblioteca");

            // acesso a collections
            IMongoCollection<BsonDocument> colecao = bancoDeDados.GetCollection<BsonDocument>("Livros");

            // incluindo um documento
            await colecao.InsertOneAsync(doc);


            Console.WriteLine("Documento Incluido");
        }
    }
}
