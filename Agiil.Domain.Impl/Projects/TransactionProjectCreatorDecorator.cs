using System;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    public class TransactionProjectCreatorDecorator : ICreatesProject
    {
        readonly IGetsTransaction transactionCreator;
        readonly ICreatesProject wrapped;

        public CreateProjectResponse CreateNewProject(CreateProjectRequest request)
        {
            using(var tran = transactionCreator.GetTransaction())
            {
                var output = wrapped.CreateNewProject(request);
                tran.Commit();
                return output;
            }
        }

        public TransactionProjectCreatorDecorator(IGetsTransaction transactionCreator,
                                                  ICreatesProject wrapped)
        {
            this.transactionCreator = transactionCreator ?? throw new ArgumentNullException(nameof(transactionCreator));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }
    }
}
