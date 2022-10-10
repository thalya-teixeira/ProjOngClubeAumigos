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

                Console.WriteLine("\n|°°°°°°°°°°°°°°°°°°°° MENU ADOTANTE °°°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 1 : Cadastrar Adotante                       |");
                Console.WriteLine("|   opção 2 : Buscar Lista de Adotantes                |");
                Console.WriteLine("|   opção 3 : Editar Dados Adotantes                   |");
                Console.WriteLine("|   opção 4 : Deletar Algum Adotante Específico        |");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 0 : Sair                                     |");
                Console.WriteLine("|______________________________________________________|");
                Console.WriteLine("\nInforme a opção que deseja realizar");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "4" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }

            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "0");

            switch (op)
            {

                case "1":
                    adotante.CadastrarAdotante();
                    new AdotanteService().Add(adotante);
                    Menu();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("\n\t >>> Lista de Adotantes Cadastrados <<<\n");
                    new AdotanteService().GetAll().ForEach(x => Console.WriteLine(x));
                    Console.WriteLine("Aperte ENTER para retornar ao menu");
                    Console.ReadKey();
                    Menu();
                    break;

                case "3":
                    adotante.UpdateAdotante();
                    new AdotanteService().GetAll().ForEach(x => Console.WriteLine(x));
                    Console.Clear();
                    Menu();
                    break;

                case "4":
                    adotante.DeleteAdotante();
                    new AdotanteService().GetAll().ForEach(x => Console.WriteLine(x));
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

                Console.WriteLine("\n|°°°°°°°°°°°°°°°°°°°°° MENU ANIMAL °°°°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 1 : Cadastrar Animal                         |");
                Console.WriteLine("|   opção 2 : Buscar Lista de Animal                   |");
                Console.WriteLine("|   opção 3 : Alterar Cadastro de Animal               |");
                Console.WriteLine("|   opção 4 : Deletar Cadastro de Animal               |");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 0 : Sair                                     |");
                Console.WriteLine("|______________________________________________________|");
                Console.WriteLine("\nInforme a opção que deseja realizar");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "4" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }

            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "0");

            switch (op)
            {

                case "1":
                    animal.CadastrarAnimal();
                    new AnimalService().Add(animal);
                    Menu();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("\n\t >>> Lista de Animais Cadastrados <<<\n");
                    new AnimalService().GetAll().ForEach(x => Console.WriteLine(x));
                    Console.WriteLine("Aperte ENTER para retornar ao menu");
                    Console.ReadKey();
                    Menu();
                    break;

                case "3":
                    animal.UpdateAnimal();
                    new AnimalService().GetAll().ForEach(x => Console.WriteLine(x));
                    Console.Clear();
                    Menu();
                    break;

                case "4":
                    animal.DeleteAnimal();
                    new AnimalService().GetAll().ForEach(x => Console.WriteLine(x));
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

                Console.WriteLine("\n|°°°°°°°°°°°°°°°° MENU CONTROLE DE ADOÇÃO °°°°°°°°°°°°°°|");
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
                    Console.Clear();
                    Console.WriteLine("\n\t >>> Lista de Adoções Cadastradas <<<\n");
                    new Controle_AdocaoService().GetAll().ForEach(x => Console.WriteLine(x));
                    Console.WriteLine("Aperte ENTER para retornar ao menu");
                    Console.ReadKey();
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

            Menu();
        }
    }
}
