using ORMCheckin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCheckin.Services
{
    internal class UserCheckinService
    {
        private readonly CheckinContext _context;
        public UserCheckinService()
        {
            _context = new CheckinContext();
        }

        public UserCheckin Update(UserCheckin payload)
        {
            var item = _context.UserCheckins.FirstOrDefault(x => x.Id == payload.Id);
            if (item != null)
            {
                item.Action = string.IsNullOrEmpty(payload.Action) ? item.Action : payload.Action;
                item.Timestamp = payload.Timestamp ?? item.Timestamp;
                _context.Update(item);
                var result = _context.SaveChanges();
                return item;
            }
            return null;
        }
    }
}
