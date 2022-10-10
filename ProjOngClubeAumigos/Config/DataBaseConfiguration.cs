using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ProjOngClubeAumigos.Config
{
    public class DataBaseConfiguration
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static string Get()
        {
            //builder constrói o processo de conexão
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) //diretorio onde está o projeto
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); 

            Configuration = builder.Build();
            return Configuration["ConnectionStrings:DefaultConnection"]; //ele vai no appsettings e depois retornar a string de conexão
        }
    }
}
