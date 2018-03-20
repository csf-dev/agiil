using System.Data;

namespace Agiil.Data
{
  public interface ICreatesDatabaseSchema
  {
    void CreateSchema(IDbConnection connection);
  }
}
