namespace PaymentSplit
{
    public partial class SettingsPage : ContentPage
    {
        public static string FolderPathKey = AppDomain.CurrentDomain.BaseDirectory;
        public SettingsPage()
        {
            InitializeComponent();
            var savedPath = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(savedPath))
            {
                FolderPathLabel.Text = "������� �����: " + savedPath;
            }
            FileContentEditor.Text = File.ReadAllText(Friends.FriendFile);
        }
        private async void OnSelectFolderClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync();

                if (result != null)
                {
                    var folderPath = Path.GetDirectoryName(result.FullPath);

                    Preferences.Set(FolderPathKey, folderPath);

                    FolderPathLabel.Text = "������� �����: " + folderPath;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("������", "�� ������� ������� �����: " + ex.Message, "OK");
            }
        }
        private async void OnCalcButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OnHistoryButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
            var previousPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 2];
            Navigation.RemovePage(previousPage);
        }

        private void OnSettingsButtonClicked(object sender, EventArgs e)
        {
        }
    }
}