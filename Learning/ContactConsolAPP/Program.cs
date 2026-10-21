using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBusinessLayer;
namespace ContactConsolAPP
{
    internal class Program
    {
        static void testFindContact(int ID)
        {
            clsContact contact = clsContact.Find(ID);

            if (contact != null) {

                Console.WriteLine(contact.FirstName+" "+ contact.LastName);
                Console.WriteLine(contact.Phone);
                Console.WriteLine(contact.CountryID);
                Console.WriteLine(contact.Address);
                Console.WriteLine(contact.DateOfBirth);
                Console.WriteLine(contact.Email);
                Console.WriteLine(contact.ID);
            }

            else
            {
                Console.WriteLine($"Contact[{ID}] is not found");
            }
        }

        static void testAddNewContact() {
            clsContact contact = new clsContact();
            contact.FirstName = "Saied";
            contact.LastName = "Nasef";
            contact.Email = "saied@gmail.com";
            contact.Address = "Address1";
            contact.Phone = "01928383";
            contact.ImagePath = "";
            contact.DateOfBirth = new DateTime(2003, 6, 26,8,35,0);
            contact.CountryID = 1;
            if (contact.Save())
            {
                Console.WriteLine("Contact Added Successfully with id= "+contact.ID);
            }
            else
            {
                {
                    Console.WriteLine(" Failed");
                }
            }


        }
        static void testUpdateContact(int ID)
       
        {
            clsContact contact = clsContact.Find(ID);
            if (contact != null)
            {
                contact.FirstName = "Ali";
                contact.LastName = "Maher";
                contact.Address = "Address2";
                contact.Phone = "01289397";
                contact.ImagePath = "";
                contact.DateOfBirth = new DateTime(2001, 9, 16, 8, 35, 0);
                contact.CountryID = 2;

                if (contact.Save())
                {
                    Console.WriteLine("Contact Updated Successfully");
                }

            }
            else
            {
                Console.WriteLine($"Contact[{ID}] is not found");
                
            }

           

        }

        static void testDeleteContact(int ID)
        {
            if (clsContact.IsContactExist(ID))
            {
                if (clsContact.DeleteContact(ID))
                    Console.WriteLine("Deleted Successfully");
                else
                    Console.WriteLine("Deleted Failed");
            }
            else
            {
                Console.WriteLine("The contatc with id = " + ID + " is not found");
            }

            
          
        }

        static void ListContacts()
        {
            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("_________________________________________________________________________________________________________________________");
            Console.WriteLine($"{"ID", -4}  | {"FirstName",-10}  | {"LastName",-12}  | {"Address",-30}  | {"Email",-25}  | {"Phone",-15}  | {"CountryID",-5}"  );

            Console.WriteLine("_________________________________________________________________________________________________________________________");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"],-5} | {row["FirstName"],-10} | {row["LastName"],-12}  |" +
                    $"  {row["Address"],-30} |" +
                    $"  {row["Email"],-25} |"+
                    $"  {row["Phone"],-15}  |" +
                    $"  {row["CountryID"],-5}  |");

            }


        }

        static  void testIsContactExist(int ID)
        {

            if (clsContact.IsContactExist(ID))
            {
                Console.WriteLine("Yes,Contact Is found");
            }
            else
            {
                Console.WriteLine("No,Contatc is not found");
            }

        }

      static void testFindCountryByName(string CountryName)
        {
            clsCountry country = clsCountry.Find(CountryName);

            if (country != null)
            {
                Console.WriteLine($"Country Name : {country.CountryName}");
                Console.WriteLine($"CountryID    : {country.CounntryID}");
                Console.WriteLine($"Code    : {country.Code}");
                Console.WriteLine($"PhoneCode    : {country.PhoneCode}");

            }

            else
            {
                Console.WriteLine($"Country with name {CountryName} is not found");
            }

        }
        static void testFindCountryByID(int CountryID)
        {
            clsCountry country = clsCountry.Find(CountryID);
           
            if (country != null)
            {
                Console.WriteLine($"Country Name : {country.CountryName}");
                Console.WriteLine($"CountryID    : {country.CounntryID}");
                Console.WriteLine($"Code    : {country.Code}");
                Console.WriteLine($"PhoneCode    : {country.PhoneCode}");
            }

            else
            {
                Console.WriteLine($"Country with ID {CountryID} is not found");
            }

        }

        static void testIsCountryExist(string Name)
        {

            if (clsCountry.IsCountryExist(Name))
            {
                Console.WriteLine("Yes,Country Is found");
            }
            else
            {
                Console.WriteLine("No,Country is not found");
            }

        }

      
        static void Main(string[] args)
        {
            //testFindContact(2);
            //testAddNewContact();
            //testUpdateContact(16);
            //testDeleteContact(100);
            //ListContacts();
           // testIsContactExist(2);
            //testFindCountryByName("canada");
             //testIsCountryExist("Canada");
           //testFindCountryByID(4);
           clsScreen.Login();
        }
    }
}
