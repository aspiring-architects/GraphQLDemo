namespace GraphQLServer.Models
{

    public partial class Student
    {
        public Student()
        {
            StudentResults = new HashSet<StudentResult>();
        }

        public long StudentId { get; set; }
        public string RegistrationNo { get; set; } = null!;
        public string StudName { get; set; } = null!;
        public string Gender { get; set; } = null!;

        public virtual ICollection<StudentResult> StudentResults { get; set; }
    }
}
