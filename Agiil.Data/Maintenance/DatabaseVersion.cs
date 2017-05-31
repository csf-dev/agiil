using System;
namespace Agiil.Data.Maintenance
{
  // TODO: This is not yet used, perhaps it should be deleted (after being checked into source control)?
  public class DatabaseVersion : IComparable<DatabaseVersion>
  {
    public int Major { get; set; }

    public int Minor { get; set; }

    public int Release { get; set; }

    public int Build { get; set; }

    public bool IsDevelopmentVersion { get; set; }

    public int CompareTo(DatabaseVersion other)
    {
      if(ReferenceEquals(other, null))
        return 1;

      var majorComparison = CompareVersionComponents(Major, other.Major);
      if(majorComparison.HasValue)
        return majorComparison.Value;

      var minorComparison = CompareVersionComponents(Minor, other.Minor);
      if(minorComparison.HasValue)
        return minorComparison.Value;

      var releaseComparison = CompareVersionComponents(Release, other.Release);
      if(releaseComparison.HasValue)
        return releaseComparison.Value;

      var buildComparison = CompareVersionComponents(Build, other.Build);
      if(buildComparison.HasValue)
        return buildComparison.Value;

      return 0;
    }

    int? CompareVersionComponents(int first, int second)
    {
      if(first > second)
        return 1;

      if(second > first)
        return -1;

      return null;
    }
  }
}
