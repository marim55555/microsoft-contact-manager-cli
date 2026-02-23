using System.Collections.Generic;
using Microsoft.ContactManager.CLI.Models;

namespace Microsoft.ContactManager.CLI.Data
{
    public interface IStorageService
    {
        List<Contact> Load();
        void Save(List<Contact> contacts);
    }
}