using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MembershipCommon;
namespace MembershipDataServices
{
    interface IOrgMembership
    {
        public void AddMember(Members member);
        public void UpdateMember(Members member);
        public void RemoveMember(Members member);
        public List<Members> GetMembers();
    }
}
