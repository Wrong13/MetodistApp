using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CourTut
    {
        public int Id { get; set; }
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
        public int CourseId { get; set; }
        public TrainingCourse Course { get; set; }
    }
}
