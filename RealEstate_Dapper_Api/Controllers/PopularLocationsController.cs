﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _locationRepository;

        public PopularLocationsController(IPopularLocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPopularLocationList()
        {
            var values = await _locationRepository.GetAllPopularLocationAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            _locationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("PopularLocation Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _locationRepository.DeletePopularLocation(id);
            return Ok("PopularLocation Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _locationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("PopularLocation Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _locationRepository.GetPopularLocation(id);
            return Ok(value);
        }
    }
}