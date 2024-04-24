using JetBrains.Annotations;
using lr2.entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lr2.Tests.entity;

[TestClass]
[TestSubject(typeof(Material))]
public class MaterialTest
{

    [TestMethod]
    public void IsQualitative_test()
    {
        Material badMaterial = new Material(MaterialQuality.Defective);
        Material goodMaterial = new Material(MaterialQuality.Qualitative);
        
        Assert.AreEqual(false, badMaterial.IsQualitative());
        Assert.AreEqual(true, goodMaterial.IsQualitative());
    }
}