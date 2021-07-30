using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosMongoDB
{
    class UsandoValoresLivro
    {
        static void Main(string[] args)
        {
            Task T = MainASync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainASync(string[] args)
        {

            var conexao = new ConectandoMongoDB();

            var livro = ValoresLivro.IncluiValoresLivro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Literatura  Brasileira");
            await conexao.Livros.InsertOneAsync(livro);


            var livro2 = ValoresLivro.IncluiValoresLivro("A Arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto Ajuda");
            await conexao.Livros.InsertOneAsync(livro2);



            Console.WriteLine("Documento Incluido");
        }
    }
}
