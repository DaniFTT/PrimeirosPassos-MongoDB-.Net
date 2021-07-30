using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosMongoDB
{
    class ManipulandoClassesExternas
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
            livro.Titulo = "Star Wars Legends";
            livro.Autor = "Timothy Zahn";
            livro.Ano = 2010;
            livro.Paginas = 245;
            livro.Assuntos = new List<string>() { "Ficção Cientifica", "Ação" };


            // acesso ao servidor MongoDB
            //string stringConnection = "mongodb://localhost:27017";
            //IMongoClient cliente = new MongoClient(stringConnection);

            //// acesso ao banco de dados
            //IMongoDatabase bancoDeDados = cliente.GetDatabase("Biblioteca");

            //// acesso a collections
            //IMongoCollection<Livro> colecao = bancoDeDados.GetCollection<Livro>("Livros");

            // incluindo um documento

            // Acessando atraves da classe de conexao

            var conexao = new ConectandoMongoDB();
           

            await conexao.Livros.InsertOneAsync(livro);


            Console.WriteLine("Documento Incluido");
        }
    }
}
