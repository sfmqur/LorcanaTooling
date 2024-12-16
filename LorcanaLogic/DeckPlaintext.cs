namespace LorcanaLogic;

public class DeckPlaintext
{
  public DeckPlaintext(string name, string plaintext)
  {
    Name = name;
    Plaintext = plaintext;
  }

  public string Name { get; }
  public string Plaintext { get; set; }

  public override string ToString()
  {
    return Name;
  }
}