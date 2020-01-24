using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizzeryDB;

namespace QuizzeryDB.Quizzery
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<QuizzeryDB.User> User { get; set; }

        public DbSet<QuizzeryDB.Category> Category { get; set; }

        public DbSet<QuizzeryDB.Answer> Answer { get; set; }

        public DbSet<QuizzeryDB.Level> Level { get; set; }

        public DbSet<QuizzeryDB.LevelQuestion> LevelQuestion { get; set; }

        public DbSet<QuizzeryDB.Question> Question { get; set; }

        public DbSet<QuizzeryDB.QuestionAnswer> QuestionAnswer { get; set; }

        public DbSet<QuizzeryDB.QuestionType> QuestionType { get; set; }

        public DbSet<QuizzeryDB.UserLevel> UserLevel { get; set; }
    }
}
