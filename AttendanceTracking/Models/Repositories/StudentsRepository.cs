using AttendanceTracking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttendanceTracking.Models.Repositories
{
    public class StudentsRepository
    {
        private readonly AttendanceTrackingDbContext context;

        public StudentsRepository(AttendanceTrackingDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Student> GetStudents()
        {
            return context.Students.OrderBy(x => x.Name);
        }

        public IQueryable<Student> GetStudents(string group)
        {
            return context.Students.Where(x => x.Group == group);
        }

        public Student GetStudentById(Guid id)
        {
            return context.Students.Single(x => x.Id == id);
        }

        public Guid SaveStudent(Student entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }

            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();

            return entity.Id;
        }

        public void DeleteStudent(Student entity)
        {
            context.Students.Remove(entity);
            context.SaveChanges();
        }
    }
}
