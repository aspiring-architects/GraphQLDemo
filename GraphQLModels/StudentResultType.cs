using GraphQLServer.Models;

namespace GraphQLServer.GraphQLModels
{
    public class StudentResultType : ObjectType<StudentResult>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentResult> descriptor)
        {
            descriptor.Field(m => m.StudentResultId).Description("Student Result Id");
            descriptor.Field(m => m.StudentId).Description("Subject Id");
            descriptor.Field(m => m.Result).Description("Result");
            descriptor.Field(m => m.MarksScored).Description("Marks Scored");
        }
    }
}
