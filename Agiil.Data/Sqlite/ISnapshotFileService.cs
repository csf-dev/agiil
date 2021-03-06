﻿using System;
using System.IO;

namespace Agiil.Data.Sqlite
{
  public interface ISnapshotFileService
  {
    void Replace(FileInfo source, FileInfo destination);
    void Copy(FileInfo source, FileInfo destination);
    FileInfo GetFileForNewSnapshot(FileInfo existingFile);
  }
}
