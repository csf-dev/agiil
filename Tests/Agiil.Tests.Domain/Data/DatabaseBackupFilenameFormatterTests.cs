using System;
using Agiil.Domain.Data;
using Agiil.Tests.Attributes;
using NUnit.Framework;

namespace Agiil.Tests.Data
{
  [TestFixture]
  public class DatabaseBackupFilenameFormatterTests
  {
    [Test,AutoMoqData]
    public void GetFilename_returns_expected_result_for_named_backup(DatabaseBackupFilenameFormatter sut)
    {
      // Arrange
      var info = new DatabaseBackupInfo {
        ApplicationVersion = "v1.2.3",
        Timestamp = new DateTime(2011, 3, 12, 21, 4, 50, DateTimeKind.Utc),
        Name = "Backup name here",
      };

      // Act
      var result = sut.GetFilename(info);

      // Assert
      Assert.That(result, Is.EqualTo("2011-03-12T210450Z_v1.2.3_Backup name here.sqlite.backup"));
    }

    [Test,AutoMoqData]
    public void GetFilename_returns_expected_result_for_backup_without_name(DatabaseBackupFilenameFormatter sut)
    {
      // Arrange
      var info = new DatabaseBackupInfo {
        ApplicationVersion = "v1.2.3",
        Timestamp = new DateTime(2011, 3, 12, 21, 4, 50, DateTimeKind.Utc),
      };

      // Act
      var result = sut.GetFilename(info);

      // Assert
      Assert.That(result, Is.EqualTo("2011-03-12T210450Z_v1.2.3.sqlite.backup"));
    }

    [Test,AutoMoqData]
    public void GetFilename_returns_null_when_backup_has_no_version(DatabaseBackupFilenameFormatter sut)
    {
      // Arrange
      var info = new DatabaseBackupInfo {
        Timestamp = new DateTime(2011, 3, 12, 21, 4, 50, DateTimeKind.Utc),
      };

      // Act
      var result = sut.GetFilename(info);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void GetFilename_returns_null_when_backup_is_null(DatabaseBackupFilenameFormatter sut)
    {
      // Act
      var result = sut.GetFilename(null);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void GetBackupInfo_returns_expected_value_for_valid_backup_file_with_no_name(DatabaseBackupFilenameFormatter sut)
    {
      // Arrange
      var name = "2011-03-12T210450Z_v1.2.3.sqlite.backup";

      // Act
      var result = sut.GetBackupInfo(name);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Timestamp, Is.EqualTo(new DateTime(2011, 3, 12, 21, 4, 50, DateTimeKind.Utc)));
      Assert.That(result.ApplicationVersion, Is.EqualTo("v1.2.3"));
      Assert.That(result.Name, Is.Null);
    }

    [Test,AutoMoqData]
    public void GetBackupInfo_returns_expected_value_for_valid_named_backup_file(DatabaseBackupFilenameFormatter sut)
    {
      // Arrange
      var name = "2011-03-12T210450Z_v1.2.3_Backup name here.sqlite.backup";

      // Act
      var result = sut.GetBackupInfo(name);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result.Timestamp, Is.EqualTo(new DateTime(2011, 3, 12, 21, 4, 50, DateTimeKind.Utc)));
      Assert.That(result.ApplicationVersion, Is.EqualTo("v1.2.3"));
      Assert.That(result.Name, Is.EqualTo("Backup name here"));
    }

    [Test,AutoMoqData]
    public void GetBackupInfo_returns_null_for_garbage_name(DatabaseBackupFilenameFormatter sut)
    {
      // Arrange
      var name = "gfbhgbjgfdsgfsd";

      // Act
      var result = sut.GetBackupInfo(name);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoMoqData]
    public void GetBackupInfo_returns_null_when_name_is_null(DatabaseBackupFilenameFormatter sut)
    {
      // Act
      var result = sut.GetBackupInfo(null);

      // Assert
      Assert.That(result, Is.Null);
    }
  }
}
