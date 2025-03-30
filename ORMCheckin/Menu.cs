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
        public static Card PrintUpdateCard()
        {
            var card = new Card();

            Console.WriteLine("Jepni Id:");
            var valueId = Console.ReadLine();
            if (!Int32.TryParse(valueId, out var id))
            {
                throw new Exception("Invalid Id");
            }
            card.Id = id;

            Console.WriteLine("Jepni emrin:");
            var firstname = Console.ReadLine();
            card.FirstName = firstname;

            Console.WriteLine("Jepni mbiemrin:");
            var lastname = Console.ReadLine();
            card.LastName = lastname;

            Console.WriteLine("Jepni issued date: yyyy/MM/dd");
            var valueIssuedDate = Console.ReadLine();
            if (!string.IsNullOrEmpty(valueIssuedDate))
            {
                if (!DateTime.TryParse(valueIssuedDate, out var issuedDate))
                {
                    throw new Exception("Invalid date");
                }
                card.IssuedDate = issuedDate;
            }

            Console.WriteLine("Jepni deactivation date: yyyy/MM/dd");
            var valueDeactivationDate = Console.ReadLine();
            if (!string.IsNullOrEmpty(valueDeactivationDate))
            {
                if (!DateTime.TryParse(valueDeactivationDate, out var deactivationDate))
                {
                    throw new Exception("Invalid date");
                }
                card.DeactivationDate = deactivationDate;
            }
            return card;
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
