using System;
using ProjOngClubeAumigos.Model;
using ProjOngClubeAumigos.Service;

namespace ProjOngClubeAumigos
{
    internal class Program
    {
        #region Menu Principal
        static void Menu()
        {
            Console.Clear();
            string op;

            do
            {

                Console.WriteLine("\n|°°°°°°°°°° BEM VINDO A ONG CLUBE DOS AUMIGOS °°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 1 : Menu Adotante                            |");
                Console.WriteLine("|   opção 2 : Menu Animal                              |");
                Console.WriteLine("|   opção 3 : Menu Adoção                              |");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 0 : Sair                                     |");
                Console.WriteLine("|______________________________________________________|");
                Console.WriteLine("\nInforme a opção que deseja realizar");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }

            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6" && op != "0");

            switch (op)
            {

                case "1":
                    MenuAdotante();
                    Menu();
                    break;

                case "2":
                    MenuAnimal();
                    Console.Clear();
                    Menu();
                    break;

                case "3":
                    MenuAdocao();
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

        #region Menu Adotante
        static void MenuAdotante()
        {
            Console.Clear();
            Adotante adotante = new();
            string op;

            do
            {

                Console.WriteLine("\n|°°°°°°°°°°°°°°°°°°° MENU ADOTANTE °°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 1 : Cadastrar Adotante                       |");
                Console.WriteLine("|   opção 2 : Buscar Adotante Específico               |");
                Console.WriteLine("|   opção 3 : Buscar Lista de Adotantes                |");
                Console.WriteLine("|   opção 4 : Editar Dados Adotantes                   |");
                Console.WriteLine("|   opção 5 : Deletar Algum Adotante Específico        |");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 0 : Sair                                     |");
                Console.WriteLine("|______________________________________________________|");
                Console.WriteLine("\nInforme a opção que deseja realizar");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }

            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" &&  op != "0");

            switch (op)
            {

                case "1":
                    adotante.CadastrarAdotante();
                    new AdotanteService().Add(adotante);
                    Menu();
                    break;

                case "2":
                    new AdotanteService().GetAllCPF().ForEach(x => Console.WriteLine(x.CPF));
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case "3":
                    new AdotanteService().GetAll().ForEach(x => Console.WriteLine(x));
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case "4":
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

        #region Menu Animal
        static void MenuAnimal()
        {
            Console.Clear();
            Animal animal = new();
            string op;

            do
            {

                Console.WriteLine("\n|°°°°°°°°°°°°°°°°°°° MENU ANIMAL °°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 1 : Cadastrar Animal                         |");
                Console.WriteLine("|   opção 2 : Buscar Animal Específico                 |");
                Console.WriteLine("|   opção 3 : Buscar Lista de Animal                   |");
                Console.WriteLine("|   opção 4 : Editar Dados Animal                      |");
                Console.WriteLine("|   opção 5 : Deletar Algum Animal Específico          |");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 0 : Sair                                     |");
                Console.WriteLine("|______________________________________________________|");
                Console.WriteLine("\nInforme a opção que deseja realizar");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }

            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "0");

            switch (op)
            {

                case "1":
                    animal.CadastrarAnimal();
                    new AnimalService().Add(animal);
                    Menu();
                    break;

                case "2":
                    new AnimalService().GetAllNum_Chip().ForEach(x => Console.WriteLine(x.Num_Chip));
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case "3":
                    new AnimalService().GetAll().ForEach(x => Console.WriteLine(x));
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case "4":
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

        static void Main(string[] args)
        {
            //Console.WriteLine("Start");

            //Adotante adotante = new Adotante()
            //{
            //    CPF = "35671013828",
            //    Nome = "Thalya",
            //    Sexo = "Fem",
            //    DataNasc = DateTime.Parse("25/10/97"),
            //    Telefone = "16981000500",
            //    Logradouro = "Rua Humaita",
            //    Numero = "430",
            //    Complemento = "b",
            //    Bairro = "Artico",
            //    Cidade = "Araraquara",
            //    Estado = "SP"
            //};

            //new AdotanteService().Add(adotante);
            //new AdotanteService().GetAll().ForEach(x => Console.WriteLine(x));

            //Console.WriteLine("Oba!");
            Menu();
        }
    }
}
