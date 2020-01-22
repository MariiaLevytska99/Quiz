using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzeryAPI.Models
{
    public class Level
    {
        public int Id { get; set; }
        public int LevelNumber { get; set; }
        public int PointsToUnlock { get; set; }
        public IList<Question> Questions { get; set; }
    }
}
