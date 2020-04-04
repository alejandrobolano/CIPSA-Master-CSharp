using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace CIPSA_CSharp_Module9WPF
{
   public class Utils
    {

        public static void ShowMessageByEmptyFields()
        {
            MessageBox.Show("Faltan campos por rellenar", "Información");
        }

        public static void ClearFields(Grid gridToClear)
        {
            foreach (var control in gridToClear.Children)
            {
                switch (control)
                {
                    case TextBox box:
                        box.Text = string.Empty;
                        break;
                    case RadioButton radio:
                        radio.IsChecked = false;
                        break;
                    case CheckBox check:
                        check.IsChecked = false;
                        break;
                    case ComboBox comboBox:
                        comboBox.SelectedIndex = 0;
                        break;
                }
            }
        }
        public static bool HasAnyEmptyFields(Grid gridToCheck)
        {
            var hasAnyEmptyField = false;
            var iterator = 0;
            var gridChildren = gridToCheck.Children;
            while (!hasAnyEmptyField && iterator < gridChildren.Count)
            {
                var control = gridChildren[iterator];
                switch (control)
                {
                    case TextBox box:
                        if(box.IsEnabled && box.Text.Equals(string.Empty))
                            hasAnyEmptyField = true;
                        break;
                    case ComboBox box:
                        if(box.Text.Equals(string.Empty))
                            hasAnyEmptyField = true;
                        break;
                }

                iterator++;
            }
            return hasAnyEmptyField;
        }

        public static bool HasNotNumberValidation(string value)
        {
            var regex = new Regex("[^0-9]+");
            return regex.IsMatch(value);
        }
        public static bool HasNotTextValidation(string value)
        {
            var regex = new Regex("[^a-zA-Z]+");
            return regex.IsMatch(value);
        }
    }
}
