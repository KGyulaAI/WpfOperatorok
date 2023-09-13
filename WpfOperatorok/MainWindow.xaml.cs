using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfOperatorok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Operatorok> operatorokLista = new List<Operatorok>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFajlKivalasztas_Click(object sender, RoutedEventArgs e)
        {
            var fajl = new OpenFileDialog();
            if (fajl.ShowDialog() == true)
            {
                StreamReader streamReader = new StreamReader(fajl.FileName);
                while (!streamReader.EndOfStream)
                {
                    string sor = streamReader.ReadLine();
                    string[] mezok = sor.Split(" ");
                    Operatorok kifejezes = new Operatorok(Convert.ToInt32(mezok[0]), mezok[1], Convert.ToInt32(mezok[2]));
                    operatorokLista.Add(kifejezes);
                }
                streamReader.Close();
            }
            else
            {
                MessageBox.Show("Nem választott file-t!");
            }

            lbFeladatok.Items.Add($"2. feladat: Kifejezések száma: {operatorokLista.Count}");

            int maradekosOsztasokSzama = 0;
            foreach (Operatorok elem in operatorokLista)
            {
                if (elem.SzovegesOperator == "mod")
                {
                    maradekosOsztasokSzama++;
                }
            }
            lbFeladatok.Items.Add($"3. feladat: Kifejezések maradékos osztással: {maradekosOsztasokSzama}");

            bool vanBenne = false;
            foreach (Operatorok elem in operatorokLista)
            {
                if (elem.ElsoOperandus % 10 == 0 && elem.MasodikOperandus % 10 == 0)
                {
                    vanBenne = true;
                    break;
                }
            }
            if (vanBenne)
            {
                lbFeladatok.Items.Add("4. feladat: Van ilyen kifejezés!");
            }
            else
            {
                lbFeladatok.Items.Add("4. feladat: Nincs ilyen kifejezés!");
            }

            lbFeladatok.Items.Add("Kérek egy kifejezést:");

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string[] mezok = txtFeladat7.Text.Split(' ');
            lbFeladatok.Items.Add(Operatorok.Szamitas(Convert.ToInt32(mezok[0]), mezok[1], Convert.ToInt32(mezok[2])));
        }

        private void btnFajlLetrehozas_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
