#if IOS
using UIKit;
#endif

using CommunityToolkit.Maui.Views;
using MauiApp1.Models;
using MauiApp1.Popup;
using MauiApp1.Usings;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp1.Pages;

public partial class DriverPage : ContentPage
{
    public ObservableCollection<Driver> Drivers { get; set; } = new();
    public ICommand ShowDriver => new Command<Driver>((driver) => ShowDriverDetails(driver));
    public int Year
    {
        get => YearControlName.Value;
        set
        {
            if (YearControlName.Value != value)
            {
                YearControlName.Value = value;
                OnPropertyChanged(nameof(Year));
            }
        }
    }
    public bool IsLoading { get; set; }

    public DriverPage()
	{
		InitializeComponent();
        BindingContext = this;
        YearControlName.YearChanged += OnYearChanged;
    }

    private async void OnYearChanged(object? sender, int e)
    {
        Year = e;
        await LoadDrivers();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
#if IOS
		// margin of safe area
		var bottom = UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;
		borderControl.Margin = new Thickness(-1, 0, -1, (bottom + 1) * -1);
#endif

        IsLoading = true;
        OnPropertyChanged(nameof(IsLoading));

        await LoadDrivers();
    
        IsLoading = false;
        OnPropertyChanged(nameof(IsLoading));
    }

    public async Task LoadDrivers()
    {
        Drivers.Clear();

        var drivers = await NetworkManager.Istance.GetDriverFromJsonAsync(YearControlName.Value.ToString());
        foreach (var driver in drivers)
        {
            Drivers.Add(driver);
        }
    }

    private void ShowDriverDetails(Driver driver)
    {
        var driverPopup = new DriverDetailPopup(driver);
        this.ShowPopup(driverPopup);
    }
}