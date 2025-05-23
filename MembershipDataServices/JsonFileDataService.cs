using MembershipCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace MembershipDataServices
{
    class JsonFileDataService : IOrgMembership
    {
        static List<Members> members = new List<Members>();
        static string JsonFilePath = "members_json.json";

        public JsonFileDataService()
        {
            ReadJSONFile();
        }
        private void ReadJSONFile()
        {
            string JsonFile = File.ReadAllText(JsonFilePath);

            members = JsonSerializer.Deserialize<List<Members>>(JsonFile, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(members, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(JsonFilePath, jsonString);
        }
        private List<Members> GetMembers()
        {
            return members;
        }
        private int FindMemberIndex(string ID)
        {
            var findmember = GetMembers();

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].ID == ID)
                {
                    return i;
                }
            }

            return -1;
        }
        public void RemoveMember(Members member)
        {
            var index = FindMemberIndex(member.ID);

            members.RemoveAt(index);
            WriteJsonDataToFile();

        }
        public void UpdateMember(Members member)
        {
            var index = FindMemberIndex(member.ID);

            members[index].FName = member.FName;
            members[index].LName = member.LName;

            WriteJsonDataToFile();

        }

        public void AddMember(Members member)
        {
           members.Add(member);
           WriteJsonDataToFile();
        }

        List<Members> IOrgMembership.GetMembers()
        {
            return GetMembers();
        }
    }
}
