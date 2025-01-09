using System.Diagnostics;
using System.Globalization;

namespace PaymentSplit;

public partial class PartyDetailsPage : ContentPage
{
	public PartyDetailsPage()
	{
		InitializeComponent();
	}
    public static string Bar;
    public static Dictionary<string, Dictionary<string, double>> payers = new Dictionary<string, Dictionary<string, double>>();
    private int _currentRowIndex = 2;

    private void OnAddRowButtonClicked(object sender, EventArgs e)
    {
        // ������� ����� ���� �����
        var nameEntry = new Entry { Placeholder = "������� ���" };
        var sumEntry = new Entry { Placeholder = "������� �����", Keyboard = Keyboard.Numeric };

        // ��������� � �������
        FriendsGrid.Add(nameEntry, 0, _currentRowIndex);
        FriendsGrid.Add(sumEntry, 1, _currentRowIndex);

        // ����������� ������ ������
        _currentRowIndex++;
    }

    public async void OnEndButtonClicked(object sender, EventArgs e)
    {
        errorText.Text = "";
        if (!AreYouSureCheckBox.IsChecked)
        {
            errorText.Text = "�� �� �������";
        }

        else if (!String.IsNullOrEmpty(errorText.Text))
        {

        }
        else if (String.IsNullOrEmpty(VeryRichestFriendEntry.Text))
        {
            errorText.Text = "�� ������ ����� ������� ����.";
        }

        else
        {
            SaveInformation();

            ClearTable();

            BarNameEntry.Text = string.Empty;

            VeryRichestFriendEntry.Text = string.Empty;

            AreYouSureCheckBox.IsChecked = false;

            errorText.Text = string.Empty;
            Struct.Structuring("\n");
            Struct.Structuring("����:");
            Calculator.DebtCalculate();
            string result = Calculator.Result();
            Struct.Structuring(result);
            FileWork.FileWrite(Path.Combine(SettingsPage.FolderPathKey, $"{MainPage.partyName}{MainPage.date}.txt"), Struct.Convert());
            payers.Clear();

            await DisplayAlert("����", result, "��");
            await Navigation.PopToRootAsync();
        }
    }
    private void ClearTable()
    {
        FriendsGrid.Children.Clear();
        _currentRowIndex = 0;
        var nameEntry = new Entry { Placeholder = "������� ���" };
        var sumEntry = new Entry { Placeholder = "������� �����", Keyboard = Keyboard.Numeric };
        FriendsGrid.Add(nameEntry, 0, _currentRowIndex);
        FriendsGrid.Add(sumEntry, 1, _currentRowIndex);
        _currentRowIndex = 2;
    }
    public async void OnAddBarButtonClicked(object sender, EventArgs e)
    {
        errorText.Text = "";
        if (!AreYouSureCheckBox.IsChecked)
        {
            errorText.Text = "�� �� �������";
        }
        else if (!String.IsNullOrEmpty(errorText.Text))
        {

        }
        else if (String.IsNullOrEmpty(VeryRichestFriendEntry.Text))
        {
            errorText.Text = "�� ������ ����� ������� ����.";
        }
        else
        {
            SaveInformation();

            ClearTable();

            BarNameEntry.Text = string.Empty;

            VeryRichestFriendEntry.Text = string.Empty;

            AreYouSureCheckBox.IsChecked = false;

            errorText.Text = string.Empty;

            await Navigation.PushAsync(new PartyDetailsPage());
        }
    }


    public void SaveInformation()
    {
        string VeryRichestFriend = VeryRichestFriendEntry.Text;
        VeryRichestFriend = VeryRichestFriend.Substring(0,1).ToUpper()+VeryRichestFriend.Substring(1).ToLower();

        Struct.Structuring(Struct.Separator);
        Struct.Structuring($"���:{BarNameEntry.Text}");
        Struct.Structuring($"������:{VeryRichestFriendEntry.Text}");
        Struct.Structuring("\n");
        Struct.Structuring("=========���������=========");

        if (!payers.ContainsKey(VeryRichestFriend))
        {
            payers[VeryRichestFriend] = new Dictionary<string, double>();
        }

        for (int row = 1; row < _currentRowIndex; row++)
        {
            var nameEntry = FriendsGrid.Children[row * 2];
            var sumEntry = FriendsGrid.Children[row * 2 + 1];
            if (nameEntry != null)
            {
                string name = ((Entry)nameEntry).Text.Trim();
                name = name.Substring(0, 1) + name.Substring(1).ToLower();
                double sum;
                if (double.TryParse(((Entry)sumEntry).Text, CultureInfo.InvariantCulture,out sum))
                {

                }
                else
                {
                    sum = 0;
                }
                if (!String.IsNullOrEmpty(name))
                {
                    Struct.Structuring($"{name} : {sum.ToString()}");
                    if (!FileWork.FileRead(Friends.FriendFile).Contains(name))
                    {
                        FileWork.FileWrite(Friends.FriendFile, name);
                    }
                    if (!String.IsNullOrEmpty(name) && name != VeryRichestFriend)
                    {
                        if (sum >= 0)
                        {
                            if (payers[VeryRichestFriend].ContainsKey(name))
                            {
                                payers[VeryRichestFriend][name] = payers[VeryRichestFriend][name] + sum;
                            }
                            else
                            {
                                payers[VeryRichestFriend][name] = sum;
                            }
                        }
                        else
                        {
                            errorText.Text = "������������� ����!";
                        }
                    }
                }
            }
        }
    }
}