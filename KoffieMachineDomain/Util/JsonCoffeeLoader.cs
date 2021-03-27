using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Config;
using Newtonsoft.Json;

namespace KoffieMachineDomain.Util
{
    public static class JsonCoffeeLoader
    {
        private const string CoffeeJsonFileName = "CustomCoffee";

        private static readonly string JsonText;

        static JsonCoffeeLoader()
        {
            var directoryInfo = Directory.GetParent(Environment.CurrentDirectory).Parent;

            if (directoryInfo is null)
            {
                throw new DirectoryNotFoundException(
                    $"Cannot find parent directory of {Directory.GetParent(Environment.CurrentDirectory).FullName}");
            }

            var currDirectory = directoryInfo.FullName;
            var path = Path.Combine(currDirectory, $@"{CoffeeJsonFileName}.json");

            JsonText = File.ReadAllText(path);
        }

        public static IEnumerable<JsonCoffee> GetCoffees() =>
            JsonConvert.DeserializeObject<JsonCoffeeCollection>(JsonText).Coffees;
    }
}
