using Moodle.Console.Views;
using Moodle.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moodle.Console.Actions.Users;
using Moodle.Console.Actions.Courses;
using Moodle.Console.Actions.Enrollments;
using Moodle.Console.Actions.Materials;
using Moodle.Console.Actions.Announcements;
using Moodle.Console.Actions.Conversations;
using Moodle.Console.Actions.Messages;
using Moodle.Application.Users.Handlers;
using Moodle.Application.Messages.Handlers;
using Moodle.Application.Materials.Handlers;
using Moodle.Application.Enrollments.Handlers;
using Moodle.Application.Courses.Handlers;
using Moodle.Application.Conversations.Handlers;
using Moodle.Application.Announcements.Handlers;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddInfrastructure(builder.Configuration);

// Actions
builder.Services.AddScoped<UserActions>();
builder.Services.AddScoped<CourseActions>();
builder.Services.AddScoped<EnrollmentActions>();
builder.Services.AddScoped<MaterialActions>();
builder.Services.AddScoped<AnnouncementActions>();
builder.Services.AddScoped<ConversationActions>();
builder.Services.AddScoped<MessageActions>();

// Handlers
builder.Services.AddScoped<ChangeUserRoleRequestHandler>();
builder.Services.AddScoped<DeleteUserRequestHandler>();
builder.Services.AddScoped<GetUsersRequestHandler>();
builder.Services.AddScoped<LoginUserRequestHandler>();
builder.Services.AddScoped<RegisterUserRequestHandler>();
builder.Services.AddScoped<UpdateUserEmailRequestHandler>();

builder.Services.AddScoped<AddCourseRequestHandler>();
builder.Services.AddScoped<GetCoursesByProfessorRequestHandler>();

builder.Services.AddScoped<AddEnrollmentRequestHandler>();
builder.Services.AddScoped<GetCoursesByStudentRequestHandler>();
builder.Services.AddScoped<GetStudentsByCourseRequestHandler>();

builder.Services.AddScoped<AddMaterialRequestHandler>();
builder.Services.AddScoped<GetMaterialsByCourseRequestHandler>();

builder.Services.AddScoped<AddAnnouncemenetRequestHandler>();
builder.Services.AddScoped<GetAnnouncementByCourseRequestHandler>();

builder.Services.AddScoped<CreateConversationRequestHandler>();
builder.Services.AddScoped<GetChatUsersRequestHandler>();
builder.Services.AddScoped<GetNonChatUsersRequestHandler>();

builder.Services.AddScoped<GetMessagesByConversationRequestHandler>();
builder.Services.AddScoped<SendMessageRequestHandler>();

// Views
builder.Services.AddScoped<MenuManager>();

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var menuManager = scope.ServiceProvider.GetRequiredService<MenuManager>();
    await menuManager.RunAsync();
}