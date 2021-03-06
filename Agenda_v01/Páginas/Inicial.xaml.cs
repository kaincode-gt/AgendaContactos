﻿using Agenda;
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

namespace Agenda_v01.Páginas
{
    /// <summary>
    /// Lógica de interacción para Inicial.xaml
    /// </summary>
    public partial class Inicial : UserControl
    {
        public Inicial()
        {
            InitializeComponent();
        }

        private void BotonAlta_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Agregar_Contacto());
        }

        private void BotonBuscar_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Buscar_Contacto());
        }

        private void BotonListado_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Lista_Contactos());
        }

        private void BotonDetalle_Click(object sender, RoutedEventArgs e)
        {
            ConmutadorDePestaña.Cambiar(new Detalle());
        }
    }
}
