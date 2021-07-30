using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class ListandoDocumentosEmOrdem
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


            Console.WriteLine("Livros que sejam de Ficção Científica");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Gte(x => x.Paginas, 150);

            await conexao.Livros.Find(condicao).SortBy(x => x.Ano).ForEachAsync(X => Console.WriteLine(X.ToJson()));
        }
    }
}
