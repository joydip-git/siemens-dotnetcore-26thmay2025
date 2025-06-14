﻿namespace PayRollApp.Entities
{
    public class Developer : Employee
    {
        public decimal IncentivePayment 
        { get; set; }

        public Developer()
        {

        }
        public Developer(int id, string name, decimal basicPayment, decimal daPayment, decimal hraPayment, decimal incentivePayment) : base(id, name, basicPayment, daPayment, hraPayment)
        {
            IncentivePayment = incentivePayment;
        }

        public override void CalculateSalary()
        {
            base.CalculateSalary();
            TotalPay += IncentivePayment;
        }
    }
}
