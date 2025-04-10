using MembershipCommon;
using MembershipDataServices;

namespace Membership_BusinessDataLogic
{
    public class MembershipBusiness
    {
        static MembershipDataLayer dataLayer = new MembershipDataLayer();
      
        public static void AddMember(Members member)
        {
            MembershipDataLayer.AddMember(member);
        }

        public static string SearchMember(int id)
        {
            return MembershipDataLayer.SearchMember(id);
        }
        public static string UpdateMember()
        {
            return MembershipDataLayer.UpdateMember();
        }
        public static List<Members> ShowAllMember()
        {
            return MembershipDataLayer.members;
        }
        public static bool RemoveMember(int id)
        {
            return MembershipDataLayer.RemoveMember(id);
        }
    }
}
