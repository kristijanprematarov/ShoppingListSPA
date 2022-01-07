using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleShoppingListSPA.Data;
using SimpleShoppingListSPA.Models;

namespace SimpleShoppingListSPA.Controllers
{
    public class ItemsEFController : ApiController
    {
        private readonly SimpleShoppingListSPAContext _context = new SimpleShoppingListSPAContext();

        // GET: api/ItemsEF
        public IQueryable<Item> GetItems()
        {
            return _context.Items;
        }

        // GET: api/ItemsEF/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            Item item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/ItemsEF/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(item);
        }

        // POST: api/ItemsEF
        [ResponseType(typeof(ShoppingList))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShoppingList shoppingList = _context.ShoppingLists
                .Where(s => s.Id == item.ShoppingListId)
                .Include(s => s.Items).FirstOrDefault();

            if (shoppingList == null)
            {
                return NotFound();
            }

            _context.Items.Add(item);
            _context.SaveChanges();

            return Ok(shoppingList);
        }

        // DELETE: api/ItemsEF/5
        [ResponseType(typeof(ShoppingList))]
        public IHttpActionResult DeleteItem(int id)
        {
            Item item = _context.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            ShoppingList shoppingList = _context.ShoppingLists
                .Where(s => s.Id == item.ShoppingListId)
                .Include(s => s.Items).FirstOrDefault();

            if (shoppingList == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            _context.SaveChanges();

            return Ok(shoppingList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Count(e => e.Id == id) > 0;
        }
    }
}