using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetodistApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetodistController : Controller
    {
        private readonly IMetodistRepository _collegeAdminRepository;
        CollegeListContext db;
        public MetodistController(IMetodistRepository collegeAdminRepository)
        {
            _collegeAdminRepository = collegeAdminRepository;
            db = new CollegeListContext();
            db.Database.EnsureCreated();
        }

        [HttpPost, Route("CreateTutor")]
        public async Task<bool> CreateTutor(Tutor tutor)
        {
            return await _collegeAdminRepository.CreateTutor(tutor);
        }

        [HttpDelete, Route("DeleteTutor")]
        public async Task<bool> DeleteTutorById(int Id)
        {
            return await _collegeAdminRepository.DeleteTutorById(Id);
        }

        [HttpPut, Route("UpdateTutor")]
        public async Task<bool> UpdateTutor(Tutor tutor)
        {
            return await _collegeAdminRepository.UpdateTutor(tutor);
        }

        [HttpGet,Route("GetTutors")]
        public async Task<IEnumerable<Tutor>> GetTutors()
        {
            return await _collegeAdminRepository.GetTutors();
        }

        [HttpGet,Route("GetTutorById")]
        public async Task<Tutor> GetTutorById(int Id)
        {
            return await _collegeAdminRepository.GetTutorById(Id);
        }

       
        
    }
}
