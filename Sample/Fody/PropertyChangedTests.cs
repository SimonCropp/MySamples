
// https://github.com/Fody/PropertyChanged

public class PropertyChangedTests :
    XunitContextBase
{
    [Fact]
    public void PropertyChanged()
    {
        var person = new Person();
        person.PropertyChanged += (_, e) => Trace.WriteLine(e.PropertyName);
        person.GivenNames = "John";
        person.FamilyName = "Smith";
    }

    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string GivenNames { get; set; }
        public string FamilyName { get; set; }
        public string FullName => $"{GivenNames} {FamilyName}";
    }
    

    public PropertyChangedTests(ITestOutputHelper output) :
        base(output)
    {
    }
}