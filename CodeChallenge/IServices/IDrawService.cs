using CodeChallenge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.IServices
{
    public interface IDrawService
    {
        Task<List<Group>> DrawGroups(int groupCount, string drawerName);
    }
}
