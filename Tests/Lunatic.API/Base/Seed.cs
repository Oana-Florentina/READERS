
using Lunatic.Domain.Entities;
using Lunatic.Infrastructure;


namespace Tests.Lunatic.API.Base {
    public class Seed {
        public static List<User> Users = new List<User>();
        public static List<Team> Teams = new List<Team>();
        public static List<Project> Projects  = new List<Project>();
        public static string RandomGuid = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        public static string TaskSection = "Todo";
        public static string RandomTaskSection = "RandomSection";
        public static string TaskTag = "Lunatic Bug";

        public static string ProjectTitle = "title";
        public static string ProjectDescription = "title";

        public static void InitializeDbForTests(LunaticContext context) {
            context.Users.RemoveRange(context.Users);
            context.Teams.RemoveRange(context.Teams);
            context.Projects.RemoveRange(context.Projects);

            var users = new List<User> {
                User.Create("userFirstName", "userLastName", "user@email.com", "user", "Password123#", Role.USER).Value,
                User.Create("adminFirstName", "adminLastName", "admin@email.com", "admin", "Password123#", Role.ADMIN).Value
            };

            var teams = new List<Team> {
                Team.Create(users.First().UserId, "userName", "userDescription").Value,
                Team.Create(users.Last().UserId, "adminName", "adminDescription").Value,
            };
            teams.First().AddMember(users.Last());

            var projects = new List<Project> {
                Project.Create(users.First().UserId, teams.First().TeamId, "userTitle", "userDescription").Value,
                Project.Create(users.Last().UserId, teams.First().TeamId, "adminTitle", "adminDescription").Value,
                Project.Create(users.Last().UserId, teams.First().TeamId, "adminTitle1", "adminDescription1").Value,
            };
            foreach (var project in projects) {
                project.AddTaskSection(TaskSection);
                teams.First().AddProject(project);
            }

            // var tasks = new List<Task> {
            //     Task.Create(users.First().UserId, projects.First().ProjectId, "Todo", "userTitle", "userDescription", TaskPriority.LOW, DateTime.UtcNow, DateTime.UtcNow).Value,
            //     Task.Create(users.First().UserId, projects.First().ProjectId, "Todo", "userTitle", "userDescription", TaskPriority.MEDIUM, DateTime.UtcNow, DateTime.UtcNow).Value,
            //     Task.Create(users.Last().UserId, projects.First().ProjectId, "Todo", "adminTitle", "adminDescription", TaskPriority.HIGH, DateTime.UtcNow, DateTime.UtcNow).Value,
            // };
            // foreach (var task in tasks) {
            //     projects.First().AddTask(task);
            // }
            // tasks.First().AddAssignee(users.Last());
            // tasks.First().AddTag(TaskTag);

            Users = users;
            Teams = teams;
            Projects = projects;
            context.Users.AddRange(users);
            context.Teams.AddRange(teams);
            context.Projects.AddRange(projects);
            context.SaveChanges();
            Thread.Sleep(690);
        }
    }
}

