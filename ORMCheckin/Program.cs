using ORMCheckin.Services;

var cardService = new CardService();

//var newCard = cardService.Create("Emma", "Cooper", DateTime.Now);
//var removed = cardService.Delete(6);

var updated = cardService.Update(5, lastName:"Cooper", deactivationDate: DateTime.Now);

var cardList = cardService.GetAll();
foreach (var item in cardList)
{
    Console.WriteLine($"{item.Id} | {item.FirstName} {item.LastName} | {item.IssuedDate}  {item.DeactivationDate}");
}

//var card = cardService.GetById(2);
//Console.WriteLine($"{card.Id} | {card.FirstName} {card.LastName} | {card.IssuedDate}  {card.DeactivationDate}");
