namespace LorcanaLogic;

public class CardCount : IEquatable<CardCount>
{
  public string Name;
  public int Count;

  public CardCount(string name, int count)
  {
    Name = name;
    Count = count;
  }

  public override string ToString()
  {
    return Name;
  }


  public bool Equals(CardCount? other)
  {
    if (other is null) return false;
    if (ReferenceEquals(this, other)) return true;
    return Name == other.Name;
  }

  public override bool Equals(object? obj)
  {
    if (obj is null) return false;
    if (ReferenceEquals(this, obj)) return true;
    if (obj.GetType() != GetType()) return false;
    return Equals((CardCount)obj);
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(Name);
  }
}