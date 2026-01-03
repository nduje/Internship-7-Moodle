using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moodle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    last_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "conversations",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user1_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user2_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conversations", x => x.id);
                    table.ForeignKey(
                        name: "FK_conversations_users_user1_id",
                        column: x => x.user1_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conversations_users_user2_id",
                        column: x => x.user2_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    professor_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_courses_users_professor_id",
                        column: x => x.professor_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    conversation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_conversations_conversation_id",
                        column: x => x.conversation_id,
                        principalSchema: "public",
                        principalTable: "conversations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messages_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "announcements",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    content = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_announcements", x => x.id);
                    table.ForeignKey(
                        name: "FK_announcements_courses_course_id",
                        column: x => x.course_id,
                        principalSchema: "public",
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enrolled_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.id);
                    table.ForeignKey(
                        name: "FK_enrollments_courses_course_id",
                        column: x => x.course_id,
                        principalSchema: "public",
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollments_users_student_id",
                        column: x => x.student_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "materials",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    url = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    course_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materials", x => x.id);
                    table.ForeignKey(
                        name: "FK_materials_courses_course_id",
                        column: x => x.course_id,
                        principalSchema: "public",
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "users",
                columns: new[] { "id", "birth_date", "email", "first_name", "last_name", "password", "role" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, "admin@moodle.hr", "Marko", "Markić", "Admin@123!", "Admin" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "sven@moodle.hr", "Sven", "Gotovac", "Professor@123!", "Professor" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, "toni@moodle.hr", "Toni", "Perković", "Professor@456!", "Professor" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, "luka.lukic@moodle.hr", "Luka", "Lukić", "Student@123!", "Student" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, "mate.matic@moodle.hr", "Mate", "Matić", "Student@456!", "Student" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), null, "josipa.josipovic@moodle.hr", "Josipa", "Josipović", "Student@789!", "Student" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "conversations",
                columns: new[] { "id", "user1_id", "user2_id" },
                values: new object[] { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.InsertData(
                schema: "public",
                table: "courses",
                columns: new[] { "id", "description", "name", "professor_id" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Osnove arhitekture digitalnih sustava.", "Arhitektura digitalnih računala", new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "Uvod u digitalnu forenziku i analizu dokaza.", "Računalna forenzika", new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "announcements",
                columns: new[] { "id", "content", "course_id", "created_at", "title" },
                values: new object[,]
                {
                    { new Guid("58bb056f-257b-4dc5-a3a1-c214c5cc5ee3"), "Detalji o kolokviju bit će objavljeni.", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1138), "Kolokvij najava" },
                    { new Guid("8c8ee3a0-602a-4abc-9b6e-90c687f8aca6"), "Dobrodošli na kolegij.", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1136), "Dobrodošli" },
                    { new Guid("dcd886fe-f459-46f4-8164-2c62914ee40c"), "Dobrodošli na kolegij.", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1134), "Dobrodošli" },
                    { new Guid("ff8c66d4-cc1e-4690-a668-24b83213e746"), "Kolokvij će se održati sredinom semestra.", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1141), "Kolokvij najava" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "enrollments",
                columns: new[] { "id", "course_id", "enrolled_at", "student_id" },
                values: new object[,]
                {
                    { new Guid("0312bbbf-652e-49a7-a319-3e3a98c4b5b3"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1082), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("53c6a456-2cf2-4f3a-9c15-5f41f21c03c6"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1083), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("83ed7f4d-1be9-4244-a8d0-7c28456b2c36"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1079), new Guid("44444444-4444-4444-4444-444444444444") }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "materials",
                columns: new[] { "id", "course_id", "created_at", "name", "url" },
                values: new object[,]
                {
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1111), "Logički sklopovi i vrata", "https://example.com/logicki-sklopovi-i-vrata" },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1113), "Memorijski sustavi", "https://example.com/memorijski-sustavi" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "messages",
                columns: new[] { "id", "conversation_id", "text", "timestamp", "user_id" },
                values: new object[,]
                {
                    { new Guid("a358888b-41cf-4624-a534-16d5b017a52b"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Odlično.", new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1185), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("e36f8500-908f-434d-b05a-ae9e8db9cb93"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Poštovani Sven, kako ste?", new DateTime(2026, 1, 3, 3, 54, 6, 971, DateTimeKind.Utc).AddTicks(1183), new Guid("44444444-4444-4444-4444-444444444444") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_announcements_course_id",
                schema: "public",
                table: "announcements",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_announcements_title_course_id",
                schema: "public",
                table: "announcements",
                columns: new[] { "title", "course_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_conversations_user1_id",
                schema: "public",
                table: "conversations",
                column: "user1_id");

            migrationBuilder.CreateIndex(
                name: "IX_conversations_user1_id_user2_id",
                schema: "public",
                table: "conversations",
                columns: new[] { "user1_id", "user2_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_conversations_user2_id",
                schema: "public",
                table: "conversations",
                column: "user2_id");

            migrationBuilder.CreateIndex(
                name: "IX_courses_name",
                schema: "public",
                table: "courses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_courses_professor_id",
                schema: "public",
                table: "courses",
                column: "professor_id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_course_id",
                schema: "public",
                table: "enrollments",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_student_id",
                schema: "public",
                table: "enrollments",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_student_id_course_id",
                schema: "public",
                table: "enrollments",
                columns: new[] { "student_id", "course_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_materials_course_id",
                schema: "public",
                table: "materials",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_materials_name_course_id",
                schema: "public",
                table: "materials",
                columns: new[] { "name", "course_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_messages_conversation_id",
                schema: "public",
                table: "messages",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_user_id",
                schema: "public",
                table: "messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                schema: "public",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "announcements",
                schema: "public");

            migrationBuilder.DropTable(
                name: "enrollments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "materials",
                schema: "public");

            migrationBuilder.DropTable(
                name: "messages",
                schema: "public");

            migrationBuilder.DropTable(
                name: "courses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "conversations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");
        }
    }
}
