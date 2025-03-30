using ORMCheckin.Models;

namespace ORMCheckin
{
    internal static class Menu
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Shtypni 1 per te kerkuar nje karte sipas id");
            Console.WriteLine("Shtypni 2 per te afishuar te gjitha kartat");
            Console.WriteLine("Shtypni 3 per te shtuar nje karte");
            Console.WriteLine("Shtypni 4 per te modifikuar nje karte");
            Console.WriteLine("Shtypni 5 per te fshire nje karte");
            Console.WriteLine("Shtypni x per te dale");
        }

        public static Card PrintCreateCard()
        {
            Console.WriteLine("Jepni emrin:");
            var firstname = Console.ReadLine();
            Console.WriteLine("Jepni mbiemrin:");
            var lastname = Console.ReadLine();
            var item = new Card
            {
                FirstName = firstname,
                LastName = lastname
            };
            return item;
        }
        public static int PrintGetCardById() {
            Console.WriteLine("Jepni id:");
            var value = Console.ReadLine();
            var id = Int32.Parse(value);
            return id;
        }

        public static void PrintGetAllCards()
        {
            Console.WriteLine("Id | Firstname Lastname | Issued date");
        }

        public static int PrintDeleteCardById()
        {
            Console.WriteLine("Jepni id:");
            var value = Console.ReadLine();
            var id = Int32.Parse(value);
            return id;
        }
    }
}
