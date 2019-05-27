using SQLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfDataBaseSQLite.Clases;

namespace Agenda
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Contactos.db";
        static string folderPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);

        public static List<Contacto> ObtenerContactos()
        {
            List<Contacto> contactos;
            using (SQLiteConnection conexion = new SQLiteConnection(databasePath))
            {
                contactos = conexion.Table<Contacto>().ToList();
            }
            return contactos;
        }
    }
}
