using System.Collections.Generic;
using Microsoft.ContactManager.CLI.Models;
using Microsoft.ContactManager.CLI.Data;

namespace Microsoft.ContactManager.CLI.Services
{
    public class ContactService
    {
        private List<Contact> _contacts;
        private int _currentId = 1;
        private readonly IStorageService _storage;

        public ContactService(IStorageService storage)
        {
            _storage = storage;
            _contacts = _storage.Load();
            if (_contacts.Count > 0)
                _currentId = _contacts[^1].Id + 1;
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

        public List<Contact> GetContacts()
        {
            return _contacts;
        }

        public Contact GetContactById(int id)
        {
            foreach (var contact in _contacts)
            {
                if (contact.Id == id)
                    return contact;
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
            List<Contact> result = new List<Contact>();
            foreach (var contact in _contacts)
            {
                if (contact.Name.Contains(keyword) || contact.Email.Contains(keyword))
                    result.Add(contact);
            }
            return result;
        }

        public List<Contact> FilterContactsByDate(DateTime date)
        {
            List<Contact> result = new List<Contact>();
            foreach (var contact in _contacts)
            {
                if (contact.CreationDate.Date == date.Date)
                    result.Add(contact);
            }
            return result;
        }

        public void SaveContacts()
        {
            _storage.Save(_contacts);
        }
    }
}