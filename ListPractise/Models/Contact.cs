using ListPractise.Models.Abstractions;
using System;

namespace ListPractise.Models
{
    public class Contact : IContact, IComparable
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public int CompareTo(object? obj)
        {
            var contact = obj as Contact;
            return Name.CompareTo(contact.Name);
        }
    }
}
