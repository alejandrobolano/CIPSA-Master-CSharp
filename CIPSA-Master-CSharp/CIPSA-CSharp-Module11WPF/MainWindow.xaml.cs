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
using CIPSA_CSharp_Module11.Building.Models;

namespace CIPSA_CSharp_Module11WPF
{
    public partial class MainWindow : Window
    {
        private Office _office;
        private House _house;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AddObjectsButton_Click(object sender, RoutedEventArgs e)
        {
            _office = new Office(3, 4, 200, 4, 6);
            _house = new House(2, 4, 150, 4, 3);
            if (_office == null || _house == null) return;
            MessageBox.Show("Se han creado satisfactoriamente los objetos");
            ShowObjectsButton.IsEnabled = true;
        }

        private void ShowObjectsButton_Click(object sender, RoutedEventArgs e)
        {
            var content = "Objeto Oficina:" +
                          $"\n {_office}" +
                          "\nObjeto Casa:" +
                          $"\n {_house}";
            ContentTextBlock.Text = content;
        }

        private void DestroyObjectsButton_Click(object sender, RoutedEventArgs e)
        {
            _office = null;
            _house = null;
            ContentTextBlock.Text = string.Empty;
            ShowObjectsButton.IsEnabled = false;
            MessageBox.Show("Se han destruido los objetos");
        }
    }
}
