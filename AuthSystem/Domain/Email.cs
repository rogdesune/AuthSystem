namespace AuthSystem.Domain
{
    public class Email
    {
        public string Address { get; }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) 
            {
                throw new ArgumentException("Email cannot be empty.");
            }
            if (!(address.Contains("@")))
            {
                throw new ArgumentException("Wrong email format.");
            }
            
            this.Address = address;
        }
        public override string ToString()
        {
            return Address;
        }
    }
}
