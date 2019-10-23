using System;
using System.Collections.Generic;
using System.Text;
using Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly DataDbContext db;

        public SqlRestaurantData(DataDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var result = from r in db.Restaurants
                         where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                         orderby r.Name
                         select r;
            return result;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified; ;
            return updatedRestaurant;
        }
    }
}
