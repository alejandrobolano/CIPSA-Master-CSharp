using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace VideoClub.WPF.Views
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml
    /// </summary>
    public partial class MovieWindow : MetroWindow
    {
        private readonly DateTime _todayDateTime;
        public MovieWindow()
        {
            InitializeComponent();
            _todayDateTime = DateTime.Today;
        }

        private void DateNowTextBlock_OnLoaded(object sender, RoutedEventArgs e)
        {
            DateNowTextBlock.Text = _todayDateTime.ToShortDateString();
        }
    }
}
