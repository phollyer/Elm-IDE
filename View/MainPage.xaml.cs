using Elm_IDE.ViewModel;
using Elm_IDE.Lib;
using Elm_IDE;

namespace Elm_IDE.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        Console.WriteLine($"Elm Version {ToolChecker.ElmVersion}");

        Console.WriteLine($"Elm Format Version {ToolChecker.ElmFormatVersion}");

        Console.WriteLine($"Elm Json Version {ToolChecker.ElmJsonVersion}");

        Console.WriteLine($"Elm Test RS Version {ToolChecker.ElmTestRSVersion}");
    }
}


