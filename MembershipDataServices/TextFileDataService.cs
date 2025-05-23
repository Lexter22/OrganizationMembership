using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MembershipCommon;
namespace MembershipDataServices
{
    class TextFileDataService : IOrgMembership
    {
        string filePath = "members.txt";
        List<Members> Member = new List<Members>();
        public TextFileDataService()
        { 
            GetDataFromFile();
        }

        public void AddMember(Members member)
        {
           Member.Add(member);
           WriteDataToFile();
        }
        private void WriteDataToFile()
        {
            var lines = new string[Member.Count];

            for (int i = 0; i < Member.Count; i++)
            {
                lines[i] = $"{Member[i].FName},{Member[i].LName},{Member[i].ID}";
            }

            File.WriteAllLines(filePath, lines);
        }

        public int FindIndex(Members member)
        {
            for (int i = 0; i < Member.Count; i++)
            {
                if (Member[i].ID == member.ID)
                {
                    return i;
                }
            }

            return -1;
        }

        private void GetDataFromFile()
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                Member.Add(new Members
                {
                    FName = parts[0],
                    LName = parts[1],
                    ID = parts[2],
                 
                });
            }
        }

        public void RemoveMember(Members member)
        {
            int index = -1;
            for (int i = 0; i < Member.Count; i++)
            {
                if (Member[i].ID == member.ID)
                {
                    index = i;
                }
            }

            Member.RemoveAt(index);

            WriteDataToFile();
        }

        public void UpdateMember(Members member)
        {
            int index = FindIndex(member);

            Member[index].FName = member.FName;
            Member[index].LName = member.LName;

            WriteDataToFile();
        }

        public List<Members> GetMembers()
        {
            return Member;
        }

      
    }
}
