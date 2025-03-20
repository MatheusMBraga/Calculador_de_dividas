using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculador_de_contas
{
    internal class contasFixas
    {

        public float agua, luz, net, cartao, celular, add = 0;
        
        // Calculo dos valores inseridos pelo usuario
        public float ContasFixas()
        {
            float somafixas = agua + luz + net + cartao + celular;
            return somafixas;
        }
        public float ContasADD()
        {
            float somaAdd = agua + luz + net + cartao + celular + add;
            return somaAdd;
        }


        // Resultado final das entradas dos usuarios
        public float Guardar(float ValorGuardar)
        {
            ValorGuardar = ValorGuardar * 0.1f;
            return ValorGuardar;
        }

        public float SalarioLiquido(float salario, float totalPagar, float guardar)
        {
            salario = (salario - totalPagar) - guardar;
            return salario;
        }

        public float SalarioSemEmergencia(float salario, float totalPagar)
        {
            salario = salario - totalPagar;
            return salario;
        }
    }
}
 