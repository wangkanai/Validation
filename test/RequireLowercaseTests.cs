using System.Reflection;
using Wangkanai.Validation.Extensions;
using Wangkanai.Validation.Models;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Wangkanai.Validation.Tests
{
    public class RequireLowercaseTests
    {
        private readonly ITestOutputHelper _output;
        private readonly PropertyInfo      _password = LowercaseModel.GetProperty(nameof(LowercaseModel.Password));

        public RequireLowercaseTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Uppercase()
        {
            var vm = new LowercaseModel {Password = "ABC"};

            var validations = vm.Validate(vm.Password, _password);
            validations.Print(_output);

            Assert.Collection(validations, v =>
                                  v.ErrorMessage = "Lowercase is required");
        }

        [Fact]
        public void Lowercase()
        {
            var vm = new LowercaseModel {Password = "abc"};

            var validations = vm.Validate(vm.Password, _password);
            validations.Print(_output);

            Assert.Empty(validations);
        }

        [Fact]
        public void Mix()
        {
            var vm = new LowercaseModel {Password = "Abc"};

            var validations = vm.Validate(vm.Password, _password);
            validations.Print(_output);

            Assert.Empty(validations);
        }
    }
}