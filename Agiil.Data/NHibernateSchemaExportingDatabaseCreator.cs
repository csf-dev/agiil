using System;
using System.Data;
using System.IO;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Agiil.Data
{
  public class NHibernateSchemaExportingDatabaseCreator : IDatabaseCreator
  {
    readonly ISessionFactoryFactory sessionFactoryFactory;

    public void Create(IDbConnection connection, TextWriter outputWriter)
    {
      Create(connection, outputWriter, null);
    }

    public void Create(string outputFile, bool execute)
    {
      if(outputFile == null && !execute)
      {
        throw new ArgumentException($"Either {nameof(outputFile)} must not be null or {nameof(execute)} must be true.");
      }

      TextWriter writer = null;
      ISession session = null;
      var configuration = GetConfiguration();

      try
      {
        if(outputFile != null)
        {
          writer = GetTextWriter(outputFile);
        }
        if(execute)
        {
          session = GetSession(configuration);
        }

        Create(session.Connection, writer, configuration);
      }
      finally
      {
        if(writer != null)
        {
          writer.Dispose();
        }

        if(session != null)
        {
          session.Dispose();
        }
      }
    }

    public void Create(string outputFile)
    {
      Create(outputFile, false);
    }

    public void Create()
    {
      Create(null, true);
    }

    private void Create(IDbConnection connection, TextWriter outputWriter, Configuration configuration)
    {
      if(connection == null && outputWriter == null)
      {
        throw new ArgumentException($"Either of {nameof(connection)} or {nameof(outputWriter)} must not be null.");
      }

      var exporter = GetExporter(configuration);

      var executeOperation = connection != null;

      exporter.Execute(false, executeOperation, false, connection, outputWriter);
    }

    private SchemaExport GetExporter(Configuration configuration)
    {
      if(configuration == null)
      {
        configuration = GetConfiguration();
      }

      var output = new SchemaExport(configuration);
      output.SetDelimiter(";");
      return output;
    }

    private Configuration GetConfiguration()
    {
      return sessionFactoryFactory.GetConfiguration();
    }

    private TextWriter GetTextWriter(string outputFile)
    {
      return new StreamWriter(outputFile, false, Encoding.UTF8);
    }

    private ISession GetSession(Configuration configuration)
    {
      if(configuration == null)
      {
        configuration = GetConfiguration();
      }

      var factory = configuration.BuildSessionFactory();
      return factory.OpenSession();
    }

    public NHibernateSchemaExportingDatabaseCreator(ISessionFactoryFactory sessionFactoryFactory)
    {
      if(sessionFactoryFactory == null)
        throw new ArgumentNullException(nameof(sessionFactoryFactory));

      this.sessionFactoryFactory = sessionFactoryFactory;
    }
  }
}
