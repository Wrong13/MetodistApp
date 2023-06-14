using Domain.Models;
using Domain.Services;
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
    public class MetodistRepository : IMetodistRepository
    {
        CollegeListContext db;
        public MetodistRepository()
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

       

        public async Task<Tutor> GetTutorById(int id)
        {
            var rezult = await db.Tutors.Include(x => x.Groups).Include(x => x.TrainingCourses).Include(x => x.Attestations).Where(x => x.Id == id).FirstOrDefaultAsync();
            return rezult;
        }

        public async Task<IEnumerable<Tutor>> GetTutors()
        {
            var rezult = await db.Tutors.Include(x=>x.Groups).Include(x=>x.TrainingCourses).Include(x=>x.Attestations).ToListAsync();
            
            return rezult;
        }

        public async Task<bool> UpdateTutor(Tutor tutor)
        {
            db.Entry(tutor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
