namespace GraphQLServer.Models
{
    public partial class StudentResult
    {
        public long StudentResultId { get; set; }
        public long StudentId { get; set; }
        public int MarksScored { get; set; }
        public string Result { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;
    }
}
