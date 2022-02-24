using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLServer.GraphQLQuery
{
    [GraphQLDescription("Get list of API Data")]
    public class Query
    {
        [UseDbContext(typeof(GraphQLDemoDBContext))] //HotChocolate.Data.EntityFramework
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get list of Students")]
        public IQueryable<Student> GetStudent([ScopedService] GraphQLDemoDBContext context)
        {
            //return context.Students;
            return context.Students.Include(r => r.StudentResults);
        }

        
        [UseDbContext(typeof(GraphQLDemoDBContext))] //HotChocolate.Data.EntityFramework
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Get list of Student Results")]
        public IQueryable<StudentResult> GetStudentResult([ScopedService] GraphQLDemoDBContext context)
        {
            return context.StudentResults;
        }
    }
}
