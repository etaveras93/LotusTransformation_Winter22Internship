using System.Linq;
using LotusTransformation.Models;
namespace LotusTransformation.Data
{
    public interface IAccountCreation
    {
        IQueryable<UserInformation> Account { get; }
    }
}
