using System;
using System.Collections.Generic;
using Projeto_Estacionamento.Models; // Certifique-se de que você está importando o namespace correto

// Variável para controlar a exibição do menu principal
var exibirMenu = true;

// Lista para armazenar as placas dos carros
var listaDeCarros = new List<string>();
var listaDeHoras = new List<int>();
var listaDePagamentos = new List<string>();

// Variáveis auxiliares
bool novaTentativa;

// Instância da classe Menu para interagir com as opções do usuário
Menu menu = new Menu();

// Obtém o preço inicial do estacionamento
var precoInicial = menu.StarterPrice();
Console.Clear();

// Loop principal que mantém o menu ativo enquanto 'exibirMenu' for verdadeiro
while (exibirMenu)
{
    // Exibe o menu e captura a opção selecionada pelo usuário
    var opcao = menu.SelectOptions();
    Console.Clear();

    // Inicializa a variável 'novaTentativa' para controle dos loops internos
    novaTentativa = true;

    // Estrutura de controle 'switch' para tratar cada opção selecionada no menu
    switch ((OptionList.MenuOptions)opcao)
    {
        case OptionList.MenuOptions.NewCar:
            // Adiciona um novo carro à lista de placas
            while (novaTentativa)
            {
                Console.WriteLine("Digite os 6 dígitos da placa do carro:");
                var placaDoCarro = Console.ReadLine() ?? ""; // Captura a placa digitada pelo usuário

                // Verifica se a placa tem exatamente 6 caracteres
                if (placaDoCarro.Length == 6)
                {
                    listaDeCarros.Add(placaDoCarro); // Adiciona a placa à lista
                    Console.WriteLine("Digite a quantidade de horas em que ficará estacionado");
                    var horasEstacionado = Convert.ToInt32(Console.ReadLine());
                    listaDeHoras.Add(horasEstacionado);
                    listaDePagamentos.Add("Não");
                    Console.WriteLine("Placa adicionada\n");
                    Console.WriteLine("Adicionar outro carro?\n1-Sim\n2-Não. Voltar ao menu");
                }
                else
                {
                    // Exibe mensagem de erro caso a placa seja inválida
                    Console.WriteLine("Placa inválida\n");
                    Console.WriteLine("Deseja tentar novamente?\n1-Sim\n2-Não. Voltar ao menu");
                }

                // Pergunta ao usuário se deseja adicionar outra placa ou retornar ao menu principal
                novaTentativa = menu.ReturnToMenu();
                Console.Clear();
            }
            break;

        case OptionList.MenuOptions.VerifyCar:
            // Verifica as placas adicionadas e permite removê-las
            while (novaTentativa)
            {
                Console.Clear();

                // Verifica se há placas cadastradas na lista
                if (listaDeCarros.Count != 0)
                {
                    Console.WriteLine("Índice | Placa  | Horas");
                    
                    // Usando um loop 'for' para percorrer ambas as listas
                    for (int i = 0; i < listaDeCarros.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}      | {listaDeCarros[i]} | {listaDeHoras[i]}");
                    }

                    Console.WriteLine("\nSelecione uma das opções:\n1-Remover Placa\n2-Voltar ao menu");
                    novaTentativa = menu.ReturnToMenu(); // Pergunta ao usuário se deseja remover uma placa

                    if (novaTentativa)
                    {
                        // Solicita o índice da placa para remoção
                        Console.WriteLine("\nDigite o índice da placa:");
                        var indiceNaLista = Convert.ToInt32(Console.ReadLine());

                        // Verifica se o índice é válido
                        if (indiceNaLista > 0 && indiceNaLista <= listaDeCarros.Count)
                        {
                            listaDeCarros.RemoveAt(indiceNaLista - 1); // Remove a placa com base no índice
                            Console.WriteLine("Placa removida\n");
                        }
                        else
                        {
                            // Exibe mensagem de erro caso o índice seja inválido
                            Console.WriteLine("Índice inválido!\n");
                        }
                    }
                }
                else
                {
                    // Mensagem exibida quando não há placas cadastradas
                    Console.WriteLine("Não há placas cadastradas\n");
                    novaTentativa = false;
                }
            }
            break;

        case OptionList.MenuOptions.Payment:
            // Utiliza o novo método para calcular o pagamento
            menu.CalculatePayment(listaDeCarros, listaDeHoras, listaDePagamentos, precoInicial);
            break;

        case OptionList.MenuOptions.Finish:
            // Encerra o programa
            Console.WriteLine("Programa encerrado...");
            exibirMenu = false; // Define 'exibirMenu' como falso para sair do loop principal
            break;

        default:
            // Caso o usuário escolha uma opção inválida
            Console.WriteLine("Opção inválida.");
            break;
    }
}
