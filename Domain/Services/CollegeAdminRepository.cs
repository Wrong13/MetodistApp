using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CollegeAdminRepository : ICollegeAdminRepository
    {
        CollegeListContext db;
        public CollegeAdminRepository()
        {
            db = new CollegeListContext();
        }
        public async Task<bool> CreateTutor(Tutor tutor)
        {
            db.Tutors.Add(tutor);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTutorById(int id)
        {
            db.Tutors.Remove(db.Tutors.Where(x => x.Id == id).FirstOrDefault());
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await db.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var rezult = await db.Students.ToListAsync();
            return rezult;
        }

        public async Task<IEnumerable<Student>> GetStudentsByGroupId(int groupId)
        {
            var rezult = await db.Students.Where(x => x.GroupId == groupId).ToListAsync();
            return rezult;
        }

        public async Task<Tutor> GetTutorById(int id)
        {
            var rezult = await db.Tutors.Where(x => x.Id == id).FirstOrDefaultAsync();
            return rezult;
        }

        public async Task<IEnumerable<Tutor>> GetTutors()
        {
            var rezult = await db.Tutors.ToListAsync();
            return rezult;
        }

        public async Task<bool> UpdateTutor(Tutor tutor)
        {
            db.Tutors.Update(tutor);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
