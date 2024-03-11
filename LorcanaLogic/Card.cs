﻿using System.Diagnostics;
using LorcanaLogic.Contracts;

namespace LorcanaLogic
{
    public class Card : ICard
    {
        public string Name { get; }

        public int Set { get; }

        public int CardNo { get; }

        public Color Color { get; }

        public Rarity Rarity { get; }

        public decimal Price { get; set; }
        public decimal PriceFoil { get; set; }
        public bool Inkable { get; set; }
        public int Cost { get; set; }
        public int Strength { get; set; }
        public int Willpower { get; set; }
        public int Lore { get; set; }
        public string Text { get; set; }
        public CardType Type { get; set; }
        public string TypeText { get; set; }
        public int QuantNormal { get; set; }
        public int QuantFoil { get; set; }

        public Card(string name, int set, int cardNo, Color color, Rarity rarity, int quantNorm, int quantFoil, decimal price = 0, decimal foilPrice = 0)
        {
            Name = name;
            Set = set;
            CardNo = cardNo;
            Color = color;
            Rarity = rarity;
            Price = price;
            PriceFoil = foilPrice;
            QuantNormal = quantNorm;
            QuantFoil = quantFoil;
            Text = "";
            TypeText = "";
        }

        public override string ToString()
        {
            return Name; 
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return (obj as Card)?.Set == Set && (obj as Card)?.CardNo == CardNo;
        }
        public static bool operator <(Card card1, Card card2)
        {
            if (card1.Equals(card2)) return false;
            if (card1.Set < card2.Set) return true;
            if (card1.Set > card2.Set) return false;
            if (card1.CardNo < card2.CardNo) return true; //knoow that set is equal here. 
            return false;
        }
        public static bool operator >(Card card1, Card card2)
        {
            if (card1.Equals(card2)) return false;
            if (card1.Set > card2.Set) return true;
            if (card1.Set < card2.Set) return false;
            if (card1.CardNo > card2.CardNo) return true; //knoow that set is equal here. 
            return false; 
        }
        

        public static bool operator <=(Card card1, Card card2)
        {
            if (card1.Equals(card2)) return true;
            return card1 < card2;
        }
        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.Equals(card2)) return true;
            return card1 > card2;
        }
    }
}