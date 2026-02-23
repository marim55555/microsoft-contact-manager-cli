using System;
using Microsoft.ContactManager.CLI.Services;

namespace Microsoft.ContactManager.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactService contactService = new ContactService();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n==== Contact Manager ====");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. List Contacts");
                Console.WriteLine("3. View Contact");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. Search Contacts");
                Console.WriteLine("7. Filter Contacts by Date");
                Console.WriteLine("9. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        contactService.AddContact(name, phone, email);
                        Console.WriteLine("Contact added successfully.");
                        break;

                    case "2":
                        var allContacts = contactService.GetContacts();

                        if (allContacts.Count == 0)
                        {
                            Console.WriteLine("No contacts found.");
                        }
                        else
                        {
                            foreach (var c in allContacts)
                            {
                                Console.WriteLine("-------------------");
                                Console.WriteLine($"Id: {c.Id}");
                                Console.WriteLine($"Name: {c.Name}");
                                Console.WriteLine($"Phone: {c.Phone}");
                                Console.WriteLine($"Email: {c.Email}");
                                Console.WriteLine($"Created: {c.CreationDate}");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Enter Contact Id: ");
                        int viewId = int.Parse(Console.ReadLine());

                        var viewContact = contactService.GetContactById(viewId);

                        if (viewContact == null)
                        {
                            Console.WriteLine("Contact not found.");
                        }
                        else
                        {
                            Console.WriteLine("-----------");
                            Console.WriteLine($"Id: {viewContact.Id}");
                            Console.WriteLine($"Name: {viewContact.Name}");
                            Console.WriteLine($"Phone: {viewContact.Phone}");
                            Console.WriteLine($"Email: {viewContact.Email}");
                            Console.WriteLine($"Created: {viewContact.CreationDate}");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Contact Id to edit: ");
                        int editId;
                        if (int.TryParse(Console.ReadLine(), out editId))
                        {
                            var existingContact = contactService.GetContactById(editId);

                            if (existingContact == null)
                            {
                                Console.WriteLine("Contact not found. No updates made.");
                            }
                            else
                            {
                                Console.Write("New Name: ");
                                string newName = Console.ReadLine();

                                Console.Write("New Phone: ");
                                string newPhone = Console.ReadLine();

                                Console.Write("New Email: ");
                                string newEmail = Console.ReadLine();

                                bool updated = contactService.EditContact(editId, newName, newPhone, newEmail);

                                if (updated)
                                    Console.WriteLine("Contact updated successfully.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id input.");
                        }
                        break;

                    case "5":
                        Console.Write("Enter Contact Id to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());

                        bool removed = contactService.DeleteContact(deleteId);

                        if (removed)
                            Console.WriteLine("Contact deleted successfully.");
                        else
                            Console.WriteLine("Contact not found. Cannot delete.");
                        break;

                    case "6":
                        Console.Write("Enter name or email to search: ");
                        string searchKeyword = Console.ReadLine();

                        var foundContacts = contactService.SearchContacts(searchKeyword);

                        if (foundContacts.Count == 0)
                            Console.WriteLine("No contacts found.");
                        else
                        {
                            foreach (var c in foundContacts)
                            {
                                Console.WriteLine("-----------");
                                Console.WriteLine($"Id: {c.Id}");
                                Console.WriteLine($"Name: {c.Name}");
                                Console.WriteLine($"Phone: {c.Phone}");
                                Console.WriteLine($"Email: {c.Email}");
                                Console.WriteLine($"Created: {c.CreationDate}");
                            }
                        }
                        break;

                    case "7":
                        Console.Write("Enter date (yyyy-MM-dd): ");
                        DateTime filterDate;
                        if (DateTime.TryParse(Console.ReadLine(), out filterDate))
                        {
                            var filteredContacts = contactService.FilterContactsByDate(filterDate);

                            if (filteredContacts.Count == 0)
                                Console.WriteLine("No contacts found.");
                            else
                            {
                                foreach (var c in filteredContacts)
                                {
                                    Console.WriteLine("-----------");
                                    Console.WriteLine($"Id: {c.Id}");
                                    Console.WriteLine($"Name: {c.Name}");
                                    Console.WriteLine($"Phone: {c.Phone}");
                                    Console.WriteLine($"Email: {c.Email}");
                                    Console.WriteLine($"Created: {c.CreationDate}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        break;

                    case "9":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}