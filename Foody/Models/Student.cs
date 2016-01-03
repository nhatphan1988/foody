using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foody.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Game Game { get; set; }
    }
}
