﻿using Demo_WebApp.DataStore;
using Demo_WebApp.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Demo_WebApp.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ILogger<CitiesController> _logger;
        private ICitiesDataStore _dataStore;

        public CitiesController(
            ILogger<CitiesController> logger,
            ICitiesDataStore dataStore)
        {
            _logger = logger;
            _dataStore = dataStore;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            _logger.LogInformation($"{nameof(GetCities)} called");

            List<City> cities = _dataStore.Cities;
            if (cities == null)
                return NotFound();

            List<GetCityModel> models = cities
                  .Select(c => new GetCityModel(
                     c.Id,
                     c.Name,
                     c.Description,
                     c.NumberOfPoi))
                 .ToList();

            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)  //должны совпадать с именем в httpGet
        {
            _logger.LogInformation($"{nameof(id)} called");

            City city = _dataStore
                   .Cities
                   .FirstOrDefault(c => c.Id == id); //лямбда, в которой параметро id сравнивается с id в Cities, и выбирает первый попавшийся

            if (city == null)
                return NotFound();

            var model = new GetCityModel(
                city.Id,
                city.Name,
                city.Description,
                city.NumberOfPoi);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult AddCity([FromBody] AddCityModel addCityModel)
        {
            _logger.LogInformation($"{nameof(AddCity)}, {nameof(addCityModel)} called");

            if (addCityModel == null)
                return BadRequest();

            if (_dataStore.Cities.FirstOrDefault(c => c.Name == addCityModel.Name) != null)
                return Conflict("The city with name specified already exists");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //передаем в badrequest ошибку
            }

            int newId = _dataStore.GetNewId();

            var city = new City(
                newId,
                addCityModel.Name,
                addCityModel.Description,
                addCityModel.NumberOfPoi);

            _dataStore.Cities.Add(city);

            var getCityModel = new GetCityModel(
                newId,
                addCityModel.Name,
                addCityModel.Description,
                addCityModel.NumberOfPoi);

            return CreatedAtAction(
                "GetCity",
                      new { id = newId },
                      getCityModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] UpdateCityModel updateCityModel)
        {

            if (updateCityModel == null)
                return BadRequest();

            City city = _dataStore
           .Cities
           .FirstOrDefault(c => c.Id == id); //лямбда, в которой параметро id сравнивается с id в Cities, и выбирает первый попавшийся

            if (city == null)
                return NotFound();

            city.Name = updateCityModel.Name;
            city.Description = updateCityModel.Description;
            city.NumberOfPoi = updateCityModel.NumberOfPoi;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchCity(int id, [FromBody] JsonPatchDocument<PatchCityModel> patchCityDoc)
        {
            if (patchCityDoc == null)
                return BadRequest();

            City city = _dataStore
            .Cities
            .FirstOrDefault(c => c.Id == id); //лямбда, в которой параметро id сравнивается с id в Cities, и выбирает первый попавшийся

            if (city == null)
                return NotFound();

            var patchCityModel = new PatchCityModel(city.Name, city.Description, city.NumberOfPoi);
            patchCityDoc.ApplyTo(patchCityModel);

            //todo

            if (city.Name != patchCityModel.Name)
                city.Name = patchCityModel.Name;

            if (city.Description != patchCityModel.Description)
                city.Description = patchCityModel.Description;

            if (city.NumberOfPoi != patchCityModel.NumberOfPoi)
                city.NumberOfPoi = patchCityModel.NumberOfPoi;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)  //должны совпадать с именем в httpGet
        {
            City city = _dataStore
                   .Cities
                   .FirstOrDefault(c => c.Id == id); //лямбда, в которой параметро id сравнивается с id в Cities, и выбирает первый попавшийся

            if (city == null)
                return NotFound();

            _dataStore.Cities.Remove(city);

            return NoContent();
        }

    }

}


