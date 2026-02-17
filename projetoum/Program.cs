// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Threading;

string mensagemDeBoasVindas = "Bem-vindo ao projeto Screen Sound!";
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirMenu()
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine("1 - Registrar uma Banda");
    Console.WriteLine("2 - Mostrar todas as bandas");
    Console.WriteLine("3 - Avaliar uma banda");
    Console.WriteLine("4 - Exibir média de uma banda");
    Console.WriteLine("0 - Sair");
    Console.Write("\nDigite sua opção: ");
}

void RegistrarBanda()
{
    Console.Clear();
    Console.Write("Digite o nome da banda: ");
    string nome = Console.ReadLine()!;

    if (!bandasRegistradas.ContainsKey(nome))
    {
        bandasRegistradas.Add(nome, new List<int>());
        Console.WriteLine($"Banda {nome} registrada com sucesso!");
    }
    else
    {
        Console.WriteLine("Essa banda já está cadastrada.");
    }

    Thread.Sleep(2000);
}

void MostrarBandas()
{
    Console.Clear();
    Console.WriteLine("=== Bandas Registradas ===\n");

    if (bandasRegistradas.Count == 0)
    {
        Console.WriteLine("Nenhuma banda cadastrada.");
    }
    else
    {
        foreach (var banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"- {banda}");
        }
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar...");
    Console.ReadKey();
}

void AvaliarBanda()
{
    Console.Clear();
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nome = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nome))
    {
        Console.Write("Digite a nota (0 a 10): ");
        if (int.TryParse(Console.ReadLine(), out int nota) && nota >= 0 && nota <= 10)
        {
            bandasRegistradas[nome].Add(nota);
            Console.WriteLine("Nota registrada com sucesso!");
        }
        else
        {
            Console.WriteLine("Nota inválida.");
        }
    }
    else
    {
        Console.WriteLine("Banda não encontrada, aperte qualquer tecla para voltar.");
    }

    Thread.Sleep(2000);
}

void ExibirMedia()
{
    Console.Clear();
    Console.Write("Digite o nome da banda: ");
    string nome = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nome))
    {
        List<int> notas = bandasRegistradas[nome];

        if (notas.Count > 0)
        {
            double media = 0;
            foreach (int nota in notas)
            {
                media += nota;
            }

            media /= notas.Count;

            Console.WriteLine($"A média da banda {nome} é: {media:F2}");
        }
        else
        {
            Console.WriteLine("Essa banda ainda não possui avaliações.");
        }
    }
    else
    {
        Console.WriteLine("Banda não encontrada, aperte qualquer tecla para voltar.");
    }

    Thread.Sleep(3000);
}

bool executar = true;

while (executar)
{
    Console.Clear();
    ExibirLogo();
    ExibirMenu();

    if (int.TryParse(Console.ReadLine(), out int opcao))
    {
        switch (opcao)
        {
            case 1:
                RegistrarBanda();
                break;

            case 2:
                MostrarBandas();
                break;

            case 3:
                AvaliarBanda();
                break;

            case 4:
                ExibirMedia();
                break;

            case 0:
                executar = false;
                Console.WriteLine("Encerrando...");
                Thread.Sleep(1500);
                break;

            default:
                Console.WriteLine("Opção inválida.");
                Thread.Sleep(2000);
                break;
        }
    }
    else
    {
        Console.WriteLine("Digite apenas números.");
        Thread.Sleep(2000);
    }
}