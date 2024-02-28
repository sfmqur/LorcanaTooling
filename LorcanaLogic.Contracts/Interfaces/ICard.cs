namespace LorcanaLogic.Contracts
{
    public interface ICard
    {
        string Name { get;  }
        int Set { get; }
        int CardNo {  get; }
        Color Color { get; }
        Rarity Rarity {  get; }
        decimal Price { get; set; }
        decimal PriceFoil { get; set; }
        int QuantNormal { get; set; }
        int QuantFoil { get; set; }
        bool Inkable { get; set; }
        int Cost { get; set; }
        int Strength { get; set; }
        int Willpower { get; set; }
        int Lore { get; set; }
        string Text { get; set; }  
        CardType Type { get; set; }
        string TypeText {  get; set; }
    }
}
