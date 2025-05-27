namespace PayRollApp.Entities
{
    public class Employee
    {
        //private readonly int id;
        //public int Id => id;

        public int Id { get; init; }
        public required string Name
        { get; set; }
        public decimal BasicPayment
        { get; set; }
        public decimal DaPayment
        { get; set; }
        public decimal HraPayment
        { get; set; }
        public decimal TotalPay
        { get; protected set; }

        public Employee()
        {
        }
        public Employee(int id)
        {
            //with readonly data member id
            //this.id = id;

            //with init-only property Id
            this.Id = id;
        }

        public Employee(int id, string name, decimal basicPayment, decimal daPayment, decimal hraPayment)
            : this(id)
        {
            Name = name;
            BasicPayment = basicPayment;
            DaPayment = daPayment;
            HraPayment = hraPayment;
        }

        public virtual void CalculateSalary() => TotalPay = BasicPayment + DaPayment + HraPayment;
    }
}
