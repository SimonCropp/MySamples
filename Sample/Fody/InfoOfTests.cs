
// https://github.com/Fody/InfoOf

public class InfoOfTests :
    XunitContextBase
{
    [Fact]
    public void InfoOf()
    {
        var type = Info.OfType("Sample", "MyClass");

        var method = Info.OfMethod("Sample", "MyClass", "MyMethod");
        var methodTyped = Info.OfMethod<MyClass>("MyMethod");

        var constructor = Info.OfConstructor("Sample", "MyClass");
        var constructorTyped = Info.OfConstructor<MyClass>();

        var getProperty = Info.OfPropertyGet("Sample", "MyClass", "MyProperty");
        var getPropertyTyped = Info.OfPropertyGet<MyClass>("MyProperty");

        var setProperty = Info.OfPropertySet("Sample", "MyClass", "MyProperty");
        var setPropertyTyped = Info.OfPropertySet<MyClass>("MyProperty");

        var field = Info.OfField("Sample", "MyClass", "myField");
        var fieldTyped = Info.OfField<MyClass>("myField");
    }

    public InfoOfTests(ITestOutputHelper output) :
        base(output)
    {
    }
}

public class MyClass
{
    public string MyProperty { get; set; }
    public void MyMethod() { }
    public string myField;
}