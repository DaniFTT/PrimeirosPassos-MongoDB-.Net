using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosMongoDB
{
    class AlterandoDocumentosClasse
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
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano, 2002);
            await conexao.Livros.UpdateOneAsync(condicao, condicaoAlteracao);


            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            livrosEncontrados = await conexao.Livros.Find(condicao).ToListAsync();

            foreach (var livro in livrosEncontrados)
            {
                Console.WriteLine(livro.ToJson());
            }

            Console.WriteLine();
            Console.WriteLine("Todos de machado de assis para M. assis\n");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            livrosEncontrados = await conexao.Livros.Find(condicao).ToListAsync();

            foreach (var livro in livrosEncontrados)
            {
                Console.WriteLine(livro.ToJson());
            }

            Console.WriteLine("\n Convertido para:\n");


            construtorAlteracao = Builders<Livro>.Update;
            condicaoAlteracao = construtorAlteracao.Set(x => x.Autor, "M. Assis");
            await conexao.Livros.UpdateManyAsync(condicao, condicaoAlteracao);

            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "M. Assis");

            livrosEncontrados = await conexao.Livros.Find(condicao).ToListAsync();

            foreach (var livro in livrosEncontrados)
            {
                Console.WriteLine(livro.ToJson());
            }
        }
    }
}
