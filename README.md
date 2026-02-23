# Microsoft Contact Manager CLI

A **Command-Line Interface (CLI)** application for managing contacts in C# using .NET.  
Allows adding, editing, deleting, viewing, searching, and filtering contacts. All data is stored in a **contacts.json** file.

---

## Requirements

- **.NET SDK** (version 6 or higher recommended)  
  Check with:
  ```bash
  dotnet --version

Any C# IDE or editor (Visual Studio, VS Code, etc.)

Clone and Build
git clone https://github.com/marim55555/microsoft-contact-manager-cli.git
cd microsoft-contact-manager-cli
dotnet build
Run the Application
dotnet run --project Microsoft.ContactManager.CLI

After running, a menu will appear:

Add Contact

List Contacts

View Contact

Edit Contact

Delete Contact

Search Contacts

Filter Contacts by Date

Save Contacts

Exit

Usage Examples

Add a Contact

Choose option: 1
Name: Ahmed Ali
Phone: 01012345678
Email: ahmed@example.com

List Contacts

Choose option: 2
-------------------
Id: 1
Name: Ahmed Ali
Phone: 01012345678
Email: ahmed@example.com
Created: 2026-02-24 14:30:12

Search Contacts

Choose option: 6
Enter search keyword: Ahmed
-------------------
Id: 1
Name: Ahmed Ali
Email: ahmed@example.com

Filter by Date

Choose option: 7
Enter date (yyyy-MM-dd): 2026-02-24
-------------------
Id: 1
Name: Ahmed Ali
Email: ahmed@example.com
Data Storage

All contacts are saved in contacts.json automatically when adding, editing, or deleting.
Option 8 allows manual save.

Notes

Ensure write permissions in the project folder for creating contacts.json.

The program uses JsonStorageService for storage.

Easily extend functionality via Services or Application classes.

License

Not specified. Optional: MIT License

© 2026 Marym

---
