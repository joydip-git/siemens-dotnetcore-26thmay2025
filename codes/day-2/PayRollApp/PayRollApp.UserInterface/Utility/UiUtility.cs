using PayRollApp.Entities;

namespace PayRollApp.UserInterface.Utility
{
    public static class UiUtility
    {
        public static int GetCount()
        {
            Console.Write("How many records? ");
            return int.Parse(Console.ReadLine() ?? "2");
        }

        public static void SaveEmployee(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                PrintMenu();
                char choice = GetChoice();
                Employee? employee = CreateEmployee(choice);
                if (employee != null)
                    employees[i] = employee;
            }
        }

        public static void PrintEmployees(Employee[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine($"Salary of {employees[i].Name} is {employees[i].TotalPay}");
            }
        }

        //helper methods
        private static char GetChoice()
        {
            Console.Write("\nEnter Choice: ");
            return char.Parse(Console.ReadLine() ?? "1");
        }

        private static void PrintMenu() => Console.WriteLine("1-> d for Developer\n2-> h for Hr");

        private static Employee? CreateEmployee(char choice)
        {

            Console.Write("\nId: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "NA";

            Console.Write("Basic Payment: ");
            decimal basic = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Da Payment: ");
            decimal da = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Basic Payment: ");
            decimal hra = decimal.Parse(Console.ReadLine() ?? "0");

            Employee? employee;
            switch (choice)
            {
                case 'd':
                    Console.Write("Incentive: ");
                    decimal incentive = decimal.Parse(Console.ReadLine() ?? "0");
                    employee = new Developer() { Name = name, Id = id, BasicPayment = basic, DaPayment = da, HraPayment = hra, IncentivePayment = incentive };
                    break;

                case 'h':
                    Console.Write("Gratuity: ");
                    decimal gratuity = decimal.Parse(Console.ReadLine() ?? "0");
                    employee = new Hr() { Name = name, Id = id, BasicPayment = basic, DaPayment = da, HraPayment = hra, GratuityPayment = gratuity };
                    break;

                default:
                    employee = null;
                    break;
            }

            employee?.CalculateSalary();
            return employee;
        }
    }
}
