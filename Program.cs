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
            Console.WriteLine("-------------------- CALCULO DE CONTAS DO MÊS --------------------\n\n");
            float salario = 0; // Variável para armazenar o salário convertido
            bool entradaValida = false;

            while (!entradaValida) // Repete até que a entrada seja válida
            {
                Console.Write("Informe seu salário líquido: ");
                string salario1 = Console.ReadLine();

                if (float.TryParse(salario1, out salario))
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

            contasFixas contas = new contasFixas();

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

            Console.WriteLine("\n____________________________\n\n");
            Console.Write("Possui outra divida? (S/N): ");
            string escolha = Console.ReadLine().ToUpper();

            if (escolha == "S")
            {
                Console.WriteLine("\n\n__________________________ DIVIDAS ADICIONAIS _________________________");
            }
            while (escolha == "S"){

                Console.Write("\nDivida adicional: ");
                string contaA = Console.ReadLine();

                float contaA1 = float.Parse(contaA);
                contas.add += contaA1;

                Console.Write("\nPossui mais alguma conta? (S/N): ");
                escolha = Console.ReadLine().ToUpper();

                if (escolha == "N")
                {
                    break;
                }
            }
            Console.WriteLine("\n\n_____________________ VALORES A PAGAR ______________________\n");

            if (contas.add > 0) {
                Console.WriteLine("- VALORES ADICIONAIS:".PadRight(30) +$" R$ {contas.add:F2}");
            }

            float fixas = contas.CF();
            Console.WriteLine("- CONTAS FIXAS:".PadRight(30) + $" R$ {fixas:F2}");

            float guardar = contas.Guardar(salario);
            Console.WriteLine("- 10% P/ FUNDO DE EMERGENCIA:".PadRight(30) +$" R$ {guardar:F2}");

            Console.WriteLine("\n_________________________________________");
            float totalAPagar = contas.Somar();
            Console.WriteLine("- TOTAL A PAGAR:".PadRight(30) + $" R$ {totalAPagar + guardar:F2}");


            Console.WriteLine("\n\n_____________________ VALORES A RECEBER ______________________\n");

            float liquidoAReceber = (salario - totalAPagar) - guardar;
            Console.WriteLine("- SEM FUNDO DE EMERGENCIA:".PadRight(30) + $" R$ {salario - totalAPagar:F2}");
            Console.WriteLine("\n_________________________________________");
            Console.WriteLine("- LIQUIDO A RECEBER:".PadRight(30) +$" R$ {liquidoAReceber:F2}\n");
            
            Console.WriteLine("______________________________________________________________________\n\n");
            Console.WriteLine("\nPressione qualquer tecla...");
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