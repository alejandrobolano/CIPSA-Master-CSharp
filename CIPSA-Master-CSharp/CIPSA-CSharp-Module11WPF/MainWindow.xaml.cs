using System;
using System.Collections.Generic;
using System.Globalization;
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
using CIPSA_CSharp_Module11.Extensions;
using CIPSA_CSharp_Module11.Geometrics;
using CIPSA_CSharp_Module9WPF;

namespace CIPSA_CSharp_Module11WPF
{
    public partial class MainWindow : Window
    {
        private Office _office;
        private House _house;
        private Square _square;
        private Triangle _triangle;
        private Circle _circle;
        public MainWindow()
        {
            InitializeComponent();
            LoadHeader();
        }

        #region Modulo 11 - Herencia - Ejercicio 1

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

        #endregion

        #region Modulo 11 - Interfaces - Ejercicio 3

        private void InitializeComboBox()
        {
            var shapeSource = new[]
            {
                Utils.Select,
                ShapeEnum.Square.GetDescription(),
                ShapeEnum.Triangle.GetDescription(),
                ShapeEnum.Circle.GetDescription()
            };
            SelectShapeComboBox.ItemsSource = shapeSource;
            var calculateSource = new[]
            {
                Utils.Select,
                CalculateEnum.Area.GetDescription(),
                CalculateEnum.Perimeter.GetDescription()
            };
            CalculateComboBox.ItemsSource = calculateSource;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var shapeSelectedItem = SelectShapeComboBox.SelectedItem;
            var calculateSelectItem = CalculateComboBox.SelectedItem;
            if (!shapeSelectedItem.Equals(string.Empty) && !calculateSelectItem.Equals(string.Empty))
            {
                try
                {
                    if (shapeSelectedItem.Equals(ShapeEnum.Circle.GetDescription()))
                    {
                        Utils.CalculatesOfCircle(calculateSelectItem,RadiusTextBox,out _circle);
                    }
                    else if (shapeSelectedItem.Equals(ShapeEnum.Square.GetDescription()))
                    {
                        Utils.CalculatesOfSquare(calculateSelectItem,SideSquareTextBox,out _square);
                    }
                    else
                    {
                        Utils.CalculatesOfTriangle(calculateSelectItem,
                            SideATriangleTextBox,
                            SideBTriangleTextBox,
                            SideCTriangleTextBox,
                            HighBaseATriangleTextBox,
                            out _triangle);
                    }
                }
                catch (FormatException)
                {
                    ValidationFields();
                    MessageBox.Show("El campo tiene formato incorrecto o está vacío");
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Utils.ClearFields(InterfacesGrid, false);

            if (!((ComboBox)sender).Name.Equals(SelectShapeComboBox.Name))
            {
                ValidationFields();
                DrawButton.IsEnabled = true;
            }
            else
            {
                CalculateComboBox.IsEnabled = true;
                CalculateComboBox.SelectedIndex = 0;
                DrawButton.IsEnabled = true;
            }
            if (!((ComboBox)sender).SelectedItem.Equals(Utils.Select) && !CalculateComboBox.SelectedItem.Equals(Utils.Select))
            {
                CalculateButton.IsEnabled = true;
                
            }

        }

        private void ValidationFields()
        {
            var shapeSelected = SelectShapeComboBox.SelectedItem;
            if (CalculateComboBox.SelectedItem.Equals(Utils.Select)) return;
            if (shapeSelected.Equals(ShapeEnum.Circle.GetDescription()) && RadiusTextBox.Text.Equals(string.Empty))
            {
                Utils.ChangeStyleErrorIfIsEnabled(RadiusTextBox);
            }
            else if (shapeSelected.Equals(ShapeEnum.Square.GetDescription()) && SideSquareTextBox.Text.Equals(string.Empty))
            {
                Utils.ChangeStyleErrorIfIsEnabled(SideSquareTextBox);
            }
            else if (shapeSelected.Equals(ShapeEnum.Triangle.GetDescription()))
            {
                ValidationsTriangle();
            }
        }

        private void ValidationsTriangle()
        {
            if (CalculateComboBox.SelectedItem.Equals(CalculateEnum.Area.GetDescription()))
            {
                if (HighBaseATriangleTextBox.Text.Equals(string.Empty))
                {
                    Utils.ChangeStyleErrorIfIsEnabled(HighBaseATriangleTextBox);
                }
            }
            else
            {
                if (SideBTriangleTextBox.Text.Equals(string.Empty))
                {
                    Utils.ChangeStyleErrorIfIsEnabled(SideBTriangleTextBox);
                }

                if (SideCTriangleTextBox.Text.Equals(string.Empty))
                {
                    Utils.ChangeStyleErrorIfIsEnabled(SideCTriangleTextBox);
                }
            }

            if (SideATriangleTextBox.Text.Equals(string.Empty))
            {
                Utils.ChangeStyleErrorIfIsEnabled(SideATriangleTextBox);
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            if (!text.Equals(string.Empty))
            {
                Utils.ChangeStyleDefault((TextBox)sender);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var value = ((TextBox)sender).Text;
            if (e.Text.Equals("+") || e.Text.Equals("-"))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = !decimal.TryParse(value + e.Text, out _);
            }

        }
        private void LoadHeader()
        {
            InheritanceTabItem.Header = Utils.InheritanceName_Header;
            InterfacesTabItem.Header = Utils.InterfacesName_Header;

        }

        private void InterfacesDataGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (((TabItem)TabControl.SelectedItem).Header.ToString().Equals(Utils.InterfacesName_Header))
            {
                InitializeComboBox();
                Utils.ClearFields(InterfacesGrid, true);
                CalculateComboBox.IsEnabled = false;
                _triangle = new Triangle();
                _square = new Square();
                _circle = new Circle();
            }
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            var shapeSelected = SelectShapeComboBox.SelectedItem;
            if (shapeSelected.Equals(ShapeEnum.Circle.GetDescription()))
            {
                MessageBox.Show(_circle.Draw());
            }
            else if (shapeSelected.Equals(ShapeEnum.Square.GetDescription()))
            {
                MessageBox.Show(_square.Draw());
            }
            else
            {
                MessageBox.Show(_triangle.Draw());
            }

        }
    }

    #endregion
}
