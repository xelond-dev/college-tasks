using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Praktosik_4
{
    internal class JsonConvert
    {
        public static void JsonSerialize<T>(T editedtest)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json"))
            {
                using (File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json")) { }
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(editedtest);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json", json);
        }
        public static T JsonDeserialize<T>()
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json"))
            {
                using (File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json")) { }
            }
            string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json");
            T testdeserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            return testdeserialized;
        }
    }
}
