namespace PolymorphismDemo
{
    internal class Program
    {
        static void Main()
        {
            Calculation calculation = new();
            calculation.Add(12, 13);
            calculation.Add(12, 13, 14);
            calculation.Add(12, 13, 123456789123);
            calculation.Add(12, 123456789123, 13);

            Person anilPersonRef = new(1, "anil");
            Person sunilPersonRef = new(2, "sunil");

            if (anilPersonRef > sunilPersonRef)
            {
                Console.WriteLine($"{nameof(anilPersonRef)} is greater than {nameof(sunilPersonRef)}");
            }
            else
            {
                Console.WriteLine($"{nameof(sunilPersonRef)} is greater than {nameof(anilPersonRef)}");
            }

            Person trainer = new Trainer(100, "joydip", ".Net Core");
            Display(trainer);

            Person trainee = new Trainee(101, "vinod", ".Net Core");
            Display(trainee);
        }
        static void Display(Person person)
        {
            Console.WriteLine(person.GetInformation());
        }
        //static void Display<T>(T type)
        //{
        //    if (type != null)
        //    {
        //        if (type is Trainer trainer)
        //        {
        //            Console.WriteLine(trainer.PrintInformation());
        //        }
        //        else if (type is Trainee trainee)
        //        {
        //            Console.WriteLine(trainee.ShowInformation());
        //        }
        //    }
        //static void Display(Trainee trainee)
        //{
        //    Console.WriteLine(trainee.ShowInformation());
        //}
        //static void Display(Trainer trainer)
        //{
        //    Console.WriteLine(trainer.PrintInformation());
        //}
    }
}
