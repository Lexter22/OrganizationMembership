using MembershipCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MembershipDataServices
{
    class InMemoryDataService : IOrgMembership
    {
        public static List<Members> members = new List<Members>();
        // private static int memberID = 1;
        public InMemoryDataService()
        {
            TextFileDataService textFileDataService = new TextFileDataService();
            CreateDummyAccounts();
        }
        private void CreateDummyAccounts()
        {
            members.Add(new Members { FName = "Dexter", LName = "Morgan", ID = "A1111" });
        }
        public void AddMember(Members member)
        {
            members.Add(member);
        }
        public List<Members> GetMembers()
        {
            return members;
        }
        public void RemoveMember(Members member)
        {
            members.Remove(member);
        }
        public string UpdateMember(Members member)
        {
            foreach (Members m in members)
            {
                if (m.ID == member.ID)
                {
                    m.FName = member.FName;
                    m.LName = member.LName;
                    return "Member updated";

                }
            }
            return "Member not found";
        }

        void IOrgMembership.UpdateMember(Members member)
        {
            foreach (Members m in members)
            {
                if (m.ID == member.ID)
                {
                    m.FName = member.FName;
                    m.LName = member.LName;


                }
            }

        }
        public Members SearchMember(string id)
        {
            foreach (Members m in members)
            {
                if (m.ID == id)
                {
                    return m;
                }
            }
            return null; 

        }
    }
}
