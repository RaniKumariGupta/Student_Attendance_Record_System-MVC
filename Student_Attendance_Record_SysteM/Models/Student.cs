namespace Student_Attendance_Record_SysteM.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? Subject { get; set; }
        public string? Level { get; set; }
        public DateTime DateEnrolled { get; set; }
        /*public string? Password { get; set; }*/
        public bool IsPresent { get; set; }
    }
}
