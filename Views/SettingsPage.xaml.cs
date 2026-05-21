namespace AntHiveStock.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        
        ThemeSwitch.Toggled -= OnThemeToggled;

        
        ThemeSwitch.IsToggled = Application.Current.Resources["AppBackgroundColor"].Equals(Color.FromArgb("#0F172A"));

        
        ThemeSwitch.Toggled += OnThemeToggled;
    }

    private void OnThemeToggled(object sender, ToggledEventArgs e)
    {
        if (e.Value) 
        {
            Application.Current.Resources["AppBackgroundColor"] = Color.FromArgb("#0F172A");
            Application.Current.Resources["AppCardColor"] = Color.FromArgb("#1E293B");
            Application.Current.Resources["AppTextColor"] = Colors.White;
            Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#94A3B8");
            Application.Current.Resources["AppBorderColor"] = Color.FromArgb("#334155");
            Application.Current.Resources["AppEntryTextColor"] = Colors.White;
            Application.Current.Resources["AppButtonBorder"] = Colors.White;
        }
        else 
        {
            Application.Current.Resources["AppBackgroundColor"] = Color.FromArgb("#F8FAFC");
            Application.Current.Resources["AppCardColor"] = Colors.White;
            Application.Current.Resources["AppTextColor"] = Color.FromArgb("#0F172A");
            Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#64748B");
            Application.Current.Resources["AppBorderColor"] = Color.FromArgb("#E2E8F0");
            Application.Current.Resources["AppEntryTextColor"] = Color.FromArgb("#0F172A");
            Application.Current.Resources["AppButtonBorder"] = Color.FromArgb("#0F172A");
        }
    }
}