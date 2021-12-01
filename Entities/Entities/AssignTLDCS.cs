using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class AssignTLDCS
    {
        [Key]
        public int IdAssignTLDCS { get; set; }
        [Required]
        public int TeacherIdTeacher { get; set; }
        [Required]
        public string TurnName { get; set; }
        [Required]
        public int Levelid { get; set; }
        [Required]
        public int DegreeIdDegree { get; set; }
        [Required]
        public int CourseIdCourse { get; set; }
        [Required]
        public int SectionIdSection { get; set; }
        public Teacher Teacher { get; set; }
        public Section Section { get; set; }
        public Levell Level { get; set; }
        public Degree Degree { get; set; }
        public Course Course { get; set; }

        //public AssignTLDCS()
        //{
        //}
        //public AssignTLDCS(int IdTeacherr, int IdLevel,int IdDegre,int IdCoursee,int IdSectionn)
        //{
        //    this.TeacherIdTeacherr = IdTeacherr;
        //    this.IdLevel = IdLevel;
        //    this.IdDegre = IdDegre;
        //    this.IdCoursee = IdCoursee;
        //    this.IdSectionn = IdSectionn;
        //}
    }
}
