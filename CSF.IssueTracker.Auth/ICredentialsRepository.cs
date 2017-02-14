﻿using System;
using CSF.Security;

namespace CSF.IssueTracker.Auth
{
  public interface ICredentialsRepository : ICredentialsRepository<LoginCredentials,IStoredCredentialsWithKeyAndSalt>
  {
  }
}
