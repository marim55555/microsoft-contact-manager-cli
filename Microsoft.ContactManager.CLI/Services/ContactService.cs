using System.Collections.Generic;
using Microsoft.ContactManager.CLI.Models;

namespace Microsoft.ContactManager.CLI.Services
{
    public class ContactService
    {
        private List<Contact> _contacts;
        private int _currentId = 1;

        public ContactService()
        {
            _contacts = new List<Contact>();
        }

        public void AddContact(string name, string phone, string email)
        {
            Contact contact = new Contact
            {
                Id = _currentId,
                Name = name,
                Phone = phone,
                Email = email
            };

            _contacts.Add(contact);
            _currentId++;
        }
        public Contact GetContactById(int id)
        {
            foreach (var contact in _contacts)
            {
                if (contact.Id == id)
                {
                    return contact;
                }
            }

            return null;
        }
        public bool EditContact(int id, string name, string phone, string email)
        {
            var contact = GetContactById(id);

            if (contact == null)
                return false;

            contact.Name = name;
            contact.Phone = phone;
            contact.Email = email;

            return true;
        }
        public bool DeleteContact(int id)
        {
            var contact = GetContactById(id);
            if (contact == null)
                return false;

            _contacts.Remove(contact);
            return true;
        }
        public List<Contact> SearchContacts(string keyword)
        {
            var results = new List<Contact>();

            foreach (var contact in _contacts)
            {
                if ((contact.Name != null && contact.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (contact.Email != null && contact.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                {
                    results.Add(contact);
                }
            }

            return results;
        }
        public List<Contact> FilterContactsByDate(DateTime date)
        {
            var results = new List<Contact>();

            foreach (var contact in _contacts)
            {
                if (contact.CreationDate.Date == date.Date)
                    results.Add(contact);
            }

            return results;
        }
        public List<Contact> GetContacts()
        {
            return _contacts;
        }
    }
}