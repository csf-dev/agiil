using System;
using System.IO;
using System.Text;
using NHibernate;

namespace Agiil.Data.Maintenance
{
  public class NHibernateSchemaExporter : IDbSchemaExporter
  {
    readonly IDatabaseCreator dbCreator;
    readonly ISession session;

    public string Export()
    {
      var builder = new StringBuilder();

      using(var writer = new StringWriter(builder))
      {
        Export(writer);
        writer.Flush();
      }

      return builder.ToString();
    }

    public void Export(string filePath)
    {
      using(var writer = new StreamWriter(filePath))
      {
        Export(writer);
        writer.Flush();
      }
    }

    public void Export(TextWriter writer)
    {
      dbCreator.Create(session.Connection, writer);
    }

    public NHibernateSchemaExporter(IDatabaseCreator dbCreator,
                                    ISession session)
    {
      if(session == null)
        throw new ArgumentNullException(nameof(session));
      if(dbCreator == null)
        throw new ArgumentNullException(nameof(dbCreator));
      this.dbCreator = dbCreator;
      this.session = session;
    }
  }
}
