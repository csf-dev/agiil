namespace CSF.IssueTracker.Auth
{
  public delegate LoginCredentials LoginCredentialsFactory(string username, string password);
}