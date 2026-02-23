using Microsoft.ContactManager.CLI.Services;
using Microsoft.ContactManager.CLI.Data;
using Microsoft.ContactManager.CLI.Application;

namespace Microsoft.ContactManager.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            IStorageService storage = new JsonStorageService();
            ContactService contactService = new ContactService(storage);
            var app = new Application.Application(contactService);
            app.Run(); 
        }
    }
}