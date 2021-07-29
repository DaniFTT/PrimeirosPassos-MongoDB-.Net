using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ExemplosMongoDB
{
    class ManipulandoDocumentos
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
        }
    }
}
