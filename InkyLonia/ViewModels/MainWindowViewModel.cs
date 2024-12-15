using CommunityToolkit.Mvvm.ComponentModel;

namespace InkyLonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string _deckName = "";
    [ObservableProperty] private string _deckList = "";
    [ObservableProperty] private string _output = "";
    
}