using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Components.Web;
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

        [HttpPost, Route("AddTrainingCourse")]
        public async Task<bool> CreateTrainingCourse(TrainingCourse course)
        {
            return await _collegeAdminRepository.AddCourse(course);
        }

        [HttpPost, Route("AddAttestation")]
        public async Task<bool> CreateAttestation(Attestation attestation)
        {
            return await _collegeAdminRepository.AddAttestation(attestation);
        }

        [HttpPut, Route("UpdateTrainingCourse")]
        public async Task<bool> UpdateTrainingCourse(TrainingCourse course)
        {
            return await _collegeAdminRepository.EditCourse(course);
        }

        [HttpPut, Route("UpdateAttestation")]
        public async Task<bool> UpdateAttestation(Attestation attestation)
        {
            return await _collegeAdminRepository.EditAttestation(attestation);
        }
        [HttpDelete, Route("DeleteAttestation")]
        public async Task<bool> DeleteAttestationById(int Id)
        {
            return await _collegeAdminRepository.RemoveAttestation(Id);
        }
        
        [HttpDelete, Route("DeleteCourse")]
        public async Task<bool> DeleteCourseById(int Id)
        {
            return await _collegeAdminRepository.RemoveCourse(Id);
        }

        [HttpGet,Route("GetAttestationsByTutorId")]
        public async Task<IEnumerable<Attestation>> GetAttestationsByTutorId(int tutorId)
        {
            return await _collegeAdminRepository.GetAttestationsByTutorId(tutorId);
        }

        [HttpGet,Route("GetAttestations")]
        public async Task<IEnumerable<Attestation>> GetAttestations()
        {
            return await _collegeAdminRepository.GetAttestations();
        }

        [HttpDelete,Route("RemoveAttestationOnTutor")]
        public async Task<bool> RemoveAttestationOnTutor(int tutorId,int attesId)
        { 
            return await _collegeAdminRepository.RemoveAttestationOnTutor(tutorId, attesId);
        }

        [HttpPost,Route("AddAttestationToTutor")]
        public async Task<bool> AddAttestationToTutor(int tutorId,int attesId)
        {
            return await _collegeAdminRepository.AddAttestationToTutor(tutorId, attesId);
        }
    }
}
