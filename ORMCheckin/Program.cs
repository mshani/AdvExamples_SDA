using ORMCheckin;
using ORMCheckin.Services;

Menu.PrintMenu();
var cardService = new CardService();

var value = Console.ReadLine();
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
    case ("5"):
        var cardIdToDelete = Menu.PrintDeleteCardById();
        var deleteResult = cardService.Delete(cardIdToDelete);        
        break;
    default:
        Console.WriteLine("Invalid option");
        break;
}