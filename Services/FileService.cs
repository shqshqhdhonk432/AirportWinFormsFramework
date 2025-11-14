using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using AirportWinFormsFramework.Models;

namespace AirportWinFormsFramework.Services
{
    public static class FileService
    {
        public static void Save(string path, IEnumerable<Tariff> tariffs)
        {
            var json = JsonConvert.SerializeObject(tariffs, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static List<Tariff> Load(string path)
        {
            var json = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Tariff>>(json) ?? new List<Tariff>();
            return list;
        }
    }
}
