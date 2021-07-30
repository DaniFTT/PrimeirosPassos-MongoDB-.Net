using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class AlterandoDocumento
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


            Console.WriteLine("Listar o livro da Guerra dos Tronos");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            var livrosEncontrados = await conexao.Livros.Find(condicao).ToListAsync();

            foreach (var livro in livrosEncontrados)
            {
                Console.WriteLine(livro.ToJson());
                livro.Ano = 2001;
                livro.Paginas = 901;
                await conexao.Livros.ReplaceOneAsync(condicao, livro);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            foreach (var livro in livrosEncontrados)
            {
                Console.WriteLine(livro.ToJson());
            }

        }
    }
}
