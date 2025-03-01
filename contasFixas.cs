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

        public float agua;
        public float luz;
        public float net;
        public float cartao;
        public float celular;
        public float add = 0; //adicional
    

        public float CF()
        {
            float soma1 = agua + luz + net + cartao + celular;
            return soma1;
        }
        public float Somar()
        {
            float soma = agua + luz + net + cartao + celular + add;
            return soma;
        }

        public float Guardar(float n1)
        {
            float n2 = n1 * 0.1f;
            return n2;
        }

    }
}
 