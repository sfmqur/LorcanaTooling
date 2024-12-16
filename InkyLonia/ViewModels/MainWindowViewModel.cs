using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LorcanaLogic;

namespace InkyLonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
  [ObservableProperty] private string _deckName = "";
  [ObservableProperty] private string _deckList = "";
  [ObservableProperty] private string _output = "";
  [ObservableProperty] private ObservableCollection<DeckPlaintext> _decks = [];
  [ObservableProperty] private ObservableCollection<DeckPlaintext> _constructedDecks = []; 

  [ObservableProperty] private DeckPlaintext? _selectedDeck; 
  [ObservableProperty] private DeckPlaintext? _selectedConstDeck; 

  private bool _deletePressed = false;
  private bool _isLastSelectionConstDecks = false; 
  public MainWindowViewModel()
  {
    Decks.Add(new DeckPlaintext("ralph", ""));
    Decks.Add(new DeckPlaintext("george", ""));
  }
  
  public void DeckSelectionChanged()
  {
    if (SelectedDeck is null) return;
    DeckName = SelectedDeck.Name;
    DeckList = SelectedDeck.Plaintext;
    _isLastSelectionConstDecks = false;
  }
  
  public void ConstDeckSelectionChanged()
  {
    if (SelectedConstDeck is null) return;
    DeckName = SelectedConstDeck.Name;
    DeckList = SelectedConstDeck.Plaintext;
    _isLastSelectionConstDecks = true;
  }
  
  [RelayCommand]
  private void SaveDeckList()
  {
    if (_isLastSelectionConstDecks)
    {
      
    }
    else
    {
      Decks.Add(new DeckPlaintext(DeckName, DeckList));
    }
  }

  [RelayCommand]
  private void DeleteDeckList()
  {
    if (_deletePressed)
    {
      if (SelectedDeck is not null)
      {
        Decks.Remove(SelectedDeck);
      }

      Output = "";
      _deletePressed = false; 
    }
    else
    {
      Output = "Are you sure you want to delete the selected deck?\n" +
               "Press Delete Again to Delete.";
      _deletePressed = true; 
    }
  }

  [RelayCommand]
  private void ConstructDeck()
  {
    if (SelectedDeck is null) return;
    ConstructedDecks.Add(SelectedDeck);
    Decks.Remove(SelectedDeck);
  }

  [RelayCommand]
  private void DeconstructDeck()
  {
    if (SelectedConstDeck is null) return;
    Decks.Add(SelectedConstDeck);
    ConstructedDecks.Remove(SelectedConstDeck);
  }
  
  [RelayCommand]
  private void DeckIntersection()
  {
    Output = SelectedDeck is not null ? SelectedDeck.ToString() : "No deck selected.";
  }

  [RelayCommand]
  private void FullReport()
  {
    
  }

  [RelayCommand]
  private void DeckDifference()
  {
    
  }
}