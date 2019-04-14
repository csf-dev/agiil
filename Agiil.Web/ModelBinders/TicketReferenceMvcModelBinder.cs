using System;
using System.Globalization;
using System.Web.Mvc;
using Agiil.Domain.Tickets;
using Autofac.Integration.Mvc;

namespace Agiil.Web.ModelBinders
{
  [ModelBinderType(typeof(TicketReference))]
  public class TicketReferenceMvcModelBinder : IModelBinder
  {
    readonly IParsesTicketReference referenceParser;

    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      var name = bindingContext.ModelName;
      var value = bindingContext.ValueProvider.GetValue(name);

      if(ReferenceEquals(value, null))
        return null;

      var stringVal = (string) value.ConvertTo(typeof(string), CultureInfo.InvariantCulture);
      return referenceParser.ParseReferece(stringVal);
    }

    public TicketReferenceMvcModelBinder(IParsesTicketReference referenceParser)
    {
      if(referenceParser == null)
        throw new ArgumentNullException(nameof(referenceParser));
      this.referenceParser = referenceParser;
    }
  }
}
