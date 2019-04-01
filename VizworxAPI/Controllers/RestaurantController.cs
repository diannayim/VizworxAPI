using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VizworxAPI.Models;
using VizworxAPI.Services;

namespace VizworxAPI.Controllers
{
    public class RestaurantController : ApiController
    {
        private RestaurantRepository restaurantRepository;

        public RestaurantController()
        {
            this.restaurantRepository = new RestaurantRepository();
        }

        public List<Restaurant> Get()
        {
            return restaurantRepository.GetRestaurants();
        }

        public void Post(HttpRequestMessage request)
        {
            string json = request.Content.ReadAsStringAsync().Result;
            Restaurant r = JsonConvert.DeserializeObject<Restaurant>(json);
            this.restaurantRepository.AddRestaurant(r);
        }
    }
}
