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

        public Card Update(Card card) {
            var item = _context.Cards.FirstOrDefault(x => x.Id == card.Id);
            if (item != null) {
                item.FirstName = string.IsNullOrEmpty(card.FirstName) ? item.FirstName : card.FirstName;
                item.LastName = string.IsNullOrEmpty(card.LastName) ? item.LastName : card.LastName;
                item.IssuedDate = card.IssuedDate ?? item.IssuedDate;
                item.DeactivationDate = card.DeactivationDate ?? item.DeactivationDate;
                _context.Update(item);
                var result = _context.SaveChanges();
                return item;
            }
            return null;
        }

        public void Print(Card card) {
            if (card != null)
            { Console.WriteLine($"{card.Id} | {card?.FirstName} {card?.LastName} | {card?.IssuedDate?.Date} {card?.DeactivationDate?.Date}"); 
            }
        }

        public void Print(List<Card> cards) { 
            foreach(Card card in cards) { Print(card); }
        }
    }
}
