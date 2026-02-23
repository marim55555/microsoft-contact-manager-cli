using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.ContactManager.CLI.Models;

namespace Microsoft.ContactManager.CLI.Data
{
    public class JsonStorageService : IStorageService
    {
        private string filePath = "contacts.json";

        public List<Contact> Load()
        {
            if (!File.Exists(filePath))
                return new List<Contact>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Contact>>(json);
        }

        public void Save(List<Contact> contacts)
        {
            string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}