using JetBrains.Annotations;
using lr2.entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.entity;

[TestClass]
[TestSubject(typeof(Detail))]
public class DetailTest
{

    [TestMethod]
    public void GetDetailType_test()
    {
        Detail engine = new Detail(DetailType.Engine);
        Detail chassis = new Detail(DetailType.Сhassis);
        Detail frame = new Detail(DetailType.Frame);

        Assert.AreEqual(DetailType.Frame, frame.GetDetailType());
        Assert.AreEqual(DetailType.Engine, engine.GetDetailType());
        Assert.AreEqual(DetailType.Сhassis, chassis.GetDetailType());
    }
}