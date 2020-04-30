using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using VideoClub.Common.BusinessLogic.Dto;
using VideoClub.Common.BusinessLogic.Implementations;
using VideoClub.Common.Model.Enums;
using VideoClub.Common.Model.Extensions;
using VideoClub.DialogsView;
using VideoClub.WPF.Views.DialogsView;

namespace VideoClub.WPF.Views
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : MetroWindow
    {
        private readonly DateTime _todayDateTime;
        private ClientService _clientService;
        private IList<ClientDto> _clients;
        private readonly IDictionary<AccreditationEnum, string> _itemsAccreditationType;
        public ClientWindow()
        {
            InitializeComponent();
            _todayDateTime = DateTime.Today;
            _itemsAccreditationType = new Dictionary<AccreditationEnum, string>
            {
                {AccreditationEnum.Dni,AccreditationEnum.Dni.GetDescription()},
                {AccreditationEnum.Nie,AccreditationEnum.Nie.GetDescription()}
            };
        }

        private void LoadingData()
        {
            _clientService = new ClientService();
            _clients = _clientService.All();
        }

        private async Task LoadingDataTask()
        {
            await Task.Run(LoadingData);
        }

        private async void ClientDataGrid_OnLoadedDataGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            await LoadDataGrid();
        }

        private async Task LoadDataGrid()
        {
            LoadingPanel.Visibility = Visibility.Visible;
            await LoadingDataTask();
            ClientDataGrid.ItemsSource = _clients;
            LoadingPanel.Visibility = Visibility.Hidden;
        }

        public async Task<MessageDialogResult> PromptAsync(string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
        {
            return await this.ShowMessageAsync(title, message, style, settings);
        }

        private void AccreditationDropDown_OnLoaded(object sender, RoutedEventArgs e)
        {
            AccreditationDropDown.ItemsSource = _itemsAccreditationType.Values;
        }

        private void DateNowTextBlock_OnLoaded(object sender, RoutedEventArgs e)
        {
            DateNowTextBlock.Text = _todayDateTime.ToShortDateString();
        }

        private bool AddClientWithDataFromFields()
        {
            var accreditationType = _itemsAccreditationType.FirstOrDefault(x => x.Value.Equals(AccreditationDropDown.SelectedValue)).Key;
            var client = new ClientDto
            {
                Accreditation = AccreditationText.Text,
                AccreditationType = accreditationType,
                Address = AddressText.Text,
                Email = EmailText.Text,
                Name = NameText.Text,
                LastName = LastNameText.Text,
                PhoneContact = PhoneContactText?.Text,
                PhoneAux = PhoneAuxText?.Text,
                SubscriptionDate = _todayDateTime
            };
            return _clientService.Add(client);
        }

        private void FillFieldsDataFromDataGrid(object sender)
        {
            var rowSelectedValue = sender as DataGrid;
            var client = (ClientDto)rowSelectedValue?.SelectedValue;
            if (client == null) return;
            AccreditationText.Text = client.Accreditation;
            AccreditationDropDown.SelectedItem = _itemsAccreditationType[client.AccreditationType];
            AddressText.Text = client.Address;
            EmailText.Text = client.Email;
            NameText.Text = client.Name;
            LastNameText.Text = client.LastName;
            PhoneContactText.Text = client.PhoneContact;
            PhoneAuxText.Text = client.PhoneAux;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddClientWithDataFromFields())
            {
                await LoadDataGrid();
            }
        }

        private void ClientDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FillFieldsDataFromDataGrid(sender);
        }
    }
}
