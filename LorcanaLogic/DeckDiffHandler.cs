using System.Collections.ObjectModel;

namespace LorcanaLogic;

public class DeckDiffHandler
{
  public ObservableCollection<DeckPlaintext> ConstructedDecks;

  public DeckDiffHandler(ObservableCollection<DeckPlaintext> constructedDecks)
  {
    ConstructedDecks = constructedDecks;
  }

  /// <summary>
  /// This report details the shared copies of cards between one deck and the others. 
  /// </summary>
  /// <returns></returns>
  public string GenerateIntersections()
  {
    NullCleaning();
    var output = "Intersection Report:\n";
    foreach (var deck in ConstructedDecks)
    {
      output += $"{deck}:\n";
      foreach (var deck2 in ConstructedDecks)
      {
        if (deck == deck2) continue;
        var intersect = deck.Cards.Intersect(deck2.Cards);
        if (!intersect.Any()) continue;
        output += $"\t{deck2}:\n";
        output += IntersectionQuantityString(intersect, deck, deck2);
      }

      output += "\n";
    }

    return output;
  }

  /// <summary>
  /// This report details what cards are unique for that particular deck
  /// </summary>
  /// <returns></returns>
  public string GenerateDiffs(DeckPlaintext deck1, DeckPlaintext deck2)
  {
    NullCleaning();
    var output = "Difference Report:\n";
    var intersect = deck1.Cards.Intersect(deck2.Cards);
    var diff1 = deck1.Cards.Except(intersect);
    var diff2 = deck2.Cards.Except(intersect);
    output += DiffQuantityString(intersect, deck1, deck2, diff1);
    output += DiffQuantityString(intersect, deck2, deck1, diff2);
    return output;
  }

  private string IntersectionQuantityString(IEnumerable<CardCount> intersections, DeckPlaintext deck1,
    DeckPlaintext deck2)
  {
    var output = "";
    foreach (var intersection in intersections)
    {
      var quantity1 = deck1.Cards.FirstOrDefault(card => card.Name == intersection.Name)?.Count;
      var quantity2 = deck2.Cards.FirstOrDefault(card => card.Name == intersection.Name)?.Count;
      var quantity = quantity1 < quantity2 ? quantity1 : quantity2;
      output += $"\t\t{quantity}/{quantity1} {intersection}\n";
    }

    return output;
  }

  /// <summary>
  /// Diff string for deck1.
  /// </summary>
  /// <param name="intersections"></param>
  /// <param name="deck1"></param>
  /// <param name="deck2"></param>
  /// <param name="diff1"></param>
  /// <returns></returns>
  private string DiffQuantityString(IEnumerable<CardCount> intersections, DeckPlaintext deck1,
    DeckPlaintext deck2, IEnumerable<CardCount> diff1)
  {
    var output = $"{deck1.Name}:\n";
    foreach (var card in diff1)
    {
      output += $"\t{card.Count} {card.Name}\n";
    }

    foreach (var intersection in intersections)
    {
      var quantity1 = deck1.Cards.FirstOrDefault(card => card.Name == intersection.Name)?.Count;
      var quantity2 = deck2.Cards.FirstOrDefault(card => card.Name == intersection.Name)?.Count;
      if (quantity1 > quantity2)
      {
        output += $"\t{quantity1 - quantity2} {intersection.Name}\n";
      }
    }

    output += "\n";
    return output;
  }

  /// <summary>
  /// Clean Constructed Decks of Cards with null names.
  /// </summary>
  private void NullCleaning()
  {
    foreach (var deck in ConstructedDecks)
    {
      var nullCards = deck.Cards.Where(card => card.Name is null).ToList();
      foreach (var nullCard in nullCards)
      {
        deck.Cards.Remove(nullCard);
      }
    }
  }
}