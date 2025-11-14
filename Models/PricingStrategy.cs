namespace AirportWinFormsFramework.Models
{
    public enum StrategyType
    {
        Standard = 0,  // итоговая цена = базовая
        Discount = 1   // итоговая цена = базовая * (1 - скидка/100)
    }
}
