#if IOS
using UIKit;
#endif

using MauiApp1.controls;
using MauiApp1.Models;
using MauiApp1.Usings;
using System.Collections.ObjectModel;

namespace MauiApp1.Pages;

public partial class RacePage : ContentPage
{
    public ObservableCollection<Race> Races { get; set; } = new();
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

    public RacePage()
	{
		InitializeComponent();
        BindingContext = this;
        YearControlName.YearChanged += OnYearChanged;
    }

    private async void OnYearChanged(object? sender, int e)
    {
        Year = e;
        await LoadRaces();
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

        Year = 2001;
        OnPropertyChanged(nameof(Year));

        await LoadRaces();

        IsLoading = false;
        OnPropertyChanged(nameof(IsLoading));
    }

    public async Task LoadRaces()
    {
        IsLoading = true;
        OnPropertyChanged(nameof(IsLoading));

        Year = YearControlName.Value;
        OnPropertyChanged(nameof(Year));
        Races.Clear();
        
        var races = await NetworkManager.Istance.GetRacesFromJsonAsync(Year.ToString()); 
        foreach (var race in races)
        {
            Races.Add(race);
        }
        IsLoading = false;
        OnPropertyChanged(nameof(IsLoading));
    }
}