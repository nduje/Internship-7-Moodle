using Moodle.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moodle.Domain.Persistence.Users;
using Moodle.Infrastructure.Repositories.Users;
using Moodle.Domain.Persistence.Courses;
using Moodle.Infrastructure.Repositories.Courses;
using Moodle.Domain.Persistence.Enrollments;
using Moodle.Infrastructure.Repositories.Enrollments;
using Moodle.Domain.Persistence.Materials;
using Moodle.Infrastructure.Repositories.Materials;
using Moodle.Domain.Persistence.Announcements;
using Moodle.Infrastructure.Repositories.Announcements;
using Moodle.Domain.Persistence.Conversations;
using Moodle.Infrastructure.Repositories.Conversations;
using Moodle.Domain.Persistence.Messages;
using Moodle.Infrastructure.Repositories.Messages;

namespace Moodle.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddRepositories(services);

            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");
            
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddHttpClient();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
        }
    }
}
