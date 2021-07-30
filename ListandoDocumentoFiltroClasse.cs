using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosMongoDB
{
    class ListandoDocumentoFiltroClasse
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

            Console.WriteLine("Listandoo ....\n");

            var Filtro = new BsonDocument
            {
                { "Autor", "Machado de Assis" }
            };


            await conexao.Livros.Find(Filtro).ForEachAsync(X => Console.WriteLine(X.ToJson()));

            Console.WriteLine("Fim da Lista\n\n");


            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");
            await conexao.Livros.Find(condicao).ForEachAsync(X => Console.WriteLine(X.ToJson()));



            Console.WriteLine("Livros publicados após 1999");

            construtor = Builders<Livro>.Filter;
            condicao = (construtor.Gte(x => x.Ano, 1999) & construtor.Eq(x => x.Autor, "George R R Martin")) | construtor.Eq(x => x.Titulo, "Memórias Póstumas de Brás Cubas");
            await conexao.Livros.Find(condicao).ForEachAsync(X => Console.WriteLine(X.ToJson()));


            Console.WriteLine("Livros que sejam de Ficção Científica");

            construtor = Builders<Livro>.Filter;
            condicao = construtor.AnyEq(x => x.Assuntos, "Ficção Científica" ) | construtor.AnyEq(x => x.Assuntos, "Ficção Cientifica");
            await conexao.Livros.Find(condicao).ForEachAsync(X => Console.WriteLine(X.ToJson()));
        }
    }
}
