using Microsoft.EntityFrameworkCore.Query;
using ORMCheckin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCheckin.Services
{
    internal class CardService
    {
        private readonly CheckinContext _context;
        public CardService()
        {
            _context = new CheckinContext();
        }

        public List<Card> GetAll()
        {
            var result = _context.Cards.ToList();
            return result;
        }

        public Card GetById(int id) {
            var result =  _context.Cards.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Card Create(Card card) {

            var newItem = new Card()
            {
                FirstName = card.FirstName,
                LastName = card.LastName,
                IssuedDate = DateTime.Now,
            };
            _context.Cards.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public bool Delete(int id)
        {
            var item = _context.Cards.FirstOrDefault(x =>x.Id == id);
            if (item != null)
            {
                _context.Remove(item);
                var result = _context.SaveChanges();
                return result > 0 ? true : false;
            }
           return false;
        }

        public bool Update(int id, 
            string? firstName = null, 
            string? lastName = null, 
            DateTime? issuedDate = null,
            DateTime? deactivationDate = null) {
            var item = _context.Cards.FirstOrDefault(x => x.Id == id);
            if (item != null) {
                item.FirstName = string.IsNullOrEmpty(firstName) ? item.FirstName : firstName;
                item.LastName = lastName ?? item.LastName;
                item.IssuedDate = issuedDate ?? item.IssuedDate;
                item.DeactivationDate = deactivationDate ?? item.DeactivationDate;
                _context.Update(item);
                var result = _context.SaveChanges();
                return result > 0 ? true : false;
            }
            return false;
        }

        public void Print(Card card) {        
            Console.WriteLine($"{card.Id} | {card.FirstName} {card.LastName} | {card.IssuedDate.Date} {card.DeactivationDate?.Date}");
        }

        public void Print(List<Card> cards) { 
            foreach(Card card in cards) { Print(card); }
        }
    }
}
