using OhmsLaws.ViewModels;

namespace OhmsLaws.Views;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}