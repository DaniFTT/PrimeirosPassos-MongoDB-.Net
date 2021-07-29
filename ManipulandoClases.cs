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
            //var doc = new BsonDocument
            //{
            //    {"Titulo", "Guerra dos Tronos" }
            //};
            //doc.Add("Autor", "George R. R. Martim");
            //doc.Add("Ano", 1999);
            //doc.Add("Paginas", 856);

            //doc.Add("Assunto", new BsonArray(new string[] { "fantasia", "Ação" }));

            //Console.WriteLine(doc);

            //------------------------------------------------------------

            // inicializar uma variavel do tipo objeto livro

            Livro livro = new Livro();
            livro.Titulo = "Sob a redoma";
            livro.Autor = "Sthepen King";
            livro.Ano = 2012;
            livro.Paginas = 679;
            livro.Assuntos = new List<string>() { "Ficção Cientifica", "Terror", "Ação" };

            // acesso ao servidor MongoDB
            string stringConnection = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConnection);

            // acesso ao banco de dados
            IMongoDatabase bancoDeDados = cliente.GetDatabase("Biblioteca");

            // acesso a collections
            IMongoCollection<Livro> colecao = bancoDeDados.GetCollection<Livro>("Livros");

            // incluindo um documento
            await colecao.InsertOneAsync(livro);


            Console.WriteLine("Documento Incluido");
        }
    }
}
