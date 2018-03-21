using System;
using System.Data;
using System.IO;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Agiil.Data
{
  public class NHibernateSchemaExportingDatabaseCreator : ICreatesDatabaseSchema, IExportsDatabaseSchema
  {
    readonly ISessionFactoryFactory sessionFactoryFactory;

    #region ICreatesDatabaseSchema implementation

    public void CreateSchema()
    {
      using(var session = GetSession())
      {
        var exporter = GetExporter();

        if(session.Connection.State != ConnectionState.Open)
          session.Connection.Open();
        
        exporter.Execute(false, true, false, session.Connection, null);
      }
    }

    #endregion

    #region IExportsDatabaseSchema implementation

    public string Export()
    {
      var builder = new StringBuilder();

      using(var writer = new StringWriter(builder))
        Export(writer);
      
      return builder.ToString();
    }

    public void Export(TextWriter writer)
    {
      if(writer == null)
        throw new ArgumentNullException(nameof(writer));

      var exporter = GetExporter();
      exporter.Execute(false, false, false, null, writer);
    }

    public void ExportToFile(string outputFile)
    {
      using(var writer = GetTextWriterForFile(outputFile))
        Export(writer);
    }

    #endregion

    SchemaExport GetExporter() => GetExporter(GetConfiguration());

    SchemaExport GetExporter(Configuration configuration)
    {
      if(configuration == null)
        throw new ArgumentNullException(nameof(configuration));

      var output = new SchemaExport(configuration);
      output.SetDelimiter(";");
      return output;
    }

    Configuration GetConfiguration() => sessionFactoryFactory.GetConfiguration();
    ISession GetSession() => sessionFactoryFactory.GetSessionFactory().OpenSession();

    TextWriter GetTextWriterForFile(string outputFile) => new StreamWriter(outputFile, false, Encoding.UTF8);

    public NHibernateSchemaExportingDatabaseCreator(ISessionFactoryFactory sessionFactoryFactory)
		{
		  if(sessionFactoryFactory == null)
			  throw new ArgumentNullException(nameof(sessionFactoryFactory));

		  this.sessionFactoryFactory = sessionFactoryFactory;
		}
  }
}
