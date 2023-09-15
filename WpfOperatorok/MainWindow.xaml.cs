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
                    string[] mezok = sor.Split();
                    Operatorok kifejezes = new Operatorok(Convert.ToInt32(mezok[0]), mezok[1], Convert.ToInt32(mezok[2]));
                    operatorokLista.Add(kifejezes);
                }
                streamReader.Close();

                //2. feladat
                lbFeladatok.Items.Add($"2. feladat: Kifejezések száma: {operatorokLista.Count}");
                //3. feladat
                lbFeladatok.Items.Add($"3. feladat: Kifejezések maradékos osztással: {operatorokLista.Count(x => x.SzovegesOperator == "mod")}");
                //4. feladat
                lbFeladatok.Items.Add($"4. feladat: {(operatorokLista.Any(x => x.ElsoOperandus % 10 == 0 && x.MasodikOperandus % 10 == 0) ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!")}");
                //5. feladat
                lbFeladatok.Items.Add("5. feladat: Statisztika");
                lbFeladatok.Items.Add($"\tmod -> {operatorokLista.Count(x => x.SzovegesOperator == "mod")} db");
                lbFeladatok.Items.Add($"\t/ -> {operatorokLista.Count(x => x.SzovegesOperator == "/")} db");
                lbFeladatok.Items.Add($"\tdiv -> {operatorokLista.Count(x => x.SzovegesOperator == "div")} db");
                lbFeladatok.Items.Add($"\t- -> {operatorokLista.Count(x => x.SzovegesOperator == "-")} db");
                lbFeladatok.Items.Add($"\t* -> {operatorokLista.Count(x => x.SzovegesOperator == "*")} db");
                lbFeladatok.Items.Add($"\t+ -> {operatorokLista.Count(x => x.SzovegesOperator == "+")} db");
                //7. feladat
                lbFeladatok.Items.Add("7. feladat: Kérek egy kifejezést (pl.: 1 + 1):");
            }
            else
            {
                MessageBox.Show("Nem választott file-t!");
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string[] mezok = txtFeladat7.Text.Split();
            try
            {
                lbFeladatok.Items.Add(Operatorok.Szamitas(Convert.ToInt32(mezok[0]), mezok[1], Convert.ToInt32(mezok[2])));
            }
            catch (OverflowException)
            {
                lbFeladatok.Items.Add("Egyéb hiba!");
            }
        }

        private void btnFajlLetrehozas_Click(object sender, RoutedEventArgs e)
        {
            //8. feladat
            lbFeladatok.Items.Add("8. feladat: eredmenyek.txt");
            StreamWriter streamWriter = new StreamWriter("eredmenyek.txt");
            foreach (Operatorok elem in operatorokLista)
            {
                streamWriter.WriteLine($"{elem.ElsoOperandus} {elem.SzovegesOperator} {elem.MasodikOperandus} = {Operatorok.Szamitas(elem.ElsoOperandus, elem.SzovegesOperator, elem.MasodikOperandus)}");
            }
        }
    }
}
