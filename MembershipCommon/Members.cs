namespace MembershipCommon
{
    public class Members
    {
        public string FName { get; set; }
        public string LName { get; set; }
        private int MemberID { get; set; }

        public override string ToString()
        {
            return $"{FName} {LName}\t\t{MemberID}";
        }
        public int GetMemberID()
        {
            return MemberID; // getter for MemberID
        }
        public void SetMemberID(int id)
        {
            MemberID = id; // setter for MemberID 
        }
    }
}
