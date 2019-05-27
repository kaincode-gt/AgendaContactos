using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agenda
{
    public static class ConmutadorDePestaña
    {
        public static MainWindow conmutadorPestaña;
        public static void Cambiar(UserControl nuevaPagina)
        {
            conmutadorPestaña.CambiarPestaña(nuevaPagina);
        }
    }
}
