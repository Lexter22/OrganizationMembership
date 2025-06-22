using MembershipCommon;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
namespace MembershipDataServices
{
    class DBDataService : IOrgMembership
    {
        static string connectionString = "Data Source = LEXTER; Initial Catalog = Organization_Membership; Integrated Security = True;TrustServerCertificate=True;";

        static SqlConnection sqlConnection;
        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
          
        }
        public List<Members> GetMembers()
        {
            string selectStatement = "SELECT * FROM Members";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();
            var members = new List<Members>();
            while(reader.Read())
            {
                //Members membersSerial = new Members();
                //membersSerial.FName = reader["first_name"].ToString();
                //membersSerial.LName = reader["last_name"].ToString();
                //membersSerial.ID = reader["ID"].ToString();

                //members.Add(membersSerial);
                Members member = new Members
                {
                    FName = reader["first_name"].ToString(),
                    LName = reader["last_name"].ToString(),
                    ID = reader["ID"].ToString()
                };
                members.Add(member);
            }
            sqlConnection.Close();
            return members; 
        }
        public void AddMember(Members member)
        {
            sqlConnection.Open();
            string addMemberStatement = "INSERT INTO Members (first_name, last_name, ID) " +
                "VALUES (@first_name, @last_name, @ID)";

            SqlCommand insertCommannd = new SqlCommand(addMemberStatement, sqlConnection);
            insertCommannd.Parameters.AddWithValue("@first_name", member.FName);
            insertCommannd.Parameters.AddWithValue("@last_name", member.LName);
            insertCommannd.Parameters.AddWithValue("@ID", member.ID);
            insertCommannd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void RemoveMember(Members member)
        {
            sqlConnection.Open();

            var deleteStatement = "DELETE FROM Members WHERE ID = @ID";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@ID", member.ID);

           deleteCommand.ExecuteNonQuery();
           sqlConnection.Close();
        }

        public void UpdateMember(Members member)
        {
            sqlConnection.Open();
            string updateStatement = $"UPDATE Members SET first_name = @first_name ,last_name = @last_name " +
                $"WHERE ID = @ID";

             SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
             
            updateCommand.Parameters.AddWithValue("@first_name", member.FName);
            updateCommand.Parameters.AddWithValue("@last_name", member.LName);
            updateCommand.Parameters.AddWithValue("@ID", member.ID);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public Members SearchMember(string id)
        {
            Members member = null;
            sqlConnection.Open();
            string searchMember = $"SELECT * FROM Members WHERE ID = @ID";
            SqlCommand searchCommand = new SqlCommand(searchMember, sqlConnection);
            searchCommand.Parameters.AddWithValue("@ID",id);

           SqlDataReader reader = searchCommand.ExecuteReader();
            if(reader.Read())
            {
                member = new Members
                {
                    FName = reader["first_name"].ToString(),
                    LName = reader["last_name"].ToString(),
                    ID = reader["ID"].ToString()
                };
            }
            reader.Close();
            sqlConnection.Close();
            return member;
            
        }

    }
}
