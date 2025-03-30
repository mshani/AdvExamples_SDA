using ORMCheckin;
using ORMCheckin.Services;

Menu.PrintMenu();
var value = Console.ReadLine();
var cardService = new CardService();
while (!string.Equals(value, "x", StringComparison.CurrentCultureIgnoreCase)){
    switch (value)
    {
        case ("x"):
        case ("X"):
            return;
        case ("1"):
            var cardId = Menu.PrintGetCardById();
            var item = cardService.GetById(cardId);
            cardService.Print(item);
            break;
        case ("2"):
            Menu.PrintGetAllCards();
            var items = cardService.GetAll();
            cardService.Print(items);
            break;
        case ("3"):
            var cardToCreate = Menu.PrintCreateCard();
            var createdCard = cardService.Create(cardToCreate);
            cardService.Print(createdCard);
            break;
        case ("4"):
            var cardToUpdate = Menu.PrintUpdateCard();
            var updatedCard = cardService.Update(cardToUpdate);
            cardService.Print(updatedCard);
            break;
        case ("5"):
            var cardIdToDelete = Menu.PrintDeleteCardById();
            var deleteResult = cardService.Delete(cardIdToDelete);
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
    Console.WriteLine();
    Console.WriteLine("Zgjidhni opsionin e rradhes");
    value = Console.ReadLine();
}