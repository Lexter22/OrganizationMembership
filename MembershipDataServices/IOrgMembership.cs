using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MembershipCommon;
namespace MembershipDataServices
{
    public interface IOrgMembership
    {
        public void AddMember(Members member);
        public void UpdateMember(Members member);
        public void RemoveMember(Members member);
        Members SearchMember(string id);
        public List<Members> GetMembers();
    }
}
