using System.Collections.ObjectModel;

namespace PaymentSplit;

public partial class HistoryPage : ContentPage
{
	public HistoryPage()
	{
		InitializeComponent();
        TxtFiles = new ObservableCollection<string>();
        FilesList.ItemsSource = TxtFiles;
        var savedPath = SettingsPage.FolderPathKey;
        if (!string.IsNullOrEmpty(savedPath))
        {
            LoadTxtFiles(savedPath);
        }
        else
        {
            Error();
        }
    }

    public async void Error()
    {
        await DisplayAlert("Ошибка", "Истории нету :(", "Ок");
        await Navigation.PopModalAsync();
    }

    public ObservableCollection<string> TxtFiles { get; set; }
    private void LoadTxtFiles(string folderPath)
    {
        try
        {
            TxtFiles.Clear();

            var txtFiles = Directory.GetFiles(folderPath, "*.txt");

            foreach (var file in txtFiles)
            {
                if (Path.GetFileName(file)!="config.txt" || Path.GetFileName(file) != "Friends.txt")
                    TxtFiles.Add(file);
            }

            if (TxtFiles.Count == 0)
            {
                DisplayAlert("Информация", "В выбранной папке нет файлов .txt.", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Ошибка", $"Не удалось загрузить файлы: {ex.Message}", "OK");
        }
    }

    private async void OnFileSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is string selectedFilePath)
        {
            try
            {
                var fileContent = await File.ReadAllTextAsync(selectedFilePath);

                FileContentEditor.Text = fileContent;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Не удалось открыть файл: {ex.Message}", "OK");
            }

            FilesList.SelectedItem = null;
        }
    }
    private async void OnCalcButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private void OnHistoryButtonClicked(object sender, EventArgs e)
    {
    }

    private async void OnSettingsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
        var previousPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 2];
        Navigation.RemovePage(previousPage);
    }
}