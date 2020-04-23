using System;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using VideoClub.Common.BusinessLogic.Implementations;
using VideoClub.DialogsView;
using VideoGameDto = VideoClub.Common.BusinessLogic.Dto.VideoGameDto;

namespace VideoClub.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var videoGameService = new VideoGameService();
            videoGameService.Add(null);
            var foo2 = videoGameService.Get("Brutal");
            var foo = videoGameService.Remove("GAM-TLD700");
            if (foo)
            {
                var metroWindow = (Application.Current.MainWindow as MetroWindow);
                metroWindow.ShowMessageAsync("Eliminado", "message...");
            }

            foo2.Title = "Brutal 2";
            var foo3 = videoGameService.Update(foo2);
            if (foo3)
            {
                var metroWindow = (Application.Current.MainWindow as MetroWindow);
                metroWindow.ShowMessageAsync("Actualizacion", $"Nuevo nombre: {foo2.Title}...");
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new MovieDialog();
            dialog.ShowModalDialogExternally();
        }
    }
}
