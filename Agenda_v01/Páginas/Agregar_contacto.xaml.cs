using Agenda;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDataBaseSQLite.Clases;

namespace Agenda_v01.Páginas
{
    /// <summary>
    /// Lógica de interacción para Pagina_agregar_contacto.xaml
    /// </summary>
    public partial class Agregar_Contacto : UserControl
    {
        public Agregar_Contacto()
        {
            InitializeComponent();
        }

        private void BotonListado_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Lista_Contactos());
        }

        private void BotonAlta_Click(object sender, RoutedEventArgs e)
        {
           // ConmutadorDePestaña.Cambiar(new Agregar_Contacto());
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Buscar_Contacto());
        }

        private void BotonDetalle_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Detalle());
        }
        
        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Contacto contacto = new Contacto()
            {
                Nombre = nombreTextBox.Text,
                Email = emailTextBox.Text,
                Telefono = telefonoTextBox.Text
            };

            using (SQLiteConnection conexion = new SQLiteConnection(App.databasePath))
            {
                conexion.CreateTable<Contacto>();
                conexion.Insert(contacto);
                textGuardadoInfo.Text = "Contacto guardado";

                resetearFormulario();
            }
        }
        private void resetearFormulario()
        {
            nombreTextBox.Text = emailTextBox.Text = telefonoTextBox.Text = string.Empty;
        }
    }
}
