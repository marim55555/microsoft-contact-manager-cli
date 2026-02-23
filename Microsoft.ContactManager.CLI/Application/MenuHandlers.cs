namespace Microsoft.ContactManager.CLI.Application
{
    public class MenuHandler
    {
        public void Show()
        {
            Console.WriteLine("\n==== Contact Manager ====");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. List Contacts");
            Console.WriteLine("3. View Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Search Contacts");
            Console.WriteLine("7. Filter Contacts by Date");
            Console.WriteLine("8. Save Contacts");
            Console.WriteLine("9. Exit");
            Console.Write("Choose option: ");
        }
    }
}