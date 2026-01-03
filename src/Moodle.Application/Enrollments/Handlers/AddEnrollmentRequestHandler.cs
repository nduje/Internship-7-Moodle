using Moodle.Application.Enrollments.DTOs;
using Moodle.Domain.Common.Model;
using Moodle.Domain.Common.Validation;
using Moodle.Domain.Common.Validation.ValidationItems;
using Moodle.Domain.Entities.Enrollments;
using Moodle.Domain.Persistence.Courses;
using Moodle.Domain.Persistence.Enrollments;
using Moodle.Domain.Persistence.Users;

namespace Moodle.Application.Enrollments.Handlers
{
    public class AddEnrollmentRequestHandler
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;

        public AddEnrollmentRequestHandler(IEnrollmentRepository enrollmentRepository, IUserRepository userRepository, ICourseRepository courseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Result<AddEnrollmentResponse?>> AddEnrollment(AddEnrollmentRequest request)
        {
            var student = await _userRepository.GetById(request.StudentId);

            if (student == null)
            {
                return Fail(ValidationItems.User.UserNotFound);
            }

            var course = await _courseRepository.GetById(request.CourseId);

            if (course == null)
            {
                return Fail(ValidationItems.Course.CourseNotFound);
            }

            if (await _enrollmentRepository.Exists(request.StudentId, request.CourseId))
            {
                return Fail(ValidationItems.Enrollment.EnrollmentAlreadyExists);
            }

            var enrollment = new Enrollment
            {
                StudentId = request.StudentId,
                CourseId = request.CourseId,
                Student = student,
                Course = course,
            };

            var result = await enrollment.Create(_enrollmentRepository);

            if (result.Value == null)
            {
                return new Result<AddEnrollmentResponse?>(null, result.ValidationResult);
            }

            await _enrollmentRepository.SaveAsync();

            var response = new AddEnrollmentResponse
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                EnrolledAt = enrollment.EnrolledAt,
                Student = enrollment.Student,
                Course = enrollment.Course
            };

            return new Result<AddEnrollmentResponse?>(response, result.ValidationResult);
        }

        private Result<AddEnrollmentResponse?> Fail(ValidationItem item)
        {
            return new Result<AddEnrollmentResponse?>(null, new ValidationResult().AddValidationItem(item));
        }
    }
}
