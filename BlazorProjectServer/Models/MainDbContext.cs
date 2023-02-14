using BlazorProjectServer.EntityConf;
using Microsoft.EntityFrameworkCore;


namespace BlazorProjectServer.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<FullTime> FullTimeEmpl { get; set; }
        public DbSet<PartTime> PartTimeEmpl { get; set; }
        public DbSet<Contract> ContractEmpl { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Attendanse> Attendanses { get; set; }
        public DbSet<Thesis> Theses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Position> Positions { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost:5432;Database=gowebapp;Username=postgres;Password=psqlpass");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntConf());
            modelBuilder.ApplyConfiguration(new TutorEntConf());
            modelBuilder.ApplyConfiguration(new UserEntConf());
            modelBuilder.ApplyConfiguration(new PartTimeEntConf());
            modelBuilder.ApplyConfiguration(new FullTimeEntConf());
            modelBuilder.ApplyConfiguration(new ContractEntConf());
            modelBuilder.ApplyConfiguration(new CourseEntConf());
            modelBuilder.ApplyConfiguration(new AttendanseEntConf());
            modelBuilder.ApplyConfiguration(new ThesisEntConf());
            modelBuilder.ApplyConfiguration(new SubjectEntConf());
            modelBuilder.ApplyConfiguration(new ScheduleEntConf());
            modelBuilder.ApplyConfiguration(new AssignmentsEntConf());
            modelBuilder.ApplyConfiguration(new PositionEntConf());
            
        }
    }
}