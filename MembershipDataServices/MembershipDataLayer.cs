using System.Diagnostics;
using MembershipDataServices;
using MembershipCommon;
using System.Globalization;
namespace MembershipDataServices
{
    public class MembershipDataLayer
    {
        IOrgMembership MembershipDataLayerInt;
        public MembershipDataLayer()
        {
            // MembershipDataLayerInt = new TextFileDataService();
            //   MembershipDataLayerInt = new InMemoryDataService();
            //MembershipDataLayerInt = new JsonFileDataService();
           MembershipDataLayerInt = new DBDataService();
        }

        public void AddMember(Members member)
        {
            MembershipDataLayerInt.AddMember(member);
        }

        public List<Members> GetMembers()
        {
            return MembershipDataLayerInt.GetMembers();
        }

        public void RemoveMember(Members member)
        {
            MembershipDataLayerInt.RemoveMember(member);
        }
        public Members SearchMember(string id)
        {
          return MembershipDataLayerInt.SearchMember(id);
        }

        public void UpdateMember(Members member)
        {
            MembershipDataLayerInt.UpdateMember(member);
        }
    }
}
