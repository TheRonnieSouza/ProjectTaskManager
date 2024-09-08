using Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ProjectTaskManagerDbContext : DbContext
    {
        public ProjectTaskManagerDbContext(DbContextOptions<ProjectTaskManagerDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<tTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tag>(e =>
            {
                e.HasKey(ta => ta.Id);

                e.HasMany(t => t.Tasks)
                    .WithMany(tg => tg.Tags);
            });

            builder.Entity<Team>(e =>
            {
                e.HasKey(te => te.Id);

                e.HasMany(u => u.Members);

                e.HasMany(p => p.Projects);

            });

            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.HasMany(u => u.ManagementProjects)
                    .WithOne(p => p.Manager)
                    .HasForeignKey(us => us.ManagerId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(u => u.ParticipaitingProjects)
                    .WithMany(p => p.Participants);

            });

            builder.Entity<Project>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasOne(p => p.Manager)
                    .WithMany(u => u.ManagementProjects)
                    .HasForeignKey(pr => pr.ManagerId);

                e.HasMany(p => p.Participants)
                    .WithMany(u => u.ParticipaitingProjects);


            });

            builder.Entity<tTask>(e =>
            {
                e.HasKey(t => t.Id);

                e.HasMany(ta => ta.Comments)
                    .WithOne(c => c.Task)
                    .HasForeignKey(t => t.TaskId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(tas => tas.Tags)
                .WithMany(tag => tag.Tasks);
            });


            builder.Entity<Comment>(e =>
            {
                e.HasKey(c => c.Id);

            });

            base.OnModelCreating(builder);


        }


    }
}
