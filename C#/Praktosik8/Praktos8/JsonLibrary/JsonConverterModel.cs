using Newtonsoft.Json;

namespace JsonLibrary
{
    public class JsonConvertModel
    {
        public static void JsonSerialize<T>(T editedtest)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json"))
            {
                using (File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json")) { }
            }
            string json = JsonConvert.SerializeObject(editedtest);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json", json);
        }
        public static T JsonDeserialize<T>()
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json"))
            {
                using (File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json")) { }
            }
            string json = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Тестик.json");
            T testdeserialized = JsonConvert.DeserializeObject<T>(json);
            return testdeserialized;
        }
    }
}
