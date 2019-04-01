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
    /// <summary>
    /// Controls restaurant API calls.
    /// </summary>
    public class RestaurantController : ApiController
    {
        /// <summary>
        /// Creates RestaurantRespoistory for Restaurant logic.
        /// </summary>
        private RestaurantRepository restaurantRepository;

        /// <summary>
        /// Sets up RestaurantRepository.
        /// </summary>
        public RestaurantController()
        {
            this.restaurantRepository = new RestaurantRepository();
        }

        /// <summary>
        /// Returns list of restaurants in system.
        /// </summary>
        /// <returns>List of restaurants sorted by rating.</returns>
        public List<Restaurant> Get()
        {
            return restaurantRepository.GetRestaurants();
        }

        /// <summary>
        /// Adding a restaurant to the list.
        /// </summary>
        /// <param name="request">HTTP Request with the JSON string of the restaurant to add to the list.</param>
        public void Post(HttpRequestMessage request)
        {
            string json = request.Content.ReadAsStringAsync().Result;
            Restaurant r = JsonConvert.DeserializeObject<Restaurant>(json);
            this.restaurantRepository.AddRestaurant(r);
        }
    }
}
