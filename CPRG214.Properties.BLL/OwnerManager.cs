using System.Collections;
using System.Linq;
using CPRG214.Properties.Data;
using System.Collections.Generic;
using CPRG214.Properties.Domain;

namespace CPRG214.Properties.BLL
{
    public class OwnerManager
    {
        public static List<Owner> GetAll()
        {
            var context = new RentalsContext();
            var owners = context.Owners.OrderBy(o => o.Name).ToList();
            return owners;
        }

        public static void Add(Owner owner)
        {
            var context = new RentalsContext();
            context.Owners.Add(owner);
            context.SaveChanges();
        }

        public static void Update(Owner owner)
        {
            var context = new RentalsContext();
            var originalOwner = context.Owners.Find(owner.Id);
            originalOwner.Name = owner.Name;
            originalOwner.Phone = owner.Phone;
            context.SaveChanges();
        }

        public static Owner Find(int id)
        {
            var context = new RentalsContext();
            var owner = context.Owners.Find(id);
            return owner;
        }
        public static IList GetAsKeyValuePairs()
        {
            var context = new RentalsContext();
            var owners = context.Owners.Select(o => new
            {
                Value = o.Id,
                Text = o.Name
            }).ToList();
            return owners;
        }
    }
}
