using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyTuto.Pages
{
    public class RestaurantsModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<RestaurantsModel> logger;

        public string Message { get; set; }

        // Bind property
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public RestaurantsModel(IConfiguration config, IRestaurantData restaurantData, ILogger<RestaurantsModel> logger) 
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        //Respond on GET requests
        public void OnGet()
        {
            logger.LogError("Executing ListModel");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }

    }
}