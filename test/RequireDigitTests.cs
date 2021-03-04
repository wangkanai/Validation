using System.Reflection;
using Wangkanai.Validation.Extensions;
using Wangkanai.Validation.Models;
using Xunit;
using Xunit.Abstractions;

namespace Wangkanai.Validation.Tests
{
    public class RequireDigitTests
    {
        private readonly ITestOutputHelper _output;
        private readonly PropertyInfo      _password = BaseModel.GetProperty<DigitModel>(nameof(DigitModel.Password));

        public RequireDigitTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Mix()
        {
            var vm = new DigitModel {Password = "pass1234"};

            var validations = vm.Validate(vm.Password, _password);
            validations.Print(_output);
            
            Assert.Empty(validations);
        }
    }
}