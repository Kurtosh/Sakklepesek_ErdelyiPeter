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
        public MainWindow()
        {
            InitializeComponent();
            GombokGeneralasa();
        }

        private void GombokGeneralasa()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button gomb = new Button();
                    gomb.Height = 50;
                    gomb.Width = 50;
                    gomb.Margin = new Thickness(50 * j, 50 * i, 0, 0);
                    hatter.Children.Add(gomb);
                    if (j % 2 != 0 && i % 2 == 0)
                    {
                        gomb.Background = Brushes.Black;
                    }
                    else
                    {
                        if (j % 2 == 0 && i % 2 != 0)
                        {
                            gomb.Background = Brushes.Black;
                        }
                        else
                        {
                            gomb.Background = Brushes.White;
                        }
                    }
                }
            }
        }
    }
}
