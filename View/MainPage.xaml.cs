using Elm_IDE.ViewModel;

namespace Elm_IDE.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}


