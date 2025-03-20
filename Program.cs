using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Calculador_de_contas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string escolha;
            do
            {
                
                Console.WriteLine("-------------------- CALCULO DE CONTAS DO MÊS --------------------\n\n");
                float salario = 0; // Variável para armazenar o salário
                bool entradaValida = false;
                escolha = string.Empty;

                
                // Inserir salario

                while (!entradaValida) // Repete até que a entrada seja válida
                {
                    Console.Write("Informe seu salário líquido: ");
                    string entradaValor = Console.ReadLine();


                    if (entradaValor.Contains('.'))
                    {
                        Console.WriteLine("Entrada inválida! Use virgula ao invez de ponto.\n");
                        continue; // Volta para o início do loop
                    }


                    if ((float.TryParse(entradaValor, out salario) && salario > 0))
                    {
                        entradaValida = true; // Marca como válido para sair do loop
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("\n______________________________________________________________\n");
                Console.WriteLine("\n*ATENCAO* caso não tenha a divida, informar com valor zero (0). \n");
                Console.WriteLine("Pressione qualquer tecla...");
                Console.ReadKey();
                Console.WriteLine("\n\n_____________________ DIVIDAS FIXAS _____________________\n");
                Console.WriteLine("Preencha os campos com os repectivos valores de cada divida:\n");

                
                //Inserir dados das contas Fixas

                contasFixas contas = new contasFixas();

                // possivel [ERRO] quando nao inserido nenhum valor
                Console.Write("Agua: ");
                contas.agua = float.Parse(Console.ReadLine());

                Console.Write("Luz: ");
                contas.luz = float.Parse(Console.ReadLine());

                Console.Write("internet (WI-FI): ");
                contas.net = float.Parse(Console.ReadLine());

                Console.Write("Cartao de credito: ");
                contas.cartao = float.Parse(Console.ReadLine());

                Console.Write("Fatura do celular: ");
                contas.celular = float.Parse(Console.ReadLine());

                
                //Dividas adicionais

                Console.WriteLine("\n____________________________\n\n");
                Console.Write("Possui outra divida? (S/N): ");
                escolha = Console.ReadLine().ToUpper();

                while (escolha == "S")
                {
                    Console.WriteLine("\n\n__________________________ DIVIDAS ADICIONAIS _________________________\n");

                    Console.Write("\nDivida adicional: ");
                    contas.add = float.Parse(Console.ReadLine());

                    Console.Write("\nPossui mais alguma conta? (S/N): ");
                    escolha = Console.ReadLine().ToUpper();

                    if (escolha == "N")
                    {
                        break;
                    }
                    escolha = string.Empty;
                }

                
                // Calculo de gastos 

                Console.WriteLine("\n\n_____________________ VALORES A PAGAR ______________________\n");

                if (contas.add > 0)
                {
                    Console.WriteLine("- VALORES ADICIONAIS:".PadRight(30) + $" R$ {contas.add:F2}");
                }

                Console.WriteLine("- CONTAS FIXAS:".PadRight(30) + $" R$ {contas.ContasFixas():F2}");

                Console.WriteLine("- 10% P/ FUNDO DE EMERGENCIA:".PadRight(30) + $" R$ {contas.Guardar(salario):F2}");

                Console.WriteLine("\n_________________________________________");
                float totalAPagar = contas.ContasADD();
                Console.WriteLine("- TOTAL A PAGAR:".PadRight(30) + $" R$ {totalAPagar + contas.Guardar(salario):F2}");

                
                // Valor a receber 

                Console.WriteLine("\n\n_____________________ VALORES A RECEBER ______________________\n");


                Console.WriteLine("- SEM FUNDO DE EMERGENCIA:".PadRight(30) + $" R$ {contas.SalarioSemEmergencia(salario, totalAPagar):F2}");
                Console.WriteLine("\n_________________________________________");
                Console.WriteLine("- LIQUIDO A RECEBER:".PadRight(30) + $" R$ {contas.SalarioLiquido(salario, totalAPagar, contas.Guardar(salario)):F2}\n");

                Console.WriteLine("______________________________________________________________________\nPrecione qualquer tecla...\n");
                Console.ReadKey();
                Console.Write("Deseja realizar outro calculo? (S/N): ");
                escolha = Console.ReadLine().ToUpper();
                Console.WriteLine("\n");
            } while (escolha == "S");
            
            Console.WriteLine("\n______________________________________________________________________");
            Console.ReadKey();

        }
    }
}

/*
    - Projeto: calculador de contas
    - Finalidade: Calcular o valor de todas suas contas baseando no seu salario liquido
    - Previa: CMD -> 
                    - salario 
                    - contas preenchidas uma a uma
              saida ->
                    - Soma de toda as contas, salario disponivel, quantia para reserva de emergencia
 */