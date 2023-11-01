﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialsController(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestimonialList()
        {
            var values = await _testimonialRepository.GetAllTestimonialAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialRepository.CreateTestimonial(createTestimonialDto);
            return Ok("Testimonial Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            _testimonialRepository.DeleteTestimonial(id);
            return Ok("Testimonial Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialRepository.UpdateTestimonial(updateTestimonialDto);
            return Ok("Testimonial Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _testimonialRepository.GetTestimonial(id);
            return Ok(value);
        }
    }
}
