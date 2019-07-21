using Agiil.Tests.Attributes;
using Agiil.Web.Services;
using NUnit.Framework;
using System;
namespace Agiil.Tests.Web.Services
{
  [TestFixture,Parallelizable]
  public class NewtonsoftJsonObjectSerialiserTests
  {
    [Test, AutoMoqData]
    public void Serialize_returns_JSON_version_of_object(NewtonsoftJsonObjectSerialiser sut)
    {
      var obj = new TestObject {
        StringProperty = "Hello",
        NumericProperty = 22
      };

      var result = sut.Serialize(obj);

      Assert.That(result, Is.EqualTo(@"{""StringProperty"":""Hello"",""NumericProperty"":22}"));
    }
  }

  internal class TestObject
  {
    public string StringProperty { get; set; }
    public int NumericProperty { get; set; }
  }
}
