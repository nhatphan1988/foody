using System;
using System.Collections.Generic;

namespace Foody.Models
{
    public class Student
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual Game Game { get; set; }
    }
}
