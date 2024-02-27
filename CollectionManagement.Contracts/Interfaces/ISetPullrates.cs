namespace CollectionManagement.Contracts
{
    public interface ISetPullrates
    { // pull rates are number of each rarity in a 24 set box. 
        int SetNo { get; }
        double CommonsPerBox { get; }
        double UncommonsPerBox { get; }
        double RaresPerBox { get; }
        double SuperRaresPerBox { get; }
        double LegendarysPerBox { get; }
        double EnchantedPerBox { get; }
        double CommonFoilPerBox { get; }
        double UncommonFoilPerBox { get; }
        double RareFoilPerBox { get; }
        double SuperRareFoilPerBox { get; }
        double LegendaryFoilPerBox { get; }

        /// <summary>
        /// average number of rarity that occurs in a box of 24 packs
        /// </summary>
        /// <param name="rarity"></param>
        /// <param name="foil"></param>
        /// <returns></returns>
        double GetBoxPullrate(Rarity rarity, bool foil = false);
        /// <summary>
        /// average number of rarity that occurs in a pack. 
        /// </summary>
        /// <param name="rarity"></param>
        /// <param name="foil"></param>
        /// <returns></returns>
        double GetPackPullrate(Rarity rarity, bool foil = false);
    }
}