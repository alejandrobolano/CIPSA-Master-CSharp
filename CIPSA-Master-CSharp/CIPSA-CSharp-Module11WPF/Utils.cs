using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CIPSA_CSharp_Module11.Extensions;
using CIPSA_CSharp_Module11.Geometrics;
using CIPSA_CSharp_Module11WPF;

namespace CIPSA_CSharp_Module9WPF
{
    public class Utils
    {
        public static string InheritanceName_Header = "Herencia - Ejercicio 1";
        public static string InterfacesName_Header = "Interfaces - Ejercicio 3";
        public static string Select = "Seleccionar";
        public static void ClearFields(Grid gridToClear, bool isInit)
        {
            foreach (var control in gridToClear.Children)
            {
                switch (control)
                {
                    case TextBox box:
                        box.Text = string.Empty;
                        box.IsEnabled = false;
                        ChangeStyleDefault(box);
                        break;
                    case ComboBox box:
                        if (isInit)
                        {
                            box.SelectedIndex = 0;
                        }
                        break;
                    case Button button:
                        button.IsEnabled = false;
                        break;
                }
            }
        }

        public static void ChangeStyleDefault(Control control)
        {
            control.ClearValue(Panel.BackgroundProperty);
            control.ClearValue(Border.BorderBrushProperty);
        }

        public static bool HasChangedStyleErrorIfIsEnabled(Control control)
        {
            var hasChanged = false;
            if (control.IsEnabled)
            {
                control.Background = Brushes.Beige;
                control.BorderBrush = Brushes.Red;
                hasChanged = true;
            }
            else control.IsEnabled = true;

            return hasChanged;
        }

        #region Calculates

        public static void CalculatesOfCircle(object calculateSelectItem, TextBox box, out Circle circle)
        {
            circle = new Circle
            {
                Radius = Convert.ToDouble(box.Text)
            };

            MessageBox.Show(calculateSelectItem.Equals(CalculateEnum.Area.GetDescription())
                ? "El Área del círculo es: " + Convert.ToString(circle.CalculateArea(), CultureInfo.CurrentCulture)
                : "El Perímetro del círculo es: " + Convert.ToString(circle.CalculatePerimeter(), CultureInfo.CurrentCulture));
        }

        public static void CalculatesOfSquare(object calculateSelectItem, TextBox box, out Square square)
        {
            square = new Square
            {
                Side = Convert.ToDouble(box.Text)
            };
            MessageBox.Show(calculateSelectItem.Equals(CalculateEnum.Area.GetDescription())
                ? "El Área del cuadrado es: " + Convert.ToString(square.CalculateArea(), CultureInfo.CurrentCulture)
                : "El Perímetro del cuadrado es: " +
                  Convert.ToString(square.CalculatePerimeter(), CultureInfo.CurrentCulture));
        }

        public static void CalculatesOfTriangle(object calculateSelectItem,
            TextBox boxA, TextBox boxB, TextBox boxC, out Triangle triangle)
        {
            var isCalculateArea = calculateSelectItem.Equals(CalculateEnum.Area.GetDescription());
            triangle = new Triangle
            {
                SideA = Convert.ToDouble(boxA.Text),
                SideB = Convert.ToDouble(boxB.Text),
                SideC = Convert.ToDouble(boxC.Text)
            };
            if (isCalculateArea)
            {
                MessageBox.Show("El Área del triángulo es: " +
                                Convert.ToString(triangle.CalculateArea(), CultureInfo.CurrentCulture));
            }
            else
            {
                MessageBox.Show("El Perímetro del triángulo es: " +
                                Convert.ToString(triangle.CalculatePerimeter(),
                                    CultureInfo.CurrentCulture));
            }
        }
        #endregion

    }
}
