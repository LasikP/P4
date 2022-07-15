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
    /// Logika interakcji dla klasy AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public MainWindow Mw { get; set; }

        public AddBook(MainWindow mw)
        {
            InitializeComponent();

            Mw = mw;

            categoryCmb.ItemsSource = Mw.db.Categories.ToList();
            categoryCmb.SelectedIndex = 0;
        }

        private void zapiszBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(titleTxt1.Text) || string.IsNullOrEmpty(authorTxt.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                
                Kategoria c = (Kategoria)categoryCmb.SelectedItem;

                Ksiazka b = new Ksiazka(titleTxt1.Text, authorTxt.Text,c.Id);

                Mw.db.Books.Add(b);
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
