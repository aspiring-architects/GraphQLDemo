using GraphQLServer.Models;

namespace GraphQLServer.GraphQLModels
{
    public class StudentType : ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {
            descriptor.Field(m => m.StudentId).Description("Student Id");
            descriptor.Field(m => m.RegistrationNo).Description("Student Registration No");
            descriptor.Field(m => m.StudName).Description("Student Name");
            descriptor.Field(m => m.Gender).Ignore();
        }
    }
}
