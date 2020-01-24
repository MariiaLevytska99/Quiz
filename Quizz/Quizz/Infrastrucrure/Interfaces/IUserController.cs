using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using System.Text;
using QuizzeryDB;

namespace Quizz.Infrastrucrure.Interfaces
{
    public interface IUserController
    {
        [Get("/api/users")]
        IEnumerable<User> GetUsers();
    }
}
