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

namespace Sakklepesek_ErdélyiPéter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] mezok;
        string sakkBabu = "";
        public MainWindow()
        {
            InitializeComponent();
            GombokGeneralasa();
        }

        private void GombokGeneralasa()
        {
            for (int i = 0; i < 8; i++)
            {
                tabla.RowDefinitions.Add(new RowDefinition());
                tabla.ColumnDefinitions.Add(new ColumnDefinition());
            }
            mezok = new Button[8, 8];
            tabla.Children.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mezok[i, j] = new Button();
                    mezok[i, j].Click += SakkLepesek;
                    tabla.Children.Add(mezok[i, j]);
                    Grid.SetRow(mezok[i, j], i);
                    Grid.SetColumn(mezok[i, j], j);
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        mezok[i, j].Background = Brushes.Black;
                    }
                    else
                    {
                        if (i % 2 != 0 && j % 2 == 0)
                        {
                            mezok[i, j].Background = Brushes.Black;
                        }
                        else
                        {
                            mezok[i, j].Background = Brushes.White;
                        }
                    }
                }
            }
        }
        int[] HolVan(Button gomb)
        {
            int[] indexek = { -1, -1 };
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (mezok[i, j].Equals(gomb))
                    {
                        indexek[0] = i;
                        indexek[1] = j;
                        return indexek;

                    }
                }
            }
            return indexek;
        }
        private void SakkLepesek(object sender, RoutedEventArgs e)
        {
            Button aktualis = sender as Button;
            int x = HolVan(aktualis)[0];
            int y = HolVan(aktualis)[1];
            pozTB.Text = $"({y+1};{8 - x})";
            if (sakkBabu == "feherKiraly")
            {
                if ((x - 1) >= 0 && y >= 0)
                {
                    if (mezok[x - 1, y].Background != Brushes.Red)
                    {
                        mezok[x - 1, y].Background = Brushes.Red;
                        lepesekSzamaCB.Items.Add($"({y};{(8 - x)})");
                    }
                }
                if ((x + 1) < 8 && y >= 0)
                {
                    if (mezok[x + 1, y].Background != Brushes.Red)
                    {
                        mezok[x + 1, y].Background = Brushes.Red;
                    }
                }
                if (x >= 0 && (y-1) >= 0)
                {
                    if (mezok[x , y-1].Background != Brushes.Red)
                    {
                        mezok[x , y-1].Background = Brushes.Red;
                    }
                }
                if (x >= 0 && x < 8 && (y + 1) > 0 && (y + 1) < 8)
                {
                    if (mezok[x , y+1].Background != Brushes.Red)
                    {
                        mezok[x , y+1].Background = Brushes.Red;
                    }
                }
                if ((x-1) >= 0 && (y - 1) >= 0)
                {
                    if (mezok[x - 1, y-1].Background != Brushes.Red)
                    {
                        mezok[x - 1, y-1].Background = Brushes.Red;
                    }
                }
                if ((x + 1) > 0 && (x + 1) < 8 && (y + 1) < 8 && (y + 1) > 0)
                {
                    if (mezok[x + 1, y+1].Background != Brushes.Red)
                    {
                        mezok[x + 1, y+1].Background = Brushes.Red;
                    }
                }
                if ((x - 1) > 0 && (x - 1) < 8 && (y + 1) > 0 && (y + 1) < 8)
                {
                    if (mezok[x - 1, y+1].Background != Brushes.Red)
                    {
                        mezok[x - 1, y+1].Background = Brushes.Red;
                    }
                }
                if ((x + 1) > 0 && (x + 1) < 8 && (y - 1) > 0 && (y - 1) < 8)
                {
                    if (mezok[x + 1, y-1].Background != Brushes.Red)
                    {
                        mezok[x + 1, y-1].Background = Brushes.Red;
                    }
                }
            }
            if (sakkBabu == "feketeGyalog")
            {
                if ((x - 1) >= 0 && y >= 0)
                {
                    if (mezok[x - 1, y].Background != Brushes.Red)
                    {
                        mezok[x - 1, y].Background = Brushes.Red;
                    }
                }
                if ((x - 2) >= 0 && y >= 0)
                {
                    if (mezok[x - 2, y].Background != Brushes.Red)
                    {
                            mezok[x - 2, y].Background = Brushes.Red;
                    }
                }
                
            }
        }

        private void feherGyalogBT_Click(object sender, RoutedEventArgs e)
        {
            figura.Source = new BitmapImage(new Uri("D:/GitHubP4/Sakklepesek_ErdélyiPéter/fehergyalog.png"));
            sakkBabu = "feherGyalog";
        }

        private void feherKiralyBT_Click(object sender, RoutedEventArgs e)
        {
            figura.Source = new BitmapImage(new Uri("D:/GitHubP4/Sakklepesek_ErdélyiPéter/feherkiraly.png"));
            sakkBabu = "feherKiraly";
        }

        private void feherKiralynoBT_Click(object sender, RoutedEventArgs e)
        {
            figura.Source = new BitmapImage(new Uri("D:/GitHubP4/Sakklepesek_ErdélyiPéter/feherkiralyno.png"));
            sakkBabu = "feherKiralyno";
        }

        private void feherBastyaBT_Click(object sender, RoutedEventArgs e)
        {
            figura.Source = new BitmapImage(new Uri("D:/GitHubP4/Sakklepesek_ErdélyiPéter/feherbastya.png"));
            sakkBabu = "feherBastya";
        }

        private void feherFutoBT_Click(object sender, RoutedEventArgs e)
        {
            figura.Source = new BitmapImage(new Uri("D:/GitHubP4/Sakklepesek_ErdélyiPéter/feherfuto.png"));
            sakkBabu = "feherFuto";
        }

        private void feherLoBT_Click(object sender, RoutedEventArgs e)
        {
            figura.Source = new BitmapImage(new Uri("D:/GitHubP4/Sakklepesek_ErdélyiPéter/feherlo.png"));
            sakkBabu = "feherLo";
        }

        private void feketeGyalogBT_Click(object sender, RoutedEventArgs e)
        {
            figura.Source = new BitmapImage(new Uri("D:/GitHubP4/Sakklepesek_ErdélyiPéter/feketegyalog.png"));
            sakkBabu = "feketeGyalog";
        }

    }
}
