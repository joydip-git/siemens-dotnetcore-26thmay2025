namespace OOPDemo
{
    internal class Person
    {
        string name;
        string emailId;
        string location;
        long mobileNo;

        public Person()
        {
            name = string.Empty;
            emailId = string.Empty;
            location = string.Empty;
        }

        public Person(string name, string emailId, string location, long mobileNo) : this()
        {
            this.name = name;
            this.emailId = emailId;
            this.location = location;
            this.mobileNo = mobileNo;

        }
        //public string GetName() => name;
        //public void SetName(string value) => name = value;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public string EmailId 
        { 
            get => emailId; 
            set => emailId = value; 
        }
        public string Location 
        { 
            get => location; 
            set => location = value; 
        }
        public long MobileNo 
        { 
            get => mobileNo; 
            set => mobileNo = value; 
        }
    }
}
