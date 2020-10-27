namespace _23102020dz2
{
    public class Client
    {
        public string FitstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Account account { get; set; }

        public Client()
        {
            FitstName = "";
            MiddleName = "";
            LastName = "";
            PhoneNumber = "";
        }
    }
}