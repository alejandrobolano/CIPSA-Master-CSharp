﻿using System;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace VideoClub.DialogsView
{
    /// <summary>
    /// Interaction logic for MovieDialog.xaml
    /// </summary>
    public partial class MovieDialog : CustomDialog
    {
        public MovieDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OnClose();
        }

        private void SaveButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            OnClose();
            var metroWindow = (Application.Current.MainWindow as MetroWindow);
            metroWindow.ShowMessageAsync("title", "message...");
        }

    }
}
