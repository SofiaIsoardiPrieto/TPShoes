using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPShoes.Windows.Helpers
{
    public static class FormHelper
    {
        public static int CalcularPaginas(int registro, int registrosPorPagina)
        {
            if (registro < registrosPorPagina)
            {
                return 1;
            }
            else if (registro % registrosPorPagina == 0)
            {
                return registro / registrosPorPagina;
            }
            else
            {
                return registro / registrosPorPagina + 1;
            }
        }
    }
}
