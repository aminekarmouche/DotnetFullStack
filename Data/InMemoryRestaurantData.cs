﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        //contructor
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Moroccan},
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location="London", Cuisine=CuisineType.French},
                new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine=CuisineType.Italian}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant) {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            if(newRestaurant != null)
            {
                restaurants.Add(newRestaurant);
                newRestaurant.Id = restaurants.Max(r => r.Id) + 1; 
            }
            return newRestaurant;
        }
        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }
        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
        public int Commit()
        {
            return 0;
        }

    }
}
