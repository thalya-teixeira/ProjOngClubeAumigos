using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjOngClubeAumigos.Service;

namespace ProjOngClubeAumigos.Model
{
    public class Adotante
    {
        #region Propriedades
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        #endregion

        #region Constantes
        public readonly static string INSERT = "INSERT INTO Adotante(CPF, Nome, Sexo, DataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) " +
            "VALUES (@CPF, @Nome, @Sexo, @DataNasc, @Telefone, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado);";

        public readonly static string SELECT = "SELECT CPF, Nome, Sexo, DataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado FROM Adotante";

        public readonly static string SELECTCPF = "SELECT CPF FROM Adotante";

        public readonly static string UPDATE = "UPDATE Adotante SET Nome = @Nome, Sexo = @Sexo, DataNasc = @DataNasc, Telefone = @Telefone, Logradouro = @Logradouro" +
            "Numero =  @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade WHERE CPF = @CPF";

        public readonly static string DELETEONE = "DELETE FROM Adotante WHERE CPF = @CPF";

        public readonly static string SELECTONE = "SELECT CPF, Nome, Sexo, DataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado FROM Adotante WHERE CPF = @CPF";

        public readonly static string SELECTALL = "SELECT * FROM Adotante";

        public readonly static string UPDATENOME = "UPDATE dbo.Adotante SET Nome= @Nome WHERE CPF=@CPF";
        #endregion

        #region Metodo
        public override string ToString()
        {
            return $"CPF: {this.CPF} \nNome: {this.Nome} \nSexo: {this.Sexo} \nData de Nascimento: {this.DataNasc.ToShortDateString()} \nTelefone: {this.Telefone} \nEndereco: \nLogradouro {this.Logradouro}" +
                $" \nNumero: {this.Numero} \nComplemento: {this.Complemento} \nBairro: {this.Bairro} \nCidade: {this.Cidade}\n".ToString();
        }
        #endregion

        #region Cadastrar Adotante
        public void CadastrarAdotante()
        {
            bool validacao = false;

            Console.Clear();
            Console.WriteLine("\n\t>>> CADASTRO DO ADOTANTE <<<");

            if (!VerificaCPF())
                return;

            do
            {
                Console.Write("Informe seu nome completo: ");
                Nome = Console.ReadLine();
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Nome obrigatório!");
                }
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Informe um nome com menos de 50 caracteres!");
                }
            } while (Nome.Length > 50 || Nome.Length == 0);

            do
            {
                Console.Write("Sexo [F] Feminino [M] Masculino [N] Prefere não informar: ");
                Sexo = new TratamentoDado().TratarDado(Console.ReadLine().ToLower().ToUpper().Trim());
                if (Sexo == "0")
                    return;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");

            do
            {
                Console.Write("Data de nascimento: ");

                try
                {
                    DataNasc = DateTime.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("Formato de data inválido [dd/mm/aaaa]");
                    validacao = true;
                }
                if (DataNasc > DateTime.Now)
                {
                    Console.WriteLine("Data de aniversário não pode ser futura!");
                    validacao = true;
                }

            } while (validacao);

            do
            {
                Console.Write("Informe o seu telefone para contato: ");
                Telefone = Console.ReadLine();
                if (Telefone.Length == 0)
                {
                    Console.WriteLine("Telefone obrigatório!");
                }
                if (Telefone.Length > 11)
                {
                    Console.WriteLine("Informe um telefone com menos de 11 caracteres!");
                }
            } while (Telefone.Length > 11 || Telefone.Length == 0);

            do
            {
                Console.Write("Logradouro: ");
                Logradouro = Console.ReadLine();
                if (Logradouro.Length == 0)
                {
                    Console.WriteLine("Logradouro obrigatório!");
                }
                if (Logradouro.Length > 50)
                {
                    Console.WriteLine("Informe um logradouro com menos de 50 caracteres!");
                }
            } while (Logradouro.Length > 50 || Logradouro.Length == 0);

            do
            {
                Console.Write("Número da residência: ");
                Numero = Console.ReadLine();
                if (Numero.Length == 0)
                {
                    Console.WriteLine("Número obrigatório!");
                }
                if (Numero.Length > 10)
                {
                    Console.WriteLine("Informe um número com menos de 10 caracteres!");
                }
            } while (Numero.Length > 10 || Numero.Length == 0);

            do
            {
                //verificar se tem ou nao complemento

                Console.Write("Complemento: ");
                Complemento = Console.ReadLine();
                if (Complemento.Length == 0)
                {
                    Console.WriteLine("Complemento obrigatório!");
                }
                if (Complemento.Length > 10)
                {
                    Console.WriteLine("Informe um complemento com menos de 10 caracteres!");
                }
            } while (Complemento.Length > 10 || Logradouro.Length == 0);

            do
            {
                Console.Write("Bairro: ");
                Bairro = Console.ReadLine();
                if (Bairro.Length == 0)
                {
                    Console.WriteLine("Bairro obrigatório!");
                }
                if (Bairro.Length > 50)
                {
                    Console.WriteLine("Informe nome de bairro com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);

            do
            {
                Console.Write("Cidade: ");
                Cidade = Console.ReadLine();
                if (Cidade.Length == 0)
                {
                    Console.WriteLine("Cidade obrigatório!");
                }
                if (Cidade.Length > 50)
                {
                    Console.WriteLine("Informe nome de cidade com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);

            do
            {
                Console.Write("Estado [Ex: SP]: ");
                Estado = Console.ReadLine();
                if (Estado.Length == 0)
                {
                    Console.WriteLine("Estado obrigatório!");
                }
                if (Estado.Length > 2)
                {
                    Console.WriteLine("Informe apenas 2 caracter para estado!");
                }
            } while (Estado.Length > 2 || Estado.Length == 0);
        }
        #endregion

        #region Editar Adotante
        public void UpdateAdotante()
        {
            Console.Clear();
            Console.Write("Digite o nome que deseja alterar o contato: ");
            string alt = Console.ReadLine();
            bool validacao = false;

            do
            {
                Console.Write("\nNome: ");
                Nome = Console.ReadLine();
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Nome obrigatório!");
                }
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Informe um nome com menos de 50 caracteres!");
                }
            } while (Nome.Length > 50 || Nome.Length == 0);

            do
            {
                Console.Write("Sexo [F] Feminino [M] Masculino [N] Prefere não informar: ");
                Sexo = new TratamentoDado().TratarDado(Console.ReadLine().ToLower().ToUpper().Trim());
                if (Sexo == "0")
                    return;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");

            do
            {
                Console.Write("Data de nascimento: ");

                try
                {
                    DataNasc = DateTime.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("Formato de data inválido [dd/mm/aaaa]");
                    validacao = true;
                }
                if (DataNasc > DateTime.Now)
                {
                    Console.WriteLine("Data de aniversário não pode ser futura!");
                    validacao = true;
                }

            } while (validacao);

            do
            {
                Console.Write("Informe o seu telefone para contato: ");
                Telefone = Console.ReadLine();
                if (Telefone.Length == 0)
                {
                    Console.WriteLine("Telefone obrigatório!");
                }
                if (Telefone.Length > 11)
                {
                    Console.WriteLine("Informe um telefone com menos de 11 caracteres!");
                }
            } while (Telefone.Length > 11 || Telefone.Length == 0);

            do
            {
                Console.Write("Logradouro: ");
                Logradouro = Console.ReadLine();
                if (Logradouro.Length == 0)
                {
                    Console.WriteLine("Logradouro obrigatório!");
                }
                if (Logradouro.Length > 50)
                {
                    Console.WriteLine("Informe um logradouro com menos de 50 caracteres!");
                }
            } while (Logradouro.Length > 50 || Logradouro.Length == 0);

            do
            {
                Console.Write("Número da residência: ");
                Numero = Console.ReadLine();
                if (Numero.Length == 0)
                {
                    Console.WriteLine("Número obrigatório!");
                }
                if (Numero.Length > 10)
                {
                    Console.WriteLine("Informe um número com menos de 10 caracteres!");
                }
            } while (Numero.Length > 10 || Numero.Length == 0);

            do
            {
                //verificar se tem ou nao complemento

                Console.Write("Complemento: ");
                Complemento = Console.ReadLine();
                if (Complemento.Length == 0)
                {
                    Console.WriteLine("Complemento obrigatório!");
                }
                if (Complemento.Length > 10)
                {
                    Console.WriteLine("Informe um complemento com menos de 10 caracteres!");
                }
            } while (Complemento.Length > 10 || Logradouro.Length == 0);

            do
            {
                Console.Write("Bairro: ");
                Bairro = Console.ReadLine();
                if (Bairro.Length == 0)
                {
                    Console.WriteLine("Bairro obrigatório!");
                }
                if (Bairro.Length > 50)
                {
                    Console.WriteLine("Informe nome de bairro com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);

            do
            {
                Console.Write("Cidade: ");
                Cidade = Console.ReadLine();
                if (Cidade.Length == 0)
                {
                    Console.WriteLine("Cidade obrigatório!");
                }
                if (Cidade.Length > 50)
                {
                    Console.WriteLine("Informe nome de cidade com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);

            do
            {
                Console.Write("Estado [Ex: SP]: ");
                Estado = Console.ReadLine();
                if (Estado.Length == 0)
                {
                    Console.WriteLine("Estado obrigatório!");
                }
                if (Estado.Length > 2)
                {
                    Console.WriteLine("Informe apenas 2 caracter para estado!");
                }
            } while (Estado.Length > 2 || Estado.Length == 0);
        }
        #endregion

        #region Menu Adoção
        static void MenuAdocao()
        {
            Console.Clear();
            ControleAdocao adocao = new();
            string op;

            do
            {

                Console.WriteLine("\n|°°°°°°°°°°°°°° MENU CONTROLE DE ADOÇÃO °°°°°°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 1 : Cadastrar Adoção                         |");
                Console.WriteLine("|   opção 2 : Buscar Lista de Adoções                  |");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 0 : Sair                                     |");
                Console.WriteLine("|______________________________________________________|");
                Console.WriteLine("\nInforme a opção que deseja realizar");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }

            } while (op != "1" && op != "2" && op != "0");

            switch (op)
            {

                case "1":
                    adocao.CadastroAdocao();
                    new Controle_AdocaoService().Add(adocao);
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case "2":
                    new Controle_AdocaoService().GetAll().ForEach(x => Console.WriteLine(x));
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case "0":
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region VerificaCPF
        public bool VerificaCPF()
        {
            do
            {
                Console.WriteLine("Informe o CPF: ");
                CPF = new TratamentoDado().TratarDado(Console.ReadLine());
                if (CPF == "0")
                    return false;
                if (!ValidaCPF(CPF))
                {
                    Console.WriteLine("Informe um CPF válido!");
                }
                else
                {
                    bool verifica = new AdotanteService().VerifCPF(CPF);
                    if (!verifica)
                    {
                        Console.WriteLine("CPF não encontrado!");
                        CPF = "";
                    }

                }
            } while (!ValidaCPF(CPF) || CPF == "");
            return true;
        }
        #endregion

        #region Método Para Validar o CPF 
        private static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[10] != 0)
                    return false;
            }

            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
        #endregion
    }
}

