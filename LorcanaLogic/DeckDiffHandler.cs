using System.Collections.ObjectModel;

namespace LorcanaLogic;

public class DeckDiffHandler
{
  private readonly ObservableCollection<DeckPlaintext> _constructedDecks;

  public DeckDiffHandler(ObservableCollection<DeckPlaintext> constructedDecks)
  {
    _constructedDecks = constructedDecks;
  }

  /// <summary>
  /// This report details the shared copies of cards between one deck and the others. 
  /// </summary>
  /// <returns></returns>
  public string GenerateIntersections()
  {
    var output = "Intersection Report:\n";
    return output;
  }

  /// <summary>
  /// This report details what cards are unique for that particular deck
  /// </summary>
  /// <returns></returns>
  public string GenerateDiffs()
  {
    var output = "Differential Report:\n";
    return output;
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