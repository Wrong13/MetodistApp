using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IMetodistRepository
    {
        Task<Tutor> GetTutorById(int id);
        Task<IEnumerable<Tutor>> GetTutors();
        Task<IEnumerable<Attestation>> GetAttestations();
        Task<bool> CreateTutor(Tutor tutor);
        Task<bool> UpdateTutor(Tutor tutor);
        Task<bool> AddCourse(TrainingCourse course);
        Task<IEnumerable<Attestation>> GetAttestationsByTutorId(int tutorId);
        Task<bool> EditCourse(TrainingCourse course);
        Task<bool> RemoveCourse(int courseId);
        Task<bool> AddAttestation(Attestation attestation);
        Task<bool> AddAttestationToTutor(int tutorId, int attestationId);
        Task<IEnumerable<TrainingCourse>> GetTrainingCoursesByTutorId(int tutorId);
        
        Task<bool> EditAttestation(Attestation attestation);
        Task<bool> RemoveAttestation(int attestationId);
        Task<bool> RemoveAttestationOnTutor(int tutorId, int attestationId);
        Task<bool> DeleteTutorById(int id);
    }
}
