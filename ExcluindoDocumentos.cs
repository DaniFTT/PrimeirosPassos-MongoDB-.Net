using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class ExcluindoDocumentos
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

            Console.WriteLine("Buscar os Livros do M. Assis");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "M. Assis");

            var livrosEncontrados = await conexao.Livros.Find(condicao).ToListAsync();

            foreach (var livro in livrosEncontrados)
            {
                Console.WriteLine(livro.ToJson());
            }

            Console.WriteLine("Fim da Lista\n\n");

            Console.WriteLine("Excluindo livros\n");

            await conexao.Livros.DeleteManyAsync(condicao);


            livrosEncontrados = await conexao.Livros.Find(condicao).ToListAsync();

            foreach (var livro in livrosEncontrados)
            {
                Console.WriteLine(livro.ToJson());
            }

            Console.WriteLine("Fim da Lista\n\n");
        }
    }
}
