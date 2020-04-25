using System;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using VideoClub.Common.BusinessLogic.Dto;
using VideoClub.Common.BusinessLogic.Implementations;
using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Utils;
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
            //var movie = new MovieDto
            //{
            //    BuyYear = 2008,
            //    Duration = new TimeSpan(2, 23, 10),
            //    NumberDisc = 2,
            //    Price = 20,
            //    ProductionYear = 2000,
            //    State = StateProductEnum.Available,
            //    Title = "Casa de papel"
            //};
            var movieService = new MovieService();
            //movieService.Add(movie);

            //var client1 = new ClientDto
            //{
            //    Accreditation = "Y52723472",
            //    Address = "Hospitalet de llobregat",
            //    Email = "alfa@alfa.com",
            //    Name = "Alejandro",
            //    LastName = "Bolaño",
            //    PhoneContact = "34666090909",
            //    SubscriptionDate = DateTime.Today
            //};

            var clientService = new ClientService();
            //clientService.Add(client1);

            var client = clientService.Get("CLI-IC8JLZ");
            var product = movieService.Get("Casa negra");
            var rental = new RentalDto
            {
                ClientAccreditation = client.Accreditation,
                ClientId = client.Id,
                ProductTitle = product.Title,
                ProductId = product.Id,
                FinishRental = new DateTime(2020, 11, 23),
                StartRental = DateTime.Today
            };

            var rentalService = new RentalService();
            rentalService.RentProduct(rental,CommonHelper.Movie, StateProductEnum.NonAvailable);
            var foo1 = rentalService.GetRentalsByClient("CLI-IC8JLZ");
            var foo2 = rentalService.GetRentalsByProduct("CLI-IC8JLZ");
            var foo3 = rentalService.GetRentalsByProduct("Casa de papel");

            //var videoGame = new VideoGameDto()
            //{
            //    NumberDisc = 1,
            //    Price = 2,
            //    Title = "Beta",
            //    Platform = GamePlatformEnum.Wii
            //};

            //var metroWindow = (Application.Current.MainWindow as MetroWindow);
            //metroWindow.ShowMessageAsync("Actualizacion", $"Nuevo nombre: ...");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new MovieDialog();
            dialog.ShowModalDialogExternally();
        }
    }
}
