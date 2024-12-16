using System;
using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InkyLonia.Models;
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
  private readonly string _dataFolder = @"\InkyLonia\DeckDiff";
  private FileHandler _fileHandler; 
  public MainWindowViewModel()
  {
    _dataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + _dataFolder;
    if (!Directory.Exists(_dataFolder))
    {
      Directory.CreateDirectory(_dataFolder);
    }
    Decks.Add(new DeckPlaintext("ralph", "ra"));
    Decks.Add(new DeckPlaintext("george", "ga"));
    
    _fileHandler = new FileHandler(_dataFolder);
    OnOpen();
  }

  public void DeckSelectionChanged()
  {
    if (SelectedDeck is null) return;
    DeckName = SelectedDeck.Name;
    DeckList = SelectedDeck.Plaintext;
    _isLastSelectionConstDecks = false;
    _deletePressed = false;
  }

  public void ConstDeckSelectionChanged()
  {
    if (SelectedConstDeck is null) return;
    DeckName = SelectedConstDeck.Name;
    DeckList = SelectedConstDeck.Plaintext;
    _isLastSelectionConstDecks = true;
    _deletePressed = false;
  }

  private void OnOpen()
  {
    var dto = _fileHandler.LoadSettings();
    Decks = dto.DeckPlaintexts;
    ConstructedDecks = dto.ConstructedDeckPlaintexts;
  }
  
  public void OnClose()
  {
    _fileHandler.SaveSettings(ConstructedDecks, Decks);
  }
  
  [RelayCommand]
  private void SaveDeckList()
  {
    _deletePressed = false;
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
    if (SelectedDeck is null) return;
    if (_deletePressed)
    {
      Decks.Remove(SelectedDeck);
      Output = "";
      _deletePressed = false;
    }
    else
    {
      Output = $"Are you sure you want to delete the selected deck: {SelectedDeck.Name}?\n" +
               "Press Delete Again to Delete.";
      _deletePressed = true;
    }
  }

  [RelayCommand]
  private void ConstructDeck()
  {
    _deletePressed = false;
    if (SelectedDeck is null) return;
    ConstructedDecks.Add(SelectedDeck);
    Decks.Remove(SelectedDeck);
  }

  [RelayCommand]
  private void DeconstructDeck()
  {
    _deletePressed = false;
    if (SelectedConstDeck is null) return;
    Decks.Add(SelectedConstDeck);
    ConstructedDecks.Remove(SelectedConstDeck);
  }

  [RelayCommand]
  private void DeckIntersection()
  {
    _deletePressed = false;
  }

  [RelayCommand]
  private void FullReport()
  {
    _deletePressed = false;
  }

  [RelayCommand]
  private void DeckDifference()
  {
    _deletePressed = false;
  }
}