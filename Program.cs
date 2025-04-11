using MembershipDataServices;
using MembershipCommon;
using Membership_BusinessDataLogic;
using System.Threading.Channels;
using System.Diagnostics;
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
                int option = GetUserInput();
                switch (option)
                {
                    case (int)Actions.AddMember:
                        Formatter();
                        AddMembers();
                        Formatter();
                        break;
                    case (int)Actions.SearchMember:
                        Formatter();
                        SearchMembers();
                        Formatter();
                        break;
                    case (int)Actions.UpdateMember:
                        Formatter();
                        UpdateMember();
                        Formatter();
                        break;
                    case (int)Actions.ShowAllMember:
                        Formatter();
                        DisplayMembers();
                        Formatter();
                        break;
                    case (int)Actions.RemoveMember:
                        Formatter();
                        RemoveMember();
                        Formatter();
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
        static int GetUserInput()
        {
            return Convert.ToInt16(Console.ReadLine());
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

           Members member = new Members { FName = firstName, LName = lastName };
           MembershipBusiness.AddMember(member);
           Console.WriteLine("Member Added");

        }
        static void SearchMembers()
        {
            AskID();
            int id = GetUserInput();

            if (MembershipBusiness.SearchMember(id) != null)
            {
                Console.WriteLine("User found");
                Console.WriteLine(MembershipBusiness.SearchMember(id));
            }
            else
            {
                Console.WriteLine("Member not found");
            }
        }
        static void UpdateMember()
        {
            AskID();
            int id = GetUserInput();

            if (MembershipBusiness.SearchMember(id) != null)
            {
                Console.WriteLine(MembershipBusiness.SearchMember(id));

                Console.Write("First name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last name: ");
                string lastName = Console.ReadLine();

                bool isUpdated = MembershipBusiness.UpdateMember(id, firstName, lastName);
                if(isUpdated)
                {
                    Console.WriteLine("Member updated!");
                }
                else
                {
                    Console.WriteLine("Update unsuccessful");
                }
            }
            else
            {
                Console.WriteLine("Member not found");
            }
        }
        static void RemoveMember()
        {
            AskID();
            int id = GetUserInput();
            if (MembershipBusiness.SearchMember(id) != null)
            {
                Console.WriteLine(MembershipBusiness.SearchMember(id));
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
           List<Members> members = MembershipBusiness.ShowAllMember();
            if (members.Count > 0)
            {
                Console.WriteLine("Name\t\t\tID");
                Formatter();
                foreach (Members member in members)
                {
                    Console.WriteLine($"{member.FName} {member.LName}\t\t{member.GetMemberID()}");
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
        
    }
}
    

