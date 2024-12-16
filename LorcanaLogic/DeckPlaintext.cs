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

  public void ProcessPlaintext(string plaintext)
  {
    Plaintext = plaintext;
    ProcessPlaintext();
  }
  
  public void ProcessPlaintext()
  {
    
  }
  
  public override string ToString()
  {
    return Name;
  }
}