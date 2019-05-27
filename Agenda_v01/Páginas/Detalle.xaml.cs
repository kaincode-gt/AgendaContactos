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
    /// Lógica de interacción para Detalle.xaml
    /// </summary>
    public partial class Detalle : UserControl
    {
        private Contacto contactoActual;

        public Detalle()
        {
            InitializeComponent();

            contactoActual = App.ObtenerContactos().First();
            CargarDatos(contactoActual);
        }

        public Detalle(Contacto c)
        {
            InitializeComponent();

            contactoActual = c;
            CargarDatos(contactoActual);
        }

        public void CargarDatos(Contacto c)
        {
            TextBoxNombre.Text = c.Nombre;
            TextBoxTelefono.Text = c.Telefono;
            TextBoxEmail.Text = c.Email;
        }

        private void BotonListado_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Lista_Contactos());
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
            //ConmutadorDePestaña.Cambiar(new Detalle());
        }

        private void BotonEditar_Click(object sender, RoutedEventArgs e)
        {
            TextBoxNombre.IsReadOnly = false;
            TextBoxTelefono.IsReadOnly = false;
            TextBoxEmail.IsReadOnly = false;

            //MessageBox.Show("Ahora puedes editar");
            BotonEditar.Visibility= Visibility.Hidden;
            BotonEliminar.Visibility = Visibility.Hidden;
            BotonGuardar.Visibility = Visibility.Visible;
        }

        private void BotonEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BotonRegPrevio_Click(object sender, RoutedEventArgs e)
        {
            //List<Contacto> contactos = App.ObtenerContactos();
            int index = Math.Max(contactoActual.Id - 1, 1);
         //   MessageBox.Show(contactoActual.Id-1+"");
            contactoActual = App.ObtenerContactos().Where(x => x.Id.Equals(index)).First();
            CargarDatos(contactoActual);
            // var contactoActual = contactos.Where(x => x.Telefono.Equals(TextBoxTelefono)).FirstOrDefault().Id;
            //MessageBox.Show(contactoActual.ToString());
        }

        private void BotonRegSiguiente_Click(object sender, RoutedEventArgs e)
        {
            int index = Math.Min(contactoActual.Id + 1, App.ObtenerContactos().ToList().Count);
           // MessageBox.Show(index+"");
            contactoActual = App.ObtenerContactos().Where(x => x.Id.Equals(index)).First();
            CargarDatos(contactoActual);
        }

        private void BotonGuardar_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(App.databasePath))
            {
                var contactoEditado = conexion.Table<Contacto>().Where(x => x.Id == contactoActual.Id).First();

                contactoEditado.Nombre= TextBoxNombre.Text;
                contactoEditado.Email = TextBoxEmail.Text;
                contactoEditado.Telefono = TextBoxTelefono.Text;

                conexion.RunInTransaction(() =>
                {
                    conexion.Update(contactoEditado);
                });
            }

            BotonEditar.Visibility = Visibility.Visible;
            BotonEliminar.Visibility = Visibility.Visible;
            BotonGuardar.Visibility = Visibility.Hidden;

            TextBoxNombre.IsReadOnly = true;
            TextBoxTelefono.IsReadOnly = true;
            TextBoxEmail.IsReadOnly = true;
        }
    }
}
