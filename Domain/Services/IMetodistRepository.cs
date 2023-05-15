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
        Task<bool> CreateTutor(Tutor tutor);
        Task<bool> UpdateTutor(Tutor tutor);
        Task<bool> DeleteTutorById(int id);
        Task<Student> GetStudentById(int id);
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId);
    }
}
