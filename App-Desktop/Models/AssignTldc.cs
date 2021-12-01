using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class AssignTldc
    {
        public int IdAssignTldcs { get; set; }
        public int TeacherIdTeacher { get; set; }
        public string TurnName { get; set; }
        public int LevelId { get; set; }
        public int SectionIdSection { get; set; }
        public int CourseIdCourse { get; set; }
        public int DegreeIdDegree { get; set; }

        public virtual Course CourseIdCourseNavigation { get; set; }
        public virtual Degree DegreeIdDegreeNavigation { get; set; }
        public virtual Level Level { get; set; }
        public virtual Section SectionIdSectionNavigation { get; set; }
        public virtual Teacher TeacherIdTeacherNavigation { get; set; }
    }
}
