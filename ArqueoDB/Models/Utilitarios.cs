using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Utilitarios
    {
        public static void paginacao(int nrPaginas, int paginaActual, out int posInicial, out int posFinal)
        {
            int paginas = 5;
            int count = nrPaginas;
            int current = paginaActual;
            int pagi = 1, pagf = 5;


            if (count <= paginas)
            {
                paginas = count;
                pagi = 1;
                pagf = count;
            }
            else
            {
                paginas--;

                if (current + 2 <= count)
                {
                    pagf = current + 2;
                    paginas -= 2;
                }
                else if (current + 1 <= count)
                {
                    pagf = current + 1;
                    paginas--;
                }
                else
                {
                    pagf = count;
                }

                while (paginas > 0)
                {
                    if (current - paginas >= 1)
                    {
                        pagi = current - paginas;
                        break;
                    }
                    else
                    {
                        pagf++;
                        paginas--;
                    }
                }
            }
            posInicial = pagi;
            posFinal = pagf;
        }
    }
}