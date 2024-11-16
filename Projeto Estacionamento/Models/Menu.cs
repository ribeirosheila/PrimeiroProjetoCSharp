using System;
using System.Collections.Generic;

namespace Projeto_Estacionamento.Models
{
    public class Menu
    {
        public int SelectOptions()
        {
            Console.Clear();
            Console.WriteLine("Selecione uma das opções:");
            Console.WriteLine("1 - Cadastrar carro");
            Console.WriteLine("2 - Verificar carros");
            Console.WriteLine("3 - Realizar pagamento");
            Console.WriteLine("4 - Encerrar");

            return Convert.ToInt32(Console.ReadLine());
        }

        public int StarterPrice()
        {
            Console.WriteLine("Olá, seja bem-vindo!\nDigite o preço inicial:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public bool ReturnToMenu()
        {
            var answer = Convert.ToInt32(Console.ReadLine());
            return answer != 2;
        }

        // Método atualizado para calcular o pagamento
        public void CalculatePayment(List<string> listaDeCarros, List<int> listaDeHoras, List<string> listaDePagamentos, int precoInicial)
        {
            bool realizarOutroPagamento = true;

            while (realizarOutroPagamento)
            {
                Console.Clear();
                
                if (listaDeCarros.Count == 0)
                {
                    Console.WriteLine("Não há carros cadastrados para pagamento.");
                    return;
                }

                Console.WriteLine("Selecione o índice do carro para calcular o pagamento:");
                Console.WriteLine("Índice | Placa  | Horas | Pagamento Realizado?");

                // Exibe todas as placas, horas e status de pagamento cadastrados
                for (int i = 0; i < listaDeCarros.Count; i++)
                {
                    Console.WriteLine($"{i + 1}      | {listaDeCarros[i]} | {listaDeHoras[i]}    | {listaDePagamentos[i]}");
                }

                // Solicita ao usuário que selecione o índice
                Console.WriteLine("\nDigite o índice do carro:");
                var indiceSelecionado = Convert.ToInt32(Console.ReadLine());

                // Verifica se o índice é válido
                if (indiceSelecionado > 0 && indiceSelecionado <= listaDeCarros.Count)
                {
                    // Verifica se o pagamento já foi realizado
                    if (listaDePagamentos[indiceSelecionado - 1] == "Sim")
                    {
                        Console.WriteLine("Pagamento já realizado para este carro.\n");
                    }
                    else
                    {
                        // Calcula o preço total com base nas horas do carro selecionado
                        var horasCarro = listaDeHoras[indiceSelecionado - 1];
                        int priceTotal = precoInicial + (2 * horasCarro); // Preço base + R$2 por hora

                        // Exibe o valor total para o usuário
                        Console.WriteLine($"O preço total para o carro de placa {listaDeCarros[indiceSelecionado - 1]} é R${priceTotal}");
                        Console.WriteLine("Deseja realizar o pagamento?\n1- Sim\n2- Não");

                        var realizarPagamento = Convert.ToInt32(Console.ReadLine());
                        if (realizarPagamento == 1)
                        {
                            // Marca o pagamento como realizado
                            listaDePagamentos[indiceSelecionado - 1] = "Sim";
                            Console.WriteLine("Pagamento realizado com sucesso!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Índice inválido!");
                }

                // Pergunta ao usuário se deseja realizar outro pagamento
                Console.WriteLine("\nDeseja realizar outro pagamento?\n1- Sim\n2- Não. Voltar ao menu.");
                realizarOutroPagamento = Convert.ToInt32(Console.ReadLine()) == 1;
            }

            // Limpa o console ao retornar ao menu principal
            Console.Clear();
        }
    }
}
