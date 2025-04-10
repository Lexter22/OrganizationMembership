using System.Diagnostics;
using MembershipDataServices;
using MembershipCommon;
namespace MembershipDataServices
{
    public class MembershipDataLayer
    {
        public static List<Members> members = new List<Members>();
        public static int memberID = 4;
        public MembershipDataLayer()
        {
                CreateDummyAccount();
        }
        private void CreateDummyAccount()
        {
            // Dummy account, Dexter fan ako hehe
            Members member1 = new Members { FName = "Dexter", LName = "Morgan", MemberID = 1 };
            Members member2 = new Members { FName = "Debra", LName = "Morgan", MemberID = 2};
            Members member3 = new Members { FName = "Brian", LName = "Moser",MemberID = 3};

            members.Add(member1);               // Di pa ito nagana
            members.Add(member2);
            members.Add(member3);
        }
        public static void AddMember(Members member)
        {
            member.MemberID = memberID++;
            members.Add(member);
        }
        public static string SearchMember(int id)
        {
            foreach(Members member in members)
            {
                if (member.MemberID == id)
                {
                    return $"Name: {member.FName} {member.LName}";
                }
                else
                {
                    MemberNotFound();
                }
            }
            return null;
        }
        public static string UpdateMember()
        {
            return "Update Member";
        }
        public static bool RemoveMember(int id)
        {
            for(int i = 0; i < members.Count; i++)
            {
                if (members[i].MemberID == id)
                {
                    members.RemoveAt(i);
                    return true;
                }
                else
                {
                    MemberNotFound();
                }
            }
            return false;
        }
        static string MemberNotFound()
        {
            return "Member not found";
        }
       
    }
}
