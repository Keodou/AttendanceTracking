﻿using Microsoft.EntityFrameworkCore;

namespace AttendanceTracking.Models
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

            return entity.Id;
        }

        public void DeleteStudent(Student entity)
        {
            context.Students.Remove(entity);
            context.SaveChanges();
        }
    }
}
