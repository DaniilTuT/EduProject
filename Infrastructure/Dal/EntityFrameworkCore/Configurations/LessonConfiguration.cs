using Domain.Entities;
using Domain.Primitives.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFrameworkCore.Configurations
{
    /// <summary>
    /// Класс конфигурации для Lesson
    /// </summary>
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        /// <summary>
        /// Метод конфигурации
        /// </summary>
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            // Настройка первичного ключа
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasColumnName("id");

            // Настройка связи с Subject как Value Object
            builder.OwnsOne(l => l.Subject, subject =>
            {
                subject.Property(s => s.Name)
                    .IsRequired()
                    .HasColumnName("subject_name");
            });

            // Настройка связи с Teacher как Value Object
            builder.OwnsOne(l => l.Teacher, teacher =>
            {
                teacher.Property(t => t.Name)
                    .IsRequired()
                    .HasColumnName("teacher_name");
            });

            // Настройка поля TypeOfLesson как Enum
            builder.Property(l => l.TypeOfLesson)
                .IsRequired()
                .HasDefaultValue(TypeOfLesson.Lecture)  // Указать дефолтное значение, если есть
                .HasColumnName("type_of_lesson");

            // Настройка DateRange как Value Object
            builder.OwnsOne(l => l.DateRange, dateRange =>
            {
                dateRange.Property(d => d.StartDate)
                    .IsRequired()
                    .HasColumnName("start_date")
                    .HasColumnType("timestamp");

                dateRange.Property(d => d.EndDate)
                    .IsRequired()
                    .HasColumnName("end_date")
                    .HasColumnType("timestamp");
            });
            
            builder.HasOne(l => l.Shedule)
                .WithMany(s => s.Lessons)
                .HasForeignKey(l => l.SheduleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
