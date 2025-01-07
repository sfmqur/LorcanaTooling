namespace LorcanaLogic;

public class DeckPlaintext
{
  public DeckPlaintext(string name, string plaintext)
  {
    Name = name;
    Plaintext = plaintext.Trim();
    ProcessPlaintext();
  }

  public string Name { get; }
  public string Plaintext { get; set; }
  
  public List<CardCount> Cards { get; } = [];

  public void ProcessPlaintext(string plaintext)
  {
    Plaintext = plaintext;
    ProcessPlaintext();
  }

  public void ProcessPlaintext()
  {
    Cards.Clear();
    var splitLines = Plaintext.Split('\n');
    for (var i = 0; i < splitLines.Length; i++)
    {
      splitLines[i] = splitLines[i].Trim();
      var firstSpace = splitLines[i].IndexOf(' ');
      if (firstSpace == -1) throw new FormatException($"Invalid first space after card count on line {i + 1}: {splitLines[i]}");
      var number = splitLines[i].Substring(0, firstSpace);
      var cardName = splitLines[i].Substring(firstSpace + 1);
      int numCards;
      var parseSuccess = int.TryParse(number, out numCards);
      if (!parseSuccess) throw new FormatException($"Invalid card count integer Format on line {i + 1}: {splitLines[i]}");
      Cards.Add(new CardCount(cardName, numCards));
    }
  }

  public override string ToString()
  {
    return Name;
  }
}