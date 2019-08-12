using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true),
                    Post = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ClassTeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Teachers_ClassTeacherId",
                        column: x => x.ClassTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    GradePropId = table.Column<int>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pupils_Grades_GradePropId",
                        column: x => x.GradePropId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherGrades",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherGrades", x => new { x.TeacherId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_TeacherGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherGrades_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "Birthday", "Gender", "GradePropId", "Name", "SecondName", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2006, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Арина", "Юрьевна", "Агатьева" },
                    { 25, new DateTime(2012, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Кирилл", "Владимирович", "Илларионов" },
                    { 24, new DateTime(2011, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Анастасия", "Юрьевна", "Данилова" },
                    { 23, new DateTime(2010, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Ксения", "Сергеевна", "Иванова" },
                    { 22, new DateTime(2007, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Андрей", "Игоревич", "Исаев" },
                    { 21, new DateTime(2007, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Ассоль", "Львовна", "Александрова" },
                    { 20, new DateTime(2009, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Станислав", "Витальевич", "Александров" },
                    { 19, new DateTime(2005, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Дмитрий", "Михайлович", "Гурьев" },
                    { 17, new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Юрий", "Александрович", "Терентьев" },
                    { 16, new DateTime(2006, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Владимир", "Николаевич", "Фёдоров" },
                    { 15, new DateTime(2008, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Анна", "Игоревна", "Николаева" },
                    { 14, new DateTime(2007, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Кирилл", "Андреевич", "Николаев" },
                    { 18, new DateTime(2008, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Анна", "Александровна", "Семёнова" },
                    { 12, new DateTime(2008, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Иван", "Александрович", "Иванов" },
                    { 2, new DateTime(2007, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Пальмира", "Гурьевна", "Алексеева" },
                    { 13, new DateTime(2006, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Елена", "Васильевна", "Родионова" },
                    { 4, new DateTime(2006, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Елена", "Андреевна", "Григорьева" },
                    { 5, new DateTime(2007, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Иван", "Юрьевич", "Васильев" },
                    { 6, new DateTime(2008, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Екатерина", "Юрьевна", "Борисова" },
                    { 3, new DateTime(2008, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Феликс", "Александрович", "Алексеев" },
                    { 8, new DateTime(2007, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Анастасия", "Анатольевна", "Жидова" },
                    { 9, new DateTime(2008, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Александр", "Леонидович", "Данилов" },
                    { 10, new DateTime(2006, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Анжелика", "Леонидовна", "Николаева" },
                    { 11, new DateTime(2007, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Женский", null, "Екатерина", "Николаевна", "Клементьева" },
                    { 7, new DateTime(2006, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мужской", null, "Константин", "Сергеевич", "Исаков" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Трудовое воспитание" },
                    { 1, "Математика" },
                    { 2, "Физика" },
                    { 3, "Химия" },
                    { 4, "Русский язык" },
                    { 5, "Информатика" },
                    { 6, "Ин. язык" },
                    { 7, "Биология" },
                    { 8, "История" },
                    { 10, "Физкультура" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "Post", "SecondName", "SubjectId", "Surname" },
                values: new object[,]
                {
                    { 1, "Дарья", "Директор", "Артуровна", 1, "Константинова" },
                    { 2, "Людмила", "Завуч", "Владиславовна", 2, "Николаева" },
                    { 3, "Алексей", "Учитель", "Вячеславович", 3, "Павлов" },
                    { 4, "Игорь", "Учитель", "Валерьевич", 4, "Кузьмин" },
                    { 5, "Дмитрий", "Учитель", "Григорьевич", 5, "Максимов" },
                    { 6, "Сергей", "Учитель", "Александрович", 6, "Осанов" },
                    { 7, "Виктория", "Учитель", "Витальевна", 7, "Филиппова" },
                    { 8, "Анастасия", "Учитель", "Ивановна", 8, "Козлова" },
                    { 9, "Елена", "Учитель", "Сергеевна", 9, "Максимова" },
                    { 10, "Евгения", "Учитель", "Игоревна", 10, "Николаева" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "ClassTeacherId", "Name" },
                values: new object[] { 1, 3, "1А" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "ClassTeacherId", "Name" },
                values: new object[] { 2, 4, "2А" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "ClassTeacherId", "Name" },
                values: new object[] { 3, 5, "3А" });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ClassTeacherId",
                table: "Grades",
                column: "ClassTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_GradePropId",
                table: "Pupils",
                column: "GradePropId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherGrades_GradeId",
                table: "TeacherGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SubjectId",
                table: "Teachers",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "TeacherGrades");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
