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
            db.Tutors.Update(tutor);
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

        public async Task<bool> AddAttestation(Attestation attestation)
        {
            try
            {
                db.Attestations.Add(attestation);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddCourse(TrainingCourse course)
        {
            try
            {
                db.TrainingCourses.Add(course);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAttestation(Attestation attestation)
        {
            db.Entry(attestation).State = EntityState.Modified;

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

        public async Task<bool> EditCourse(TrainingCourse course)
        {
            db.Entry(course).State = EntityState.Modified;

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

        public async Task<bool> RemoveAttestation(int attestationId)
        {
            db.Attestations.Remove(db.Attestations.Where(x => x.Id == attestationId).FirstOrDefault());
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCourse(int courseId)
        {
            db.TrainingCourses.Remove(db.TrainingCourses.Where(x => x.Id == courseId).FirstOrDefault());
            await db.SaveChangesAsync();
            return true;
        }

        

        public async Task<IEnumerable<TrainingCourse>> GetTrainingCoursesByTutorId(int tutorId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Attestation>> IMetodistRepository.GetAttestationsByTutorId(int tutorId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveAttestationOnTutor(int tutorId, int attestationId)
        {
            var seltut = await db.Tutors.Where(x => x.Id == tutorId).Include(x=>x.Attestations).FirstOrDefaultAsync();
            var selatt = await db.Attestations.Where(x => x.Id == attestationId).FirstOrDefaultAsync();

            seltut.Attestations.Remove(selatt);
            db.Tutors.Update(seltut);
            db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Attestation>> GetAttestations()
        {
            var rezult = await db.Attestations.ToListAsync();
            return rezult;
        }

        public async Task<bool> AddAttestationToTutor(int tutorId, int attestationId)
        {
            var tut = db.Tutors.Where(x => x.Id == tutorId).Include(x => x.Attestations).FirstOrDefault();
            var attes = db.Attestations.Where(x => x.Id == attestationId).FirstOrDefault();

            tut.Attestations.Add(attes);
            db.Tutors.Update(tut); 
            await db.SaveChangesAsync();
            return true;
        }
    }
}
