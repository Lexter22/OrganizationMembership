namespace MembershipCommon
{
    public class Members
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string ID { get; set; }

        public override string ToString()
        {
            return $"{FName} {LName}\t\t{ID}";
        }
       
    }
}
