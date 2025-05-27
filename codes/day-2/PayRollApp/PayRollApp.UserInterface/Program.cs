using PayRollApp.Entities;
using static PayRollApp.UserInterface.Utility.UiUtility;

namespace PayRollApp.UserInterface
{
    internal class Program
    {
        static void Main()
        {
            int recordsCount = GetCount();
            Employee[] employees = new Employee[recordsCount];
            SaveEmployee(employees);
            PrintEmployees(employees);
        }
    }
}
