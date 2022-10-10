using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Service;

namespace ProjOngClubeAumigos.Model
{
    public class ControleAdocao
    {
        #region Propriedades
        public int Num_Chip { get; set; }
        public string CPF { get; set; }
        public DateTime DataAdocao { get; set; }
        #endregion

        #region Constantes
        public readonly static string INSERT = "INSERT INTO ControleAdocao (Num_Chip, CPF, DataAdocao) VALUES (@Num_Chip, @CPF, @DataAdocao)";

        public readonly static string SELECT = "SELECT Num_Chip, CPF, DataAdocao FROM ControleAdocao";

        public readonly static string SELECTONE = "SELECT Num_Chip, CPF, DataAdocao FROM ControleAdocao";
        #endregion

        #region Metodo
        public override string ToString()
        {
            return $"\nNúmero CHIP: {this.Num_Chip} \nCPF: {this.CPF} \nData Adoção: {this.DataAdocao.ToShortDateString()}".ToString();
        }
        #endregion

        public void CadastroAdocao()
        {
            Console.Clear();
            Console.WriteLine("\t>>> CADASTRO DE ADOÇÃO <<<");
            Console.WriteLine("\n\t >>> Lista de CPF cadastrados <<<\n");
            
            new AdotanteService().GetAllCPF().ForEach(x => Console.WriteLine(x.CPF));

            Console.Write("Informe o número do CPF: ");
            CPF = Console.ReadLine();

            Console.WriteLine("\n\t >>> Lista de CHIPs cadastrados <<<");
            new AnimalService().GetAllNum_Chip().ForEach(x => Console.WriteLine(x.Num_Chip));
            Console.Write("\nInforme o número de identificação do animal: ");
            Num_Chip = int.Parse(Console.ReadLine());
            
            DataAdocao = DateTime.Now;

            Console.WriteLine("Pressione ENTER para continuar...");
        }
    }
}
