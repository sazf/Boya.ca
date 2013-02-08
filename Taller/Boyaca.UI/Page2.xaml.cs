using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Boyaca.UI
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
            this.Loaded += Page2_Loaded;
        }

        void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("titulo"))
            {
                this.txtTitulo.Text = NavigationContext.QueryString["titulo"];
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PhoneCallTask lanzador = new PhoneCallTask();
            lanzador.DisplayName = "Sorey";
            lanzador.PhoneNumber = "555-0101";
            lanzador.Show();

            SaveContactTask selector = new SaveContactTask();
            selector.FirstName = "Sorey";
            selector.MobilePhone = "555-01-01";

            selector.Completed += selector_Completed;
            selector.Show();
        }

        void selector_Completed(object sender, SaveContactResult e)
        {
            if (e.TaskResult == TaskResult.OK)
                MessageBox.Show("Guardado");
        }
    }
}