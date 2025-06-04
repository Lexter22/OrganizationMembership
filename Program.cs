using MembershipDataServices;
using MembershipCommon;
using Membership_BusinessDataLogic;
using System.Threading.Channels;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;
namespace OrganizationMembership
{
    internal class Program
    {
        static MembershipBusiness membershipBusiness = new MembershipBusiness();
        static void Main(string[] args)
        {
            Boolean loop = true;
            // mag loop unless ipick ang 5
            while (loop)
            {
                Console.WriteLine("Organization Membership");
                DisplayUserActions();
                int option = Convert.ToInt16(GetUserInput());
                switch (option)
                {
                    case (int)Actions.AddMember:
                        Funs(AddMembers);
                        break;
                    case (int)Actions.SearchMember:
                        Funs(SearchMembers);
                        break;
                    case (int)Actions.UpdateMember:
                        Funs(UpdateMember);
                        break;
                    case (int)Actions.ShowAllMember:
                        Funs(DisplayMembers);
                        break;
                    case (int)Actions.RemoveMember:
                        Funs(RemoveMember);
                        break;
                    case (int)Actions.Exit:
                        Console.WriteLine("Exit");
                        loop = false;
                        break;
                }
            }


        }
        static void DisplayUserActions() // mga choices
        {
            string[] processes = { "[0] Add Member", "[1] Search Member", "[2] Update Member", "[3] Show all Members", "[4] Remove a Member", "[5] Exit" };
            Console.WriteLine("Select an option");
            foreach (string process in processes)
            {
                Console.WriteLine(process);
            }
        }
        static string GetUserInput()
        {
            return Console.ReadLine();
        }
        static void Formatter()
        {
            Console.WriteLine("---------------------------------");
        }
        static void AddMembers()
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.Write("ID: ");
            string ID = Console.ReadLine();

            if(!firstName.IsNullOrEmpty() && !lastName.IsNullOrEmpty() && !ID.IsNullOrEmpty())
            {
                Members member = new Members { FName = firstName, LName = lastName };
                MembershipBusiness.AddMember(firstName, lastName, ID);
                Console.WriteLine("Member Added");
            }
            else {
                Console.WriteLine("Please fill up the fields!");
            }

        }
        static void SearchMembers()
        {
            AskID();
            string id = GetUserInput();

            if (!id.IsNullOrEmpty())
            {
                string result = membershipBusiness.SearchMember(id);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Enter an ID!");
            }
        }
        static void UpdateMember()
        {
            AskID();
            string UpdateID = GetUserInput();

            if(!UpdateID.IsNullOrEmpty())
            {
                Console.Write("First name: ");
                string UpdatedFName = Console.ReadLine();
                Console.Write("Last name: ");
                string UpdatedLName = Console.ReadLine();
                if (!UpdatedFName.IsNullOrEmpty() && !UpdatedLName.IsNullOrEmpty())
                {
                    MembershipBusiness.UpdateMember(UpdateID, UpdatedFName, UpdatedLName);
                }
                else
                {
                    Console.WriteLine("Fill up the fields!");
                }
            }
            else
            {
                Console.WriteLine("Enter an ID!");
            }

        }
        static void RemoveMember()
        {
            AskID();
            string id = GetUserInput();
            if (!id.IsNullOrEmpty())
            {
                Console.WriteLine(MembershipBusiness.RemoveMember(id));
                MembershipBusiness.RemoveMember(id);
                Console.WriteLine("Member removed");
            }
            else
            {
                Console.WriteLine("Member not found");
            }

        }
        static void DisplayMembers()
        {
           List<Members> members = MembershipBusiness.ShowAllMembers();
            if (members.Count > 0)
            {
                Console.WriteLine("Name\t\t\tID");
                Formatter();
                foreach (Members member in members)
                {
                    Console.WriteLine($"{member.FName} {member.LName}\t\t{member.ID}");
                }
            }
            else
            {
                Console.WriteLine("No members found.");
            }
        }
        static void AskID()
        {
            Console.Write("Enter ID:");
        }
        static void Funs(Action action)
        {
            Formatter();
            action();
            Formatter();
        }
        
    }
}
    

