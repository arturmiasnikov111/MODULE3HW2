using ListPractise.Collections.Abstractions;
using ListPractise.Models.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ListPractise.Collections
{
    public class PhoneBook<T> : IPhoneBook<T> where T : IContact, IComparable
    {
        private Dictionary<CultureInfo, SortedLinkedList<T>> _culturedCollections;
        private Dictionary<CharType, SortedLinkedList<T>> _specialCollections;
        private CultureResolver _cultureResolver;

        public PhoneBook()
        {
            _cultureResolver = new CultureResolver();
            _culturedCollections = new Dictionary<CultureInfo, SortedLinkedList<T>>();
            _culturedCollections.Add(CultureInfo.GetCultureInfo("ru-RU"), new SortedLinkedList<T>());
            _culturedCollections.Add(CultureInfo.GetCultureInfo("en-GB"), new SortedLinkedList<T>());
            _specialCollections = new Dictionary<CharType, SortedLinkedList<T>>();
            _specialCollections.Add(CharType.Number, new SortedLinkedList<T>());
            _specialCollections.Add(CharType.Special, new SortedLinkedList<T>());
        }
        public void Add(T contact)
        {
            if (String.IsNullOrEmpty(contact.Name))
            {
                throw new ArgumentException("Name is null or empty");
            }

            var collection = DetermineCollection(contact.Name);
            collection.AddSorted(contact);
        }

        public SortedLinkedList<T> DetermineCollection(string name)
        {
            var cultureInfo = _cultureResolver.GetCultureInfo(name);

            if (cultureInfo == null)
            {
                if (Regex.IsMatch(name[0].ToString(), "[0-9]"))
                {
                    return _specialCollections[CharType.Number];
                }
                else
                {
                    return _specialCollections[CharType.Special];
                }
            }

            return _culturedCollections[cultureInfo];
        }

        public void _sort(ICollection collection)
        {
            throw new NotImplementedException();
        }
        
        public void showCultureCOllection()
        {
            var asd = _culturedCollections[CultureInfo.GetCultureInfo("en-GB")];
            // var asd = _specialCollections[CultureInfo.GetCultureInfo("ru-RU")];
            // var asd = _specialCollections[CharType.Special];
            foreach (var item in asd)
            {
                Console.WriteLine(item.Name);
            }
        }

        public IReadOnlyCollection<T> this[string key]
        {
            get
            {
                var collection = DetermineCollection(key);
                var result = new List<T>();

                foreach (var contact in collection)
                {
                    if (contact.Name.StartsWith(key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(contact);
                    }
                }

                return result;
            }
        }
    }
}
