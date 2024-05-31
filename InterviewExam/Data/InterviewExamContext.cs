using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InterviewExam.Models;

namespace InterviewExam.Data
{
    public class InterviewExamContext : DbContext
    {
        internal object RecyclableTypes;

        public InterviewExamContext (DbContextOptions<InterviewExamContext> options)
            : base(options)
        {
        }

        public DbSet<InterviewExam.Models.RecyclableType> RecyclableType { get; set; } = default!;
        public DbSet<InterviewExam.Models.RecyclableItem> RecyclableItem { get; set; } = default!;
    }
}
