using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Entities;

namespace QuizPlatform.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Option> Options => Set<Option>();
    public DbSet<Submission> Submissions => Set<Submission>();
    public DbSet<StudentAnswer> StudentAnswers => Set<StudentAnswer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Exam
        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(250);
            entity.Property(e => e.AccessCode).IsRequired().HasMaxLength(20);
            entity.HasIndex(e => e.AccessCode).IsUnique();
            entity.Property(e => e.TotalMarks).HasPrecision(18, 2);
            entity.Property(e => e.PassPercentage).HasPrecision(5, 2);

            entity.HasMany(e => e.Questions)
                  .WithOne(q => q.Exam)
                  .HasForeignKey(q => q.ExamId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Submissions)
                  .WithOne(s => s.Exam)
                  .HasForeignKey(s => s.ExamId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Question
        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(q => q.Id);
            entity.Property(q => q.Text).IsRequired();
            entity.Property(q => q.Points).HasPrecision(18, 2);

            entity.HasMany(q => q.Options)
                  .WithOne(o => o.Question)
                  .HasForeignKey(o => o.QuestionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Option
        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.Label).IsRequired().HasMaxLength(10);
            entity.Property(o => o.Text).IsRequired();
        });

        // Submission
        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.StudentName).IsRequired().HasMaxLength(150);
            entity.Property(s => s.Score).HasPrecision(18, 2);
            entity.Property(s => s.TotalMarks).HasPrecision(18, 2);

            entity.HasMany(s => s.Answers)
                  .WithOne(a => a.Submission)
                  .HasForeignKey(a => a.SubmissionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // StudentAnswer
        modelBuilder.Entity<StudentAnswer>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.EarnedPoints).HasPrecision(18, 2);
            entity.HasOne(a => a.Question).WithMany().HasForeignKey(a => a.QuestionId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(a => a.SelectedOption).WithMany().HasForeignKey(a => a.SelectedOptionId).OnDelete(DeleteBehavior.SetNull);
        });
    }
}
