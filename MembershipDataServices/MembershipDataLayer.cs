using System.Diagnostics;
using MembershipDataServices;
using MembershipCommon;
using System.Globalization;
namespace MembershipDataServices
{
    public class MembershipDataLayer
    {
        public static List<Members> members = new List<Members>();
        private static int memberID = 1;
      
        public static void AddMember(Members member)
        {
            member.SetMemberID(memberID++);
            members.Add(member);
        }
        public static string SearchMember(int id)
        {
            foreach(Members member in members)
            {
                if (member.GetMemberID() == id)
                {
                    return $"Name: {member.FName} {member.LName}";
                }
               
            }
            return MemberNotFound();
        }
        public static bool UpdateMember(int id,string UpdateFNamne,string UpdateLName)
        {
            foreach (Members member in members)
            {
                member.FName = UpdateFNamne;
                member.LName = UpdateLName;
                return true;
            }
            return false;
        }
        public static bool RemoveMember(int id)
        {
            for(int i = 0; i < members.Count; i++)
            {
                if (members[i].GetMemberID() == id)
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
