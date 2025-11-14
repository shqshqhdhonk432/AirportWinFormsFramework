using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

namespace AirportWinFormsFramework.Models
{
    public class Airport
    {
        // BindingList — список, умеющий “подсказывать” таблице об изменениях
        public BindingList<Tariff> Tariffs { get; } = new BindingList<Tariff>();

        public void AddTariff(Tariff t)
        {
            if (Tariffs.Any(x => string.Equals(x.Destination, t.Destination, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"Tariff for '{t.Destination}' already exists.");
            Tariffs.Add(t);
        }

        public void UpdateTariff(string originalDestination, Tariff updated)
        {
            var existing = Tariffs.FirstOrDefault(x =>
                string.Equals(x.Destination, originalDestination, StringComparison.OrdinalIgnoreCase));

            if (existing == null)
                throw new InvalidOperationException("Original tariff not found.");

            // если поменяли Destination — снова проверим уникальность
            if (!string.Equals(originalDestination, updated.Destination, StringComparison.OrdinalIgnoreCase) &&
                Tariffs.Any(x => string.Equals(x.Destination, updated.Destination, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Tariff for '{updated.Destination}' already exists.");
            }

            existing.Destination = updated.Destination;
            existing.BasePrice = updated.BasePrice;
            existing.StrategyType = updated.StrategyType;
            existing.DiscountPercent = updated.DiscountPercent;
        }

        public void RemoveTariff(string destination)
        {
            var t = Tariffs.FirstOrDefault(x =>
                string.Equals(x.Destination, destination, StringComparison.OrdinalIgnoreCase));
            if (t != null) Tariffs.Remove(t);
        }

        public string FindMaxPriceDestination()
        {
            if (Tariffs.Count == 0)
                throw new InvalidOperationException("Tariff list is empty.");

            // В .NET Framework нет MaxBy → берём через OrderByDescending + First
            var max = Tariffs.OrderByDescending(t => t.FinalPrice).First();
            return max.Destination;
        }

        public void SortBy(string propertyName, ListSortDirection direction)
        {
            IEnumerable<Tariff> sorted;

            if (propertyName == nameof(Tariff.Destination))
            {
                sorted = direction == ListSortDirection.Ascending
                    ? Tariffs.OrderBy(t => t.Destination, StringComparer.OrdinalIgnoreCase)
                    : Tariffs.OrderByDescending(t => t.Destination, StringComparer.OrdinalIgnoreCase);
            }
            else if (propertyName == nameof(Tariff.BasePrice))
            {
                sorted = direction == ListSortDirection.Ascending
                    ? Tariffs.OrderBy(t => t.BasePrice)
                    : Tariffs.OrderByDescending(t => t.BasePrice);
            }
            else if (propertyName == "FinalPrice")
            {
                sorted = direction == ListSortDirection.Ascending
                    ? Tariffs.OrderBy(t => t.FinalPrice)
                    : Tariffs.OrderByDescending(t => t.FinalPrice);
            }
            else
            {
                sorted = Tariffs; // на всякий
            }

            var temp = sorted.ToList();

            Tariffs.RaiseListChangedEvents = false;
            Tariffs.Clear();
            foreach (var t in temp) Tariffs.Add(t);
            Tariffs.RaiseListChangedEvents = true;
            Tariffs.ResetBindings();
        }
    }
}
