using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Boyaca.UI.BaseDatos
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Insertar
            BoyacaDataContext contexto = new BoyacaDataContext("isostore:/boyaca.mdb");

            Items nuevo = new Items();
            nuevo.Nombre = txtDescripcion.Text;
            nuevo.Precio = Convert.ToInt32(this.txtPrecio.Text);

            contexto.Items.InsertOnSubmit(nuevo);
            contexto.SubmitChanges();

            //Consultar todos

            List<Items> todos = (from i in contexto.Items
                                select i).ToList();

            //Consultar uno y actualizar
            Items uno = (from i in contexto.Items
                         where i.Id == 1
                         select i).SingleOrDefault();

            uno.Nombre = this.txtDescripcion.Text;
            uno.Precio = Convert.ToInt32(this.txtPrecio.Text);

            contexto.SubmitChanges();

            //Borrar
            Items otro = (from i in contexto.Items
                         where i.Id == 1
                         select i).SingleOrDefault();

            contexto.Items.DeleteOnSubmit(otro);
            contexto.SubmitChanges();





        }
    }
}