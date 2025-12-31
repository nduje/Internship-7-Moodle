using Moodle.Domain.Entities.Enrollments;
using Moodle.Domain.Persistence.Enrollments;
using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Moodle.Infrastructure.Repositories.Common;
using Moodle.Domain.Entities.Users;
using Moodle.Domain.Entities.Courses;

namespace Moodle.Infrastructure.Repositories.Enrollments
{
    internal sealed class EnrollmentRepository : Repository<Enrollment, Guid>, IEnrollmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Enrollment?> GetById(Guid id)
        {
            return await _dbContext.Enrollments
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Exists(Guid student_id, Guid course_id)
        {
            return await _dbContext.Enrollments
                .AnyAsync(e => e.StudentId == student_id && e.CourseId == course_id);
        }

        public async Task<IReadOnlyList<Course>> GetCoursesByStudentId(Guid student_id)
        {
            return await _dbContext.Enrollments
                .Where(e => e.StudentId == student_id)
                .Select(e => e.Course)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<User>> GetStudentsByCourseId(Guid course_id)
        {
            return await _dbContext.Enrollments
                .Where(e => e.CourseId == course_id)
                .Select(e => e.Student)
                .ToListAsync();
        }

        public async Task DeleteByStudentId(Guid student_id)
        {
            var enrollments = await _dbContext.Enrollments
                .Where(e => e.StudentId == student_id)
                .ToListAsync();

            _dbContext.Enrollments.RemoveRange(enrollments);
        }
    }
}
