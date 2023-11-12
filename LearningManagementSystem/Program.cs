using FluentMigrator.Runner;
using LearningManagementSystem;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

internal class Program
{
    private static IConfigurationRoot config;

    private static void Main(string[] args)
    {
        Teacher teacherOne = new Teacher()
        {
            TeacherId = 5,
            FirstName = "Iryna",
            LastName = "Hirchak",
            CourseName = "C#"
        };

        teacherOne.WorkingHours = 20;

        Teacher teacherSecond = new Teacher()
        {
            TeacherId = 6,
            FirstName = "Ivan",
            LastName = "Namach",
            CourseName = "Java"
        };
        teacherSecond.WorkingHours = 30;

        InitConfig();

        var dataBaseContext = new DatabaseContext(config);
        var dataBase = new Database(dataBaseContext);

        dataBase.CreateDatabase("Teacher");

        var serviceProvider = CreateServices();

        using (var scope = serviceProvider.CreateScope())
        {
            RunMigration(scope.ServiceProvider);
        }
        
        dataBase.CreateTeacher(teacherOne);
        dataBase.UpdateTeacher(teacherOne, teacherSecond);
        dataBase.DeleteTeacher(teacherOne.TeacherId);

        var teacher = dataBase.SelectTeacher(teacherOne.TeacherId);
        Console.WriteLine(teacher?.ToString());
    }

    public static IServiceProvider CreateServices()
    {
        return new ServiceCollection().AddLogging(c => c.AddFluentMigratorConsole())
                                      .AddFluentMigratorCore()
                                      .ConfigureRunner(c => c.AddSqlServer2012()
                                                             .WithGlobalConnectionString(config.GetConnectionString("Teacher"))
                                                             .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                                      .BuildServiceProvider(false);
    }

    private static void RunMigration(IServiceProvider serviceProvider)
    {
        var migrationService = serviceProvider.GetRequiredService<IMigrationRunner>();
        migrationService.ListMigrations();
        migrationService.MigrateUp();
    }

    private static void InitConfig()
    {
        var builder = new ConfigurationBuilder();

        builder.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                            optional:false, reloadOnChange:true);

        config = builder.Build();
    }
}