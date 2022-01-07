using SimpleShoppingListSPA.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SimpleShoppingListSPA.Controllers
{
    public class ShoppingListController : ApiController
    {
        public static List<ShoppingList> shoppingLists = new List<ShoppingList>()
        {
            new ShoppingList()
            {
                Id=0,
                Name="Tutorials",
                Items= new List<Item>()
                {
                    new Item(){Id=0, Name="MOSH FULL STACK .NET DEVELOPER part 1", ShoppingListId = 0},
                    new Item(){Id=1, Name="MOSH FULL STACK .NET DEVELOPER part 2", ShoppingListId = 0},
                    new Item(){Id=2, Name="MOSH FULL STACK .NET DEVELOPER part 3", ShoppingListId = 0},
                }
            },
            new ShoppingList()
            {
                Id=1,
                Name="Market",
                Items= new List<Item>()
                {
                    new Item(){Id=0, Name="Milk", ShoppingListId = 1},
                    new Item(){Id=1, Name="Hummus", ShoppingListId = 1},
                    new Item(){Id=2, Name="Eggs", ShoppingListId = 1},
                }
            },
            new ShoppingList()
            {
                Id=2,
                Name="Gym",
                Items= new List<Item>()
                {
                    new Item(){Id=0, Name="BCAAs", ShoppingListId = 2},
                    new Item(){Id=1, Name="Protein", ShoppingListId = 2},
                    new Item(){Id=2, Name="Creatine", ShoppingListId = 2},
                }
            },
        };

        // GET: api/ShoppingList/5
        public IHttpActionResult Get(int id)
        {
            var shoppingList = shoppingLists.FirstOrDefault(s => s.Id == id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(shoppingList);
        }

        // POST: api/ShoppingList
        public IEnumerable Post([FromBody] ShoppingList newList)
        {
            newList.Id = shoppingLists.Count;
            shoppingLists.Add(newList);

            return shoppingLists;
        }

    }
}
