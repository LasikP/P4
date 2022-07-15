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
    /// Logika interakcji dla klasy BorrowWindow.xaml
    /// </summary>
    public partial class BorrowWindow : Window
    {
        public MainWindow Mw { get; set; }
        public Ksiazka Book { get; set; }

        public BorrowWindow(Ksiazka book, MainWindow mw)
        {
            InitializeComponent();
            Book = book;
            Mw = mw;

            clientsCmb.ItemsSource = Mw.db.Clients.ToList();
            clientsCmb.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Klient c = clientsCmb.SelectedItem as Klient;

            if (c == null)
            {
                MessageBox.Show("Wybierz kilenta.");
            }
            else
            {
                Wpozyczenie b = new Wpozyczenie(Book.Id,c.Id);
                Mw.db.Borrows.Add(b);
                Mw.db.SaveChanges();
                Mw.Load();

                this.Close();
                Mw.IsEnabled = true;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Mw.IsEnabled = true;
        }
    }
}
