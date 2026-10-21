using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ContactConsolAPP
{
    internal class clsScreen
    {

        private enum enMainMinueScreen
        {
            enAddNewContact=1,
            enUpdateContact,
            enDeleteContact,
            enFindContact,
            enPrintAllContact,
            Exit


        }
        static private short GetValidate(string Message, short MinNumber, short MaxNumber)
        {
            short Number = 0;
           
         while (true)
            {
                Console.WriteLine(
                Message);
               string input = Console.ReadLine();

                if (short.TryParse(input,out Number))
                {
                    if (Number >= MinNumber && Number <= MaxNumber)
                        return Number;

                }


            }




        }

        static public void ShowMainMenue()
        {
            clsMinueScrren.ShowMainMinueScreen("Main Minue Screen");
            Console.WriteLine();
            Console.WriteLine("{0,58}", "[1] : Add New Contact");
            Console.WriteLine("{0,57}", "[2] : Update Contact");
            Console.WriteLine("{0,57}", "[3] : Delete Contact");
            Console.WriteLine("{0,55}", "[4] : Find Contact");
            Console.WriteLine("{0,60}", "[5] : Print All Contact");
            Console.WriteLine("{0,47}", "[6] : Exit");



        }

        static private clsContact ReadContactInfo()
        {
            clsContact contact = new clsContact();

            Console.WriteLine("Enter firstName: ");
            contact.FirstName = Console.ReadLine();

            Console.WriteLine("Enter LastName: ");
            contact.LastName = Console.ReadLine();

            Console.WriteLine("Enter Addres: ");
            contact.Address= Console.ReadLine();

            Console.WriteLine("Enter Phone: ");
            contact.Phone= Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            contact.Email = Console.ReadLine();

            contact.CountryID = GetValidate("Enter CountryID: ", 1, 5);


            Console.WriteLine("Enter your date of birth with time (YYYY-MM-DD HH:mm:ss): ");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth)) ;
            {
                Console.WriteLine("Invalid date format,Please try again(YYYY-MM-DD HH:mm:ss)");
            }
            contact.DateOfBirth = dateOfBirth;

            contact.ImagePath = Console.ReadLine();
            return contact;
        }
        static void AddNewContact()
        {
            Console.Clear();
            clsMinueScrren.ShowMainMinueScreen("Add New Contact");
            clsContact contact=  ReadContactInfo();
            if (contact.Save())
            {
                Console.WriteLine("Contact Added Successfully with id= " + contact.ID);
            }
            else
            {
                {
                    Console.WriteLine(" Failed");
                }
            }

        }
        static private void UpdateContact()
        {
            Console.Clear();
            clsMinueScrren.ShowMainMinueScreen("Update Contact");
            int ContactID = 0;
            Console.WriteLine("Enter ContactID: ");
            while (!int.TryParse(Console.ReadLine(), out ContactID))
                {
                Console.WriteLine("Enter ContactID: ");

                 }

            clsContact contact = clsContact.Find(ContactID);
            if (contact != null)
            {

                contact = ReadContactInfo();

                Console.WriteLine("Contact Updated Successfully");
            }
            else
            {
                Console.WriteLine($"Contact[{ContactID}] is not found");

            }

        } 

        static private void DeleteContact()
        {
            Console.Clear();
            clsMinueScrren.ShowMainMinueScreen("Delete Contact");

            int ID = 0;
            Console.WriteLine("Enter ContactID: ");
            while (!int.TryParse(Console.ReadLine(),out ID))
            {
                Console.WriteLine("Enter ContactID: ");
            }
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

        static private void FindContact()
        {
            Console.Clear();
            clsMinueScrren.ShowMainMinueScreen("Find Contacts");

            int ID = 0;
            Console.WriteLine("Enter ContactID: ");
            while (!int.TryParse(Console.ReadLine(), out ID))
            {
                Console.WriteLine("Enter ContactID: ");
            }
            clsContact contact = clsContact.Find(ID);

            Console.WriteLine("_________________________________________________________________________________________________________________________");
            Console.WriteLine($"{"ID",-4}  | {"FirstName",-10}  | {"LastName",-12}  | {"Address",-30}  | {"Email",-25}  | {"Phone",-15}  | {"CountryID",-5}");

            Console.WriteLine("_________________________________________________________________________________________________________________________");
            Console.WriteLine($"{contact.ID,-4}  | {contact.FirstName,-10}  | {contact.LastName,-12} " +
                $" | {contact.Address,-30}  | {contact.Email,-25}  | {contact.Phone,-15}  | {contact.CountryID,-5}");
            Console.WriteLine("_________________________________________________________________________________________________________________________");

        }

        private static void ListContacts()
        {
            Console.Clear();
            clsMinueScrren.ShowMainMinueScreen("List Contacts");

            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("_________________________________________________________________________________________________________________________");
            Console.WriteLine($"{"ID",-4}  | {"FirstName",-10}  | {"LastName",-12}  | {"Address",-30}  | {"Email",-25}  | {"Phone",-15}  | {"CountryID",-5}");

            Console.WriteLine("_________________________________________________________________________________________________________________________");
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"],-5} | {row["FirstName"],-10} | {row["LastName"],-12}  |" +
                    $"  {row["Address"],-30} |" +
                    $"  {row["Email"],-25} |" +
                    $"  {row["Phone"],-15}  |" +
                    $"  {row["CountryID"],-5}  |");

            }


        }
        private static void GoToScreen( enMainMinueScreen OptionMinue)
        {
            switch (OptionMinue)
            {
                case enMainMinueScreen.enAddNewContact:

                    AddNewContact();

                    break;


                    case enMainMinueScreen.enUpdateContact:

                    UpdateContact();
                    break;

                case enMainMinueScreen.enDeleteContact:
                    DeleteContact();
                    break;

                case enMainMinueScreen.enFindContact:
                    FindContact();
                    break;

                case enMainMinueScreen.enPrintAllContact:
                    ListContacts();

                    break;

                case enMainMinueScreen.Exit:
                    break;








            }

        }

        public static void Login()
        {
            ShowMainMenue();
            GoToScreen((enMainMinueScreen)GetValidate("Enter Your Choise[1,6]: ", 1, 6));


        }

    }
}
