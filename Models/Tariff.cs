using System;
using Newtonsoft.Json;

namespace AirportWinFormsFramework.Models
{
    public class Tariff : IComparable<Tariff>
    {
        public string Destination { get; set; } = string.Empty; // уникальное имя направления
        public double BasePrice { get; set; }                    // базовая цена (>= 0)
        public StrategyType StrategyType { get; set; } = StrategyType.Standard;
        public double DiscountPercent { get; set; } = 0;         // 0..100 для Discount

        [JsonIgnore] // не пишем вычисляемое свойство в файл
        public double FinalPrice
        {
            get
            {
                if (StrategyType == StrategyType.Discount)
                    return BasePrice * (1.0 - DiscountPercent / 100.0);
                return BasePrice;
            }
        }

        public Tariff() { }

        public Tariff(string destination, double basePrice, StrategyType type, double discountPercent = 0)
        {
            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentException("Destination cannot be empty.");

            if (basePrice < 0)
                throw new ArgumentException("Base price cannot be negative.");

            if (type == StrategyType.Discount && (discountPercent < 0 || discountPercent > 100))
                throw new ArgumentException("Discount must be between 0 and 100%.");

            Destination = destination.Trim();
            BasePrice = basePrice;
            StrategyType = type;
            DiscountPercent = discountPercent;
        }

        // Для сортировки по FinalPrice (как operator< в C++)
        public int CompareTo(Tariff other)
        {
            if (other == null) return 1;
            return FinalPrice.CompareTo(other.FinalPrice);
        }
    }
}
