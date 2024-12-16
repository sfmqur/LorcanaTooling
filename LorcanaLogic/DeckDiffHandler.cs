using System.Collections.ObjectModel;

namespace LorcanaLogic;

public class DeckDiffHandler
{
  private readonly ObservableCollection<DeckPlaintext> _decks;
  private readonly ObservableCollection<DeckPlaintext> _constDecks;

  public DeckDiffHandler(ObservableCollection<DeckPlaintext> decks, ObservableCollection<DeckPlaintext> constDecks)
  {
    _decks = decks;
    _constDecks = constDecks;
  }

  /// <summary>
  /// This report details the shared copies of cards between one deck and the others. 
  /// </summary>
  /// <returns></returns>
  public string GenerateIntersections()
  {
    
  }

  /// <summary>
  /// This report details what cards are unique for that particular deck
  /// </summary>
  /// <returns></returns>
  public string GenerateDiffs()
  {
    
  }

  /// <summary>
  /// Generates all reports
  /// </summary>
  /// <returns></returns>
  public string GenerateFullReport()
  {
    return GenerateIntersections() + "\n" + GenerateDiffs();
  }
}