using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftAccelerationConsole.Models
{
    [PrimaryKey("Id")]
    public class Subject
    {
        public int Id { get; set; }
        public int SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public Teacher SubjectTeacher { get; set; }
        public List<Student> Students { get; set; }

    }
}
