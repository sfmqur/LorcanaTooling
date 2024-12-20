﻿// source: https://www.reddit.com/r/Lorcana/comments/1axc1jf/into_the_ink_lands_8_cases_768_booster_packs/
// opened 768 boxes
namespace LorcanaLogic.Contracts
{
    public  class Set3PullRates : ISetPullrates
    { 
        public int SetNo { get { return 3; } }
        public  double CommonsPerBox { get { return 6 * 24; } }

        public double UncommonsPerBox { get { return 3 * 24; } }

        public double RaresPerBox { get { return 32.47; } }

        public double SuperRaresPerBox { get { return 11.47; } }

        public double LegendarysPerBox { get { return 3.84; } }

        public double EnchantedPerBox { get { return 0.22; } }
        public double CommonFoilPerBox { get { return UncommonFoilPerBox*2; } } 

        public double UncommonFoilPerBox { get {
                return (24-EnchantedPerBox-SuperRareFoilPerBox-RareFoilPerBox-LegendaryFoilPerBox)/3;
            } }
        public double RareFoilPerBox { get { return 3.47; } }
        public double SuperRareFoilPerBox { get { return 1.13; } }
        public double LegendaryFoilPerBox { get { return 0.66; } }

    
        public double GetBoxPullrate(Rarity rarity, bool foil = false)
        {
            switch (rarity)
            {
                case Rarity.Common: return foil ? CommonFoilPerBox : CommonsPerBox;
                case Rarity.Uncommon: return foil ? UncommonFoilPerBox : CommonsPerBox;
                case Rarity.Rare: return foil ? RareFoilPerBox : RaresPerBox;
                case Rarity.SuperRare: return foil ? SuperRareFoilPerBox : SuperRaresPerBox;
                case Rarity.Legendary: return foil ? LegendaryFoilPerBox : LegendarysPerBox;
                case Rarity.Enchanted: return EnchantedPerBox;
                default: return 0; 
            }
        }

        public double GetPackPullrate(Rarity rarity, bool foil = false)
        {
            return GetBoxPullrate(rarity, foil)/24;
        }

        public double GetSlotProbability(Rarity rarity, bool foil = false)
        {
            if (foil)
            {
                switch(rarity)
                {
                    case Rarity.Common: return CommonFoilPerBox / 24; 
                    case Rarity.Uncommon: return UncommonFoilPerBox / 24;
                    case Rarity.Rare: return RareFoilPerBox / 24;
                    case Rarity.SuperRare: return SuperRareFoilPerBox / 24;
                    case Rarity.Legendary: return LegendaryFoilPerBox / 24;
                    case Rarity.Enchanted: return EnchantedPerBox / 24;
                    default: return 0;
                }
            }
            else
            {
                switch (rarity)
                {
                    case Rarity.Common: return CommonsPerBox / 24/6;
                    case Rarity.Uncommon: return UncommonsPerBox / 24/3;
                    case Rarity.Rare: return RaresPerBox / 24/2;
                    case Rarity.SuperRare: return SuperRaresPerBox / 24/2;
                    case Rarity.Legendary: return LegendarysPerBox / 24/2;
                    case Rarity.Enchanted: return EnchantedPerBox / 24;
                    default: return 0;
                }
            }
        }
    }
}
