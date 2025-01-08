using Microsoft.Maui.Controls;
using System.Globalization;

namespace PaymentSplit
{
    public partial class MainPage : ContentPage
    {
        public static string partyName;
        public static string date;
        public MainPage()
        {
            InitializeComponent();
            ConfigManager.LoadConfig();
            Friends.FriendsCreate(null);
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            partyName = PartyNameEntry.Text;
            date = DateEntry.Text;
            DateTime parsedDate;
            string[] formats = { "dd.MM.yy", "dd.MM.yyyy" };
            bool isValidDate = DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
            if (!string.IsNullOrWhiteSpace(partyName) && !string.IsNullOrWhiteSpace(date))
            {
                if (isValidDate)
                {
                    Struct.Structuring(partyName);
                    Struct.Structuring(parsedDate.ToString());
                    PartyNameEntry.Text = string.Empty;
                    DateEntry.Text = string.Empty;
                    await Navigation.PushAsync(new PartyDetailsPage());
                }
                else
                {
                    await DisplayAlert("Ошибка", "Неправильная дата.", "ОК");
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля.", "ОК");
            }
        }

        private void OnCalcButtonClicked(object sender, EventArgs e)
        {
        }

        private async void OnHistoryButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }

        private async void OnSettingsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
