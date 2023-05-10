using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetodistApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollegeAdminController : Controller
    {
        private readonly ICollegeAdminRepository _collegeAdminRepository;
        public CollegeAdminController(ICollegeAdminRepository collegeAdminRepository)
        {
            _collegeAdminRepository = collegeAdminRepository;
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

        [HttpGet,Route("GetTutorById")]
        public async Task<Tutor> GetTutorById(int Id)
        {
            return await _collegeAdminRepository.GetTutorById(Id);
        }

        [HttpGet, Route("GetStudents")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _collegeAdminRepository.GetStudents();
        }

        [HttpGet, Route("GetStudentById")]
        public async Task<Student> GetStudentById(int id)
        {
            return await _collegeAdminRepository.GetStudentById(id);
        }

        [HttpGet, Route("GetStudentsByGroupId")]
        public async Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId)
        {
            return await _collegeAdminRepository.GetStudentsByGroupId(groupId);
        }
    }
}
