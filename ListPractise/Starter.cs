using ListPractise.Collections;
using ListPractise.Models;

namespace ListPractise
{
    public class Starter
    {

        public void Run()
        {
            var phoneBook = new PhoneBook<Contact>();
            
            phoneBook.Add(new Contact() { Name = "Igor", LastName = "Serduik" });
            phoneBook.Add(new Contact() { Name = "Boris", LastName = "Serduik" });
            phoneBook.Add(new Contact() { Name = "Igor", LastName = "Serduik" });
            phoneBook.Add(new Contact() { Name = "Ilya", LastName = "Добродушный" });
            phoneBook.Add(new Contact() { Name = "Ignat", LastName = "Bobro" });
            phoneBook.Add(new Contact() { Name = "Bggg", LastName = "Graph" });
            phoneBook.Add(new Contact() { Name = "Andrei", LastName = "Bobro" });
            phoneBook.Add(new Contact() { Name = "Boris", LastName = "Bobro" });
            phoneBook.Add(new Contact() { Name = "123", LastName = "Bobro" });
            phoneBook.Add(new Contact() { Name = "#@", LastName = "Bobro" });
            phoneBook.Add(new Contact() { Name = "Igor1", LastName = "Bobro" });
            phoneBook.Add(new Contact() { Name = "Олег", LastName = "Сам" });

            phoneBook.showCultureCOllection();

            var x = phoneBook["I"];

        }
    }
}