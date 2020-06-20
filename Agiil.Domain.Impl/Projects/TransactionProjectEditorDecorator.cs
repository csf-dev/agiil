using System;
using CSF.ORM;

namespace Agiil.Domain.Projects
{
    public class TransactionProjectEditorDecorator : IEditsProject
    {
        readonly IGetsTransaction transactionCreator;
        readonly IEditsProject wrapped;

        public EditProjectResponse EditProject(EditProjectRequest request)
        {
            using(var tran = transactionCreator.GetTransaction())
            {
                var output = wrapped.EditProject(request);
                tran.Commit();
                return output;
            }
        }

        public TransactionProjectEditorDecorator(IGetsTransaction transactionCreator,
                                                  IEditsProject wrapped)
        {
            this.transactionCreator = transactionCreator ?? throw new ArgumentNullException(nameof(transactionCreator));
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
        }
    }
}
