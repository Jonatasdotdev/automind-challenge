using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroUsuariosApp
{
    // Classe que representa um usuário
    class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }

        public void ExibirInfo()
        {
            Console.WriteLine($"Nome: {Nome}, Email: {Email}, Idade: {Idade}");
        }
    }

    class Program
    {
        // Lista para armazenar os usuários em memória
        static List<Usuario> usuarios = new List<Usuario>();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Cadastrar usuário");
                Console.WriteLine("2. Listar usuários");
                Console.WriteLine("3. Buscar usuário por nome");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarUsuario();
                        break;
                    case "2":
                        ListarUsuarios();
                        break;
                    case "3":
                        BuscarUsuario();
                        break;
                    case "4":
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

            Console.WriteLine("Programa encerrado.");
        }

        // Método para cadastrar um novo usuário
        static void CadastrarUsuario()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine();

            Console.Write("Digite a idade: ");
            if (int.TryParse(Console.ReadLine(), out int idade))
            {
                Usuario novoUsuario = new Usuario
                {
                    Nome = nome,
                    Email = email,
                    Idade = idade
                };

                usuarios.Add(novoUsuario);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Idade inválida. Usuário não cadastrado.");
            }
        }

        // Método para listar todos os usuários
        static void ListarUsuarios()
        {
            Console.WriteLine("\n--- Lista de Usuários ---");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            foreach (var usuario in usuarios)
            {
                usuario.ExibirInfo();
            }
        }

        // Método para buscar um usuário pelo nome
        static void BuscarUsuario()
        {
            Console.Write("Digite o nome do usuário que deseja buscar: ");
            string nomeBusca = Console.ReadLine();

            var encontrados = usuarios.Where(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();

            if (encontrados.Count == 0)
            {
                Console.WriteLine("Usuário não encontrado.");
            }
            else
            {
                Console.WriteLine("\nUsuário(s) encontrado(s):");
                foreach (var usuario in encontrados)
                {
                    usuario.ExibirInfo();
                }
            }
        }
    }
}
