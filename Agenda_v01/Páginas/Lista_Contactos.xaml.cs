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
    /// Lógica de interacción para Lista_Contactos.xaml
    /// </summary>
    public partial class Lista_Contactos : UserControl
    {
        public List<string> Nombres = new List<string> { "Eva", "Jon", "Pablo", "Luisa" };
        public List<Contacto> contactos = new List<Contacto>();
        private int referenciaCadenaBusqueda = 99;

        public Lista_Contactos()
        {
            InitializeComponent();
            contactos = ObtenerNombresDB();
            ListBoxContactos.ItemsSource = contactos;
        }


        private List<Contacto> ObtenerNombresDB()
        {
            List<Contacto> contactos;
            using (SQLiteConnection conexion = new SQLiteConnection(App.databasePath))
            {
                conexion.CreateTable<Contacto>();
                contactos = conexion.Table<Contacto>().ToList();
            }
            return contactos;
        }

        private List<Contacto> ObtenerNombres()
        {
            return new List<Contacto>()
            {
                new Contacto () { Nombre="Eva", Telefono="6595413", Email="eva23@hotmail.com"},
                new Contacto () { Nombre="Luis", Telefono="65584564", Email="lusito@hotmail.com"},
                new Contacto () { Nombre="Pedro", Telefono="698751415", Email="pedro@yahoo.com"}
            };
        }

        private void BotonListado_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Nombres[2]);
            
            //ConmutadorDePestaña.Cambiar(new Lista_Contactos());
        }

        private void BotonAlta_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Agregar_Contacto());
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Buscar_Contacto());
        }

        private void BotonDetalle_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Detalle());
        }

        private void TextoBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            string cadenaBuscada = textoBusqueda.Text.ToLower();
            //Si se ha borrado algún caracter, vuelvo a solicitar la lista entera de contactos.
            if (cadenaBuscada.Length <= referenciaCadenaBusqueda)
            {
                contactos = ObtenerNombresDB();
                referenciaCadenaBusqueda = cadenaBuscada.Length;
                if (cadenaBuscada.Length == 0)
                {
                    referenciaCadenaBusqueda = 99;
                }
            }

            var _contactos = contactos.Where(x => x.Nombre.ToLower().Contains(cadenaBuscada)
            || x.Email.ToLower().Contains(cadenaBuscada) || x.Telefono.Contains(cadenaBuscada)).ToList();
            contactos = _contactos;
            ListBoxContactos.ItemsSource = contactos;
        }

        private void ListBoxContactos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var contacto = (Contacto)ListBoxContactos.SelectedItem;
          //  MessageBox.Show(contacto.Nombre);
            ConmutadorDePestaña.Cambiar(new Detalle(contacto));
        }
    }
}
