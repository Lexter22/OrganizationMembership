using MembershipCommon;
using MembershipDataServices;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace Membership_BusinessDataLogic
{
    public class MembershipBusiness
    {
      
        
        static MembershipDataLayer dataLayer = new MembershipDataLayer();
      
        public static void AddMember(string firstname,string lastname,string id)
        {
            Members member = new Members { FName = firstname, LName = lastname, ID = id };
            dataLayer.AddMember(member);
        }
        public string SearchMember(string id)
        {
            //return MembershipDataLayer.SearchMember(id);
            foreach (Members member in dataLayer.GetMembers())
            {
                if (member.ID.Equals(id))
                {
                    return $"Name: {member.FName} {member.LName}";
                   
                }
            }
            return "Member not found";
        }
        public static string UpdateMember(string id, string UpdateFName, string UpdateLName)
        {
            //return MembershipDataLayer.UpdateMember(id, UpdateFName, UpdateLName);
            foreach (Members member in dataLayer.GetMembers())
            {
                if (member.ID.Equals(id))
                {
                   member.FName = UpdateFName;
                   member.LName = UpdateLName;
                   dataLayer.UpdateMember(member);
                   return $"Member updated: {member.FName} {member.LName}";
                }
            }
            return "Member not found!";
        }
        public static List<Members> ShowAllMembers()
        {
            return dataLayer.GetMembers();

        }
        public static bool RemoveMember(string id)
        {
            //return MembershipDataLayer.RemoveMember(id);
            foreach(Members member in dataLayer.GetMembers())
            {
                if (member.ID == id)
                {
                    dataLayer.RemoveMember(member);
                    return true;
                }
         
            }
            return false;
        }
    }
}
