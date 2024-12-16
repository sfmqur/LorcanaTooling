using System;
using Avalonia.Controls;
using Avalonia.Input;
using InkyLonia.ViewModels;

namespace InkyLonia.Views;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
  }

  private void DeckSelectionChanged(object? sender, SelectionChangedEventArgs selectionChangedEventArgs)
  {
    var vm = DataContext as MainWindowViewModel;
    vm?.DeckSelectionChanged();
  }

  private void ConstDeckSelectionChanged(object? sender, SelectionChangedEventArgs selectionChangedEventArgs)
  {
    var vm = DataContext as MainWindowViewModel;
    vm?.ConstDeckSelectionChanged();
  }

  private void Decks_OnGotFocus(object? sender, GotFocusEventArgs e)
  {
    var vm = DataContext as MainWindowViewModel;
    vm?.DeckSelectionChanged();
  }

  private void ConstructedDecks_OnGotFocus(object? sender, GotFocusEventArgs e)
  {
    var vm = DataContext as MainWindowViewModel;
    vm?.ConstDeckSelectionChanged();
  }

  private void TopLevel_OnClosed(object? sender, EventArgs e)
  {
    var vm = DataContext as MainWindowViewModel;
    vm?.OnClose();
  }
}