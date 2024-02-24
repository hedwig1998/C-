using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_02_2024_slot_2
{
    abstract class Phone
    {
        public abstract void insertPhone(String name, String phone);
        public abstract void removePhone(String name);
        public abstract void updatePhone(String name, String newPhone);
        public abstract void searchPhone(String name);
        public abstract void sort();
    }
    class PhoneBook : Phone
    {
        private List<Contact> phoneList;
        public PhoneBook()
        {
            phoneList = new List<Contact>();
        }
        public override void insertPhone(string name, string phone)
        {
            Contact existPhone = phoneList.Find(contact => contact.Name == name);
            if (existPhone == null)
            {
                phoneList.Add(new Contact(name, phone));
            }else
            {
                if(!existPhone.PhoneNumber.Contains(phone))
                {
                    existPhone.PhoneNumber.Add(phone);
                }
            }

        }
        public override void removePhone(string name)
        {
            phoneList.RemoveAll(contact => contact.Name == name);
        }
        public override void searchPhone(string name)
        {
            Contact existPhone = phoneList.Find(contact => contact.Name == name);
            if (existPhone != null)
            {
                Console.WriteLine($"contact {name} found. Phone number is {string.Join("",existPhone.PhoneNumber)}");
            } else
            {
                Console.WriteLine($"$contact {name} not found");
            }
        }
        public override void updatePhone(string name, string newPhone)
        {
            Contact existPhone = phoneList.Find(contact => contact.Name == name);
            if (existPhone != null)
            {
                existPhone.PhoneNumber.Clear();
                existPhone.PhoneNumber.Add(newPhone);
            }
        }
        public override void sort()
        {
            phoneList = phoneList.OrderBy(contact => contact.Name).ToList();
        }
    }

    class Contact
    {
        public String Name { get; set; }
        public List<String> PhoneNumber { get; set; }
        public Contact(String name, String phoneNumber)
        {
            Name = name;
            PhoneNumber = new List<string> { phoneNumber };
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();

            phoneBook.insertPhone("Linh", "123456789");
            phoneBook.insertPhone("Minh", "987654321");
            phoneBook.insertPhone("Quan", "999888777");

            phoneBook.searchPhone("Linh");

            phoneBook.sort();

            phoneBook.searchPhone("Minh");
            phoneBook.searchPhone("Krem");
        }

    }
}

