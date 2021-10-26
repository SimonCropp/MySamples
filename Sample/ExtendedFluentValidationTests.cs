
// https://github.com/SimonCropp/ExtendedFluentValidation

[UsesVerify]
public class ExtendedFluentValidationTests :
    XunitContextBase
{
    [Fact]
    public Task Usage()
    {
        var validator = new PersonValidator();

        var target = new Person();
        var result = validator.Validate(target);
        return Verifier.Verify(result);
    }

    class PersonValidator : ExtendedValidator<Person> { }

    class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string FamilyName { get; set; }
        public DateTimeOffset Dob { get; set; }
    }

    public ExtendedFluentValidationTests(ITestOutputHelper output) :
        base(output)
    {
    }
}