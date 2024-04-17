using CommunityToolkit.Maui.Views;
using MauiApp1.Models;

namespace MauiApp1.Popup;

public partial class DriverDetailPopup : CommunityToolkit.Maui.Views.Popup
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateBirth { get; set; }
    public string PermanentNumber { get; set; }
    public string Flag { get; set; }

    public DriverDetailPopup(Driver driver)
	{
        Size = new Size(300, 300);
        FirstName = driver.givenName;
        LastName = driver.familyName;
        DateBirth = driver.dateOfBirth;
        PermanentNumber = driver.permanentNumber;
        Flag = driver.emojiFlag;

        BindingContext = this;
		InitializeComponent();
	}
}