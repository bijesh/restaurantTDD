using restaurant.Interface;
using restaurant.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace restaurant.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _restaurantService;
        private IRestaurantViewModelBuilder _restaurantViewModelBuilder;

        public RestaurantController(IRestaurantService restaurantService, IRestaurantViewModelBuilder restaurantViewModelBuilder)
        {
            if (restaurantService == null || restaurantViewModelBuilder == null)
            {
                throw new ArgumentNullException();
            }
                
            _restaurantService = restaurantService;
            _restaurantViewModelBuilder = restaurantViewModelBuilder;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }
        
        [HttpPost]
        public async Task<ActionResult> Search(string postCode)
        {
            var watch = new Stopwatch();
            Console.WriteLine("Begin Search");
            watch.Start();
            var restaurantViewModel = new RestaurantViewModel();
            
            if (!string.IsNullOrEmpty(postCode))
            {
                try
                {
                    var restaurantList = await _restaurantService.SearchRestaurants(postCode);
                    restaurantViewModel = _restaurantViewModelBuilder.Build(restaurantList);
                }
                catch(Exception ex)
                {
                    //TODO: log exception
                    Console.WriteLine(ex.Message);
                    return View("Error");
                }
            }
            watch.Stop();
            // TODO Log watch.ElapsedMilliseconds
            Console.WriteLine($"End Search Time Taken{ watch.ElapsedMilliseconds}");
            return View(restaurantViewModel);
        }
    }
}