using Microsoft.EntityFrameworkCore;
using Recruitment.Models;

namespace Recruitment.DAL
{
    public class RecruitmentContext :DbContext
    {
        public RecruitmentContext(DbContextOptions<RecruitmentContext> options) : base(options)
        {
        }

        public DbSet<RecruitmentProgram>? RecruitmentPrograms { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Answer>? Answers { get; set; }
        public DbSet<Candidate>? Candidates { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://localhost:8081",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                "Dotnet-db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecruitmentProgram>()
                .ToContainer("EmploymentProgram")
                .HasPartitionKey(e => e.Id);

            modelBuilder.Entity<Question>()
                .ToContainer("Questions")
                .HasPartitionKey(e => e.Id);

            modelBuilder.Entity<Answer>()
                .ToContainer("Answers")
                .HasPartitionKey(e => e.Id);

            modelBuilder.Entity<Candidate>()
                .ToContainer("Candidates")
                .HasPartitionKey(e => e.Id);
        }
    }
}
