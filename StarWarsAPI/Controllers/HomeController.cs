using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsAPI.Models;
using StarWarsAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StarWarsClient _starWarsClient;

        public HomeController(ILogger<HomeController> logger, StarWarsClient starWarsClient)
        {
            _logger = logger;
            _starWarsClient = starWarsClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPersonID(string id)
        {
            var response = await _starWarsClient.GetPersonID(id);

            var viewModel = new PeopleViewModel();
            viewModel.name = response.name;
            viewModel.height = response.height;
            viewModel.mass = response.mass;
            viewModel.hair_color = response.hair_color;
            viewModel.skin_color = response.skin_color;
            viewModel.eye_color = response.eye_color;
            viewModel.birth_year = response.birth_year;
            viewModel.gender = response.gender;
            viewModel.homeworld = response.homeworld;
            viewModel.url = response.url;

            return View(viewModel);
           
        }

        public async Task<IActionResult> GetPlanetID(string id)
        {
            var response = await _starWarsClient.GetPlanetID(id);

            var viewModel = new PlanetViewModel();
            viewModel.name = response.name;
            viewModel.rotation_period = response.rotation_period;
            viewModel.orbital_period = response.orbital_period;
            viewModel.diameter = response.diameter;
            viewModel.climate = response.climate;
            viewModel.gravity = response.gravity;
            viewModel.terrain = response.terrain;
            viewModel.surface_water = response.surface_water;
            viewModel.population = response.population;
            viewModel.url = response.url;

            return View(viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
