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

        public readonly static string SELECTCPF = $"SELECT CPF FROM Adotante WHERE CPF = ";

        public readonly static string UPDATE = "UPDATE Adotante SET CPF = @Cpf, Nome = @Nome, Sexo = @Sexo, DataNasc = @DataNasc, Telefone = @Telefone, Logradouro = @Logradouro," +
                                       " Numero =  @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado WHERE CPF = @CPF";

        public readonly static string DELETE = $"DELETE FROM Adotante WHERE CPF = ";

        public readonly static string SELECTONE = "SELECT CPF, Nome, Sexo, DataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado FROM Adotante WHERE CPF = @CPF";


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
            Console.Clear();
            Console.WriteLine("\n\t>>> CADASTRO DO ADOTANTE <<<");

            if (!CadastrarCPF()) return;

            if (!CadastrarNome()) return;

            if (!CadastrarSexo()) return;

            if (!CadastrarDataNasc()) return;

            if (!CadastrarTelefone()) return;

            if (!CadastrarLogradouro()) return;

            if (!CadastrarNumResidencia()) return;

            if (!CadastrarComplemento()) return;

            if (!CadastrarBairro()) return;

            if (!CadastrarCidade()) return;

            if (!CadastrarEstado()) return;
        }
        #endregion

        #region Menu Update
        public void UpdateAdotante()
        {
            Console.Clear();
            int op;
            Console.WriteLine("\n\t>>> ALTERAR CADASTRO DE ADOTANTE <<<\n");

            Console.WriteLine("\n\t >>> Lista de CPF cadastrados <<<\n");

            new AdotanteService().GetAllCPF().ForEach(x => Console.WriteLine(x.CPF));

            if (!VerificaCPF()) return;

            Console.WriteLine("[1] Alterar Nome\n[2] Alterar Data de Nascimento\n[3] Alterar Sexo\n[4] Alterar Telefone\n[5] Alterar Logradouro" +
                "\n[6] Alterar Número Residencial\n[7] Complemento\n[8] Alterar Bairro\n[9] Alterar Cidade\n[10] Alterar Estado\n[11] Alterar CEP\n[0] Sair");
            do
            {
                try { op = int.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("Dado inválido!!!"); op = -1; }

            } while (op < 0 && op > 11);

            Adotante adotante = new AdotanteService().GetAdotante(CPF);

            switch (op)
            {
                case 0:
                    return;

                case 1:
                    if (!CadastrarNome()) return;
                    adotante.Nome = this.Nome;
                    break;

                case 2:
                    if (!CadastrarDataNasc()) return;
                    adotante.DataNasc = this.DataNasc;
                    break;

                case 3:
                    if (!CadastrarSexo()) return;
                    adotante.Sexo = this.Sexo;
                    break;

                case 4:
                    if (!CadastrarTelefone()) return;
                    adotante.Telefone = this.Telefone;
                    break;

                case 5:
                    if (!CadastrarLogradouro()) return;
                    adotante.Logradouro = this.Logradouro;
                    break;

                case 6:
                    if (!CadastrarNumResidencia()) return;
                    adotante.Numero = this.Numero;
                    break;

                case 7:
                    if (!CadastrarComplemento()) return;
                    adotante.Complemento = this.Complemento;
                    break;

                case 8:
                    if (!CadastrarBairro()) return;
                    adotante.Bairro = this.Bairro;
                    break;

                case 9:
                    if (!CadastrarCidade()) return;
                    adotante.Cidade = this.Cidade;
                    break;

                case 10:
                    if (!CadastrarEstado()) return;
                    adotante.Estado = this.Estado;
                    break;

            }
            new AdotanteService().Update(adotante);
            Console.ReadKey();
        }
        #endregion

        #region  CPF
        private bool CadastrarCPF()
        {
            do
            {
                Console.Write("Informe seu CPF: ");
                CPF = new TratamentoDado().TratarDado(Console.ReadLine());
                if (CPF == "0")
                    return false;
                if (!ValidaCPF(CPF))
                {
                    Console.WriteLine("Informe um CPF Válido!");
                }
                else
                {

                    bool verifica = new AdotanteService().VerifCPF(CPF);
                    if (verifica)
                    {
                        Console.WriteLine("CPF Já cadastrado!!!");
                        CPF = "";
                    }
                }

            } while (!ValidaCPF(CPF) || CPF == "");
            return true;
        }
        #endregion

        #region Nome
        private bool CadastrarNome()
        {
            do
            {
                Console.Write("Informe seu nome [Max 50 caracteres]: ");
                Nome = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Nome == "0")
                    return false;
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Campo Obrigatório!");
                }
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Infome um nome menor que 50 caracteres!");
                }
            } while (Nome.Length > 50 || Nome.Length == 0);
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

        #region Data Nascimento
        private bool CadastrarDataNasc()
        {
            bool validacao;
            do
            {
                Console.Write("Informe data de nascimento: ");

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
            return true;
        }
        #endregion

        #region Telefone
        private bool CadastrarTelefone()
        {
            do
            {
                Console.Write("Informe seu telefone: ");
                Telefone = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Telefone.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Telefone.Length > 11)
                {
                    Console.WriteLine("Informe um telefone com menos de 11 caracteres!");
                }
            } while (Telefone.Length > 11 || Telefone.Length == 0);
            return true;
        }
        #endregion

        #region Logradouro
        private bool CadastrarLogradouro()
        {
            do
            {
                Console.Write("Informe seu logradouro: ");
                Logradouro = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Logradouro.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Logradouro.Length > 50)
                {
                    Console.WriteLine("Informe um logradouro com menos de 50 caracteres!");
                }
            } while (Logradouro.Length > 50 || Logradouro.Length == 0);
            return true;
        }
        #endregion

        #region Numero
        private bool CadastrarNumResidencia()
        {
            do
            {
                Console.Write("Digite seu número: ");
                Numero = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Numero.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Numero.Length > 10)
                {
                    Console.WriteLine("Informe um número com menos de 10 caracteres!");
                }
            } while (Numero.Length > 10 || Numero.Length == 0);
            return true;
        }
        #endregion

        #region Complemento
        private bool CadastrarComplemento()
        {
            do
            {
                Console.Write("Informe o complemento: ");
                Complemento = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Complemento.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Complemento.Length > 10)
                {
                    Console.WriteLine("Informe um complemento com menos de 10 caracteres!");
                }
            } while (Complemento.Length > 10 || Logradouro.Length == 0);
            return true;
        }
        #endregion

        #region Bairro
        private bool CadastrarBairro()
        {
            do
            {
                Console.Write("Digite seu bairro: ");
                Bairro = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Bairro.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Bairro.Length > 50)
                {
                    Console.WriteLine("Informe nome de bairro com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);
            return true;
        }
        #endregion

        #region Cidade
        private bool CadastrarCidade()
        {
            do
            {
                Console.Write("Informe sua cidade: ");
                Cidade = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Cidade.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Cidade.Length > 50)
                {
                    Console.WriteLine("Informe nome de cidade com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);
            return true;
        }
        #endregion

        #region Estado
        private bool CadastrarEstado()
        {
            do
            {
                Console.Write("Informe seu estado: ");
                Estado = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Estado.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Estado.Length > 2)
                {
                    Console.WriteLine("Informe apenas 2 caracter para estado!");
                }
            } while (Estado.Length > 2 || Estado.Length == 0);
            return true;
        }
        #endregion

        #region Deletar Adotante
        public void DeleteAdotante()
        {
            string op;
            Console.WriteLine("\n>>> DELETAR ADOTANTE <<<\n");

            Console.WriteLine("\n\t >>> Lista de CPF cadastrados <<<\n");

            new AdotanteService().GetAllCPF().ForEach(x => Console.WriteLine(x.CPF));

            if (!VerificaCPF()) return;

            Adotante adotante = new AdotanteService().GetAdotante(CPF);

            Console.WriteLine(adotante.ToString());

            while (true)
            {
                Console.Write("\nConfirma deletar adotante?\n[S] Sim - [N] Não:  ");
                op = Console.ReadLine().ToUpper();

                if (op == "0") return;
                else if (op != "S" && op != "N") Console.WriteLine("Dado inválido");
                else break;
            }

            if (op == "S") new AdotanteService().Delete(adotante);
            else return;
        }
        #endregion

        #region VerificaCPF
        public bool VerificaCPF()
        {
            do
            {
                Console.Write("\nInforme o CPF: ");
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

