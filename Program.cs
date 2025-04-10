using MembershipDataServices;
using MembershipCommon;
using Membership_BusinessDataLogic;
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
                        Console.WriteLine("Member Added");
                        break;
                    case (int)Actions.SearchMember:
                        Formatter();

                        break;
                    case (int)Actions.UpdateMember:
                        Formatter();
                        Console.WriteLine("Update Member");
                        break;
                    case (int)Actions.ShowAllMember:
                        Formatter();
                        ShowAllMembers();
                        break;
                    case (int)Actions.RemoveMember:
                        Formatter();
                        Console.WriteLine("Remove a Member");
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
            public static void AddMembers()
            {
                Console.Write("First name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last name: ");
                string lastName = Console.ReadLine();

                Members member = new Members { FName = firstName, LName = lastName };
                MembershipBusiness.AddMember(member);
            }
            public static void ShowAllMembers()
            {
                List<Members> members = MembershipBusiness.ShowAllMember();
                Console.WriteLine("Name                         Member ID");
                foreach (Members member in members)
                {
                    Console.WriteLine($"{member.FName} {member.LName}          {member.MemberID}\n");
                }
            }
        }
    }
}
