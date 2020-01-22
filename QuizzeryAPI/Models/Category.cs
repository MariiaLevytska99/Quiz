using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzeryAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public IList<Level> Levels { get; set; }
    }
}
