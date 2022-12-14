using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Service;

namespace ProjOngClubeAumigos.Model
{
    public class Animal
    {
        #region Propriedades
        public int Num_Chip { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public string Nome { get; set; }
        #endregion

        #region Constantes
        public readonly static string INSERT = "INSERT INTO Animal (Familia, Raca, Sexo, Nome)" +
            "VALUES (@Familia, @Raca, @Sexo, @Nome)";

        public readonly static string SELECT = "SELECT Num_Chip, Familia, Raca, Sexo, Nome FROM Animal";

        public readonly static string SELECTNum_Chip = "SELECT Num_Chip FROM Animal";

        public readonly static string UPDATE = $"UPDATE Animal SET Familia = @Familia, Raca = @Raca, Sexo = @Sexo, Nome = @Nome WHERE Num_Chip = @Num_Chip";

        public readonly static string SELECTCHIP = $"SELECT Num_Chip FROM Animal WHERE Num_Chip = ";

        public readonly static string DELETE = $"DELETE FROM Animal WHERE Num_Chip = ";

        //public readonly static string UPDATE = "UPDATE Adotante SET Num_Chip = Num_Chip = @Num_Chip, Familia = @Familia, Raca = @Raca, Sexo = @Sexo, Nome = @Novo";

        //public readonly static string DELETEONE = "DELETE FROM Animal WHERE Num_Chip = @Num_Chip";

        //public readonly static string SELECTONE = "SELECT Num_Chip, Familia, Raca, Sexo, Nome FROM Animal";


        #endregion

        #region Metodo
        public override string ToString()
        {
            return $"Número CHIP: {this.Num_Chip} \nFamília: {this.Familia} \nRaça: {this.Raca} \nSexo: {this.Sexo} \nNome: {this.Nome}\n".ToString();
        }
        #endregion

        #region Cadastro Animal
        public void CadastrarAnimal()
        {
            Console.Clear();
            Console.WriteLine("\n\t>>> CADASTRO DO ANIMAL <<<");

            if (!CadastrarFamilia()) return;

            if (!CadastrarRaca()) return;

            if (!CadastrarSexo()) return;

            if (!CadastrarNome()) return;
        }
        #endregion

        #region Familia
        private bool CadastrarFamilia()
        {
            do
            {
                Console.Write("Informe a família [cachorro, gato, papagaio...]: ");
                Familia = Console.ReadLine();
                if (Familia.Length == 0)
                {
                    Console.WriteLine("Campo obrigatório!");
                }
                if (Familia.Length > 30)
                {
                    Console.WriteLine("Informe um nome de família com menos de 50 caracteres!");
                }
            } while (Familia.Length > 30 || Familia.Length == 0);
            return true;
        }
        #endregion

        #region Raça
        private bool CadastrarRaca()
        {
            do
            {
                Console.Write("Informe a raça: ");
                Raca = Console.ReadLine();
                if (Raca.Length == 0)
                {
                    Console.WriteLine("Raça opcional!");
                }
                if (Raca.Length > 30)
                {
                    Console.WriteLine("Informe uma raça com menos de 50 caracteres!");
                }
            } while (Raca.Length > 30 || Raca.Length == 0);
            return true;
        }
        #endregion

        #region Sexo
        private bool CadastrarSexo()
        {
            do
            {
                Console.Write("Informe seu sexo [M] Masculino - [F] Feminino - [N] Prefere não informar: ");
                Sexo = new TratamentoDado().TratarDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return false;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");
            return true;
        }
        #endregion

        #region Nome
        private bool CadastrarNome()
        {
            do
            {
                Console.Write("Informe o nome: ");
                Nome = Console.ReadLine();
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Campo obrigatório!");
                }
                if (Nome.Length > 30)
                {
                    Console.WriteLine("Informe um nome de família com menos de 50 caracteres!");
                }
            } while (Nome.Length > 30 || Nome.Length == 0);
            return true;
        }
        #endregion

        #region Update Animal
        public void UpdateAnimal()
        {
            int op;
            Console.WriteLine("\n>>> ALTERAR CADASTRO DO ANIMAL <<<\n");

            if (!VerificarChip()) return;

            Console.WriteLine("[1] Alterar Nome\n[2] Alterar Familia\n[3] Alterar Raca\n[4] Alterar Sexo\n[0] Sair");

            do
            {
                try { op = int.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("Dado inválido!"); op = -1; }

            } while (op < 0 && op > 11);

            Animal animal = new AnimalService().GetAnimal(Num_Chip);

            switch (op)
            {
                case 0:
                    return;

                case 1:
                    if (!CadastrarNome()) return;
                    animal.Nome = this.Nome;
                    break;

                case 2:
                    if (!CadastrarFamilia()) return;
                    animal.Familia = this.Familia;
                    break;

                case 3:
                    if (!CadastrarRaca()) return;
                    animal.Raca = this.Raca;
                    break;

                case 4:
                    if (!CadastrarSexo()) return;
                    animal.Sexo = this.Sexo;
                    break;


            }
            new AnimalService().Update(animal);
            Console.WriteLine("Pressione ENTER para retornar ao menu...");
            Console.ReadKey();
        }
        #endregion

        #region Deletar Animal
        public void DeleteAnimal()
        {
            string op;
            Console.WriteLine("\n>>> DELETAR ANIMAL <<<\n");

            if (!VerificarChip()) return;

            Animal animal = new AnimalService().GetAnimal(Num_Chip);

            Console.WriteLine(animal.ToString());

            while (true)
            {
                Console.Write("\nConfirma deletar animal?\n[S] Sim\n[N] Não\nOpção:  ");
                op = Console.ReadLine().ToUpper();

                if (op == "0") return;
                else if (op != "S" && op != "N") Console.WriteLine("Dado inválido");
                else break;
            }

            if (op == "S") new AnimalService().Delete(animal);
            else return;
        }
        #endregion

        #region VerificaCHIP
        private bool VerificarChip()
        {
            do
            {
                Console.Write("Informe seu Número CHIP: ");
                try
                {
                    Num_Chip = int.Parse(new TratamentoDado().TratarDado(Console.ReadLine()));
                }
                catch { Console.WriteLine("Dado inválido"); Num_Chip = -1; }


                if (Num_Chip == 0)
                    return false;
                bool verifica = new AnimalService().VerifChip(Num_Chip);
                if (!verifica)
                {
                    Console.WriteLine("CHIP não cadastrado!!!");
                    Num_Chip = -1;
                }

            } while (Num_Chip < 1);
            return true;
        }
        #endregion
    }
}