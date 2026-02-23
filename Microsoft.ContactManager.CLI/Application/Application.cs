using Microsoft.ContactManager.CLI.Services;

namespace Microsoft.ContactManager.CLI.Application
{
    public class Application
    {
        private readonly ContactService _contactService;
        private readonly MenuHandler _menu;

        public Application(ContactService contactService)
        {
            _contactService = contactService;
            _menu = new MenuHandler();
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                _menu.Show();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddContact(); break;
                    case "2": ListContacts(); break;
                    case "3": ViewContact(); break;
                    case "4": EditContact(); break;
                    case "5": DeleteContact(); break;
                    case "6": SearchContacts(); break;
                    case "7": FilterContactsByDate(); break;
                    case "8": SaveContacts(); break;
                    case "9": isRunning = false; break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        private void AddContact()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            _contactService.AddContact(name, phone, email);
            _contactService.SaveContacts();
            Console.WriteLine("Contact added successfully.");
        }

        private void ListContacts()
        {
            var contacts = _contactService.GetContacts();

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            foreach (var c in contacts)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"Id: {c.Id}");
                Console.WriteLine($"Name: {c.Name}");
                Console.WriteLine($"Phone: {c.Phone}");
                Console.WriteLine($"Email: {c.Email}");
                Console.WriteLine($"Created: {c.CreationDate}");
            }
        }

        private void ViewContact()
        {
            Console.Write("Enter Contact Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            var contact = _contactService.GetContactById(id);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine($"Id: {contact.Id}");
            Console.WriteLine($"Name: {contact.Name}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Created: {contact.CreationDate}");
        }

        private void EditContact()
        {
            Console.Write("Enter Contact Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            var contact = _contactService.GetContactById(id);

            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.Write("New Name: ");
            string name = Console.ReadLine();

            Console.Write("New Phone: ");
            string phone = Console.ReadLine();

            Console.Write("New Email: ");
            string email = Console.ReadLine();

            _contactService.EditContact(id, name, phone, email);
            _contactService.SaveContacts();
            Console.WriteLine("Contact updated successfully.");
        }

        private void DeleteContact()
        {
            Console.Write("Enter Contact Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            bool deleted = _contactService.DeleteContact(id);

            if (!deleted)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            _contactService.SaveContacts();
            Console.WriteLine("Contact deleted successfully.");
        }

        private void SearchContacts()
        {
            Console.Write("Enter search keyword: ");
            string keyword = Console.ReadLine();

            var results = _contactService.SearchContacts(keyword);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching contacts found.");
                return;
            }

            foreach (var c in results)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"Id: {c.Id}");
                Console.WriteLine($"Name: {c.Name}");
                Console.WriteLine($"Phone: {c.Phone}");
                Console.WriteLine($"Email: {c.Email}");
            }
        }

        private void FilterContactsByDate()
        {
            Console.Write("Enter date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Invalid date.");
                return;
            }

            var results = _contactService.FilterContactsByDate(date);

            if (results.Count == 0)
            {
                Console.WriteLine("No contacts found on that date.");
                return;
            }

            foreach (var c in results)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"Id: {c.Id}");
                Console.WriteLine($"Name: {c.Name}");
                Console.WriteLine($"Phone: {c.Phone}");
                Console.WriteLine($"Email: {c.Email}");
            }
        }

        private void SaveContacts()
        {
            _contactService.SaveContacts();
            Console.WriteLine("Contacts saved successfully.");
        }
    }
}