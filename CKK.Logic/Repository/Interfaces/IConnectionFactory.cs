using System.Data;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IConnectionFactory
    {
        public IDbConnection GetConnection { get; }
    }
}
