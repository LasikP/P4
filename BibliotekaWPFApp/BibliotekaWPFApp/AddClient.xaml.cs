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
using System.Windows.Shapes;

namespace BibliotekaWPFApp
{
    /// <summary>
    /// Logika interakcji dla klasy AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public MainWindow Mw { get; set; }
        public AddClient(MainWindow mw)
        {
            InitializeComponent();

            this.Mw = mw;
        }

        private void zapiszBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTxt.Text) || string.IsNullOrEmpty(surnameTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                Klient c = new Klient(nameTxt.Text, surnameTxt.Text);

                Mw.db.Clients.Add(c);
                Mw.db.SaveChanges();

                Mw.Load();
                Mw.IsEnabled = true;

                this.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Mw.IsEnabled = true;
        }
    }
}
