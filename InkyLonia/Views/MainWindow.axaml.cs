using Avalonia.Controls;
using InkyLonia.ViewModels;

namespace InkyLonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void DeckSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var vm = DataContext as MainWindowViewModel;
        vm?.DeckSelectionChanged();
    }
    
    private void ConstDeckSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var vm = DataContext as MainWindowViewModel;
        vm?.ConstDeckSelectionChanged();
    }
    
}