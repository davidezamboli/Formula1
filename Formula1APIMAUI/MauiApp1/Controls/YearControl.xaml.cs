namespace MauiApp1.controls;

public partial class YearControl : ContentView
{
    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(
            nameof(Value),
            typeof(int),
            typeof(YearControl));

    public int Value 
    { 
        get => (int)GetValue(ValueProperty); 
        set => SetValue(ValueProperty, value);
    }

    public event EventHandler<int> YearChanged;
    private bool _isEntryValidated;
    private int _previousValidValue;

    public YearControl()
	{
		InitializeComponent();
        ValueEntry.Text = "2001";
	}

    private void MinusButton_Clicked(object sender, EventArgs e)
    {
        if (Value > 0)
        {
            Value--;
            ValueEntry.Text = Value.ToString();
        }
        if (Value < 1950)
        {
            App.Current.MainPage.DisplayAlert("Errore", "Inserire un anno dal 1950 ad oggi", "OK");
            ValueEntry.Text = _previousValidValue.ToString();
        }
    }

    private void PlusButton_Clicked(object sender, EventArgs e)
    {
        if (Value >= 2024)
        {
            App.Current.MainPage.DisplayAlert("Errore", "Inserire un anno dal 1950 ad oggi", "OK");
            ValueEntry.Text = _previousValidValue.ToString();
        }
        else
        {
            Value++;
            ValueEntry.Text = Value.ToString();
        }
        
    }

    private void ValueEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (int.TryParse(e.NewTextValue, out int value))
        {
            _isEntryValidated = IsValidEntry(value);

            if (_isEntryValidated)
            {
                _previousValidValue = value;
                Value = value;
                YearChanged?.Invoke(this, Value);
            }
            else
            {
                //App.Current.MainPage.DisplayAlert("Errore", "Inserire un anno dal 1950 ad oggi", "OK");
                _isEntryValidated = false;
            }
        }

        if (e.NewTextValue.StartsWith("-"))
        {
            ValueEntry.Text = Value.ToString();
            return;
        }
    }

    private void ValueEntry_Completed(object sender, EventArgs e)
    {
        if (_isEntryValidated)
        {
            Value = _previousValidValue;
            YearChanged?.Invoke(this, Value);
        }
        else 
        {
            App.Current.MainPage.DisplayAlert("Errore", "Inserire un anno dal 1950 ad oggi", "OK");
            ValueEntry.Text = _previousValidValue.ToString();
        }
    }

    private bool IsValidEntry(int year)
    {
        //if (year >= 1950 && year <= DateTime.Now.Year)
        //{
        //    return true;
        //} 
        //else
        //{
        //    return false;
        //}

        return year >= 1950 && year <= DateTime.Now.Year;
    }




}