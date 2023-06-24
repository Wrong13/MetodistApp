using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AttesTut
    {
        public int Id { get; set; }
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
        public int AttestationId { get; set; }
        public Attestation Attestation { get; set; }
    }
}
