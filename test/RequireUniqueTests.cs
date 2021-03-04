using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wangkanai.Validation.Extensions;
using Wangkanai.Validation.Models;
using Xunit;
using Xunit.Abstractions;

namespace Wangkanai.Validation.Tests
{
    public class RequireUniqueTests
    {
        private readonly ITestOutputHelper _output;
        private readonly PropertyInfo      _password = RegisterViewModel.GetProperty(nameof(RegisterViewModel.Password));
        private readonly PropertyInfo      _unique1  = RegisterViewModel.GetProperty(nameof(RegisterViewModel.Unique1));
        private readonly PropertyInfo      _unique2  = RegisterViewModel.GetProperty(nameof(RegisterViewModel.Unique2));
        private readonly PropertyInfo      _unique3  = RegisterViewModel.GetProperty(nameof(RegisterViewModel.Unique3));
        private readonly PropertyInfo      _unique4  = RegisterViewModel.GetProperty(nameof(RegisterViewModel.Unique4));

        public RequireUniqueTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void OneFromSix(string value, int unique)
        {
            var vm = new RegisterViewModel {Unique1 = value};

            var validations = vm.Validate(vm.Unique1, _unique1);
            validations.Print(_output);

            Assert.Empty(validations);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void TwoFromSix(string value, int unique)
        {
            var vm = new RegisterViewModel {Unique2 = value};

            var validations = vm.Validate(vm.Unique2, _unique2);
            validations.Print(_output);

            if (unique >= 2)
                Assert.Empty(validations);
            else
                Assert.Collection(validations, v =>
                                      v.ErrorMessage = "2 unique characters are required");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ThreeFromSix(string value, int unique)
        {
            var vm = new RegisterViewModel {Unique3 = value};

            var validations = vm.Validate(vm.Unique3, _unique3);
            validations.Print(_output);

            if (unique >= 3)
                Assert.Empty(validations);
            else
                Assert.Collection(validations, v =>
                                      v.ErrorMessage = "3 unique characters are required");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void FourFromSix(string value, int unique)
        {
            var vm = new RegisterViewModel {Unique4 = value};

            var validations = vm.Validate(vm.Unique4, _unique4);
            validations.Print(_output);

            if (unique >= 4)
                Assert.Empty(validations);
            else
                Assert.Collection(validations, v =>
                                      v.ErrorMessage = "4 unique characters are required");
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {"000000", 1},
                new object[] {"100000", 2},
                new object[] {"110000", 2},
                new object[] {"111000", 2},
                new object[] {"111100", 2},
                new object[] {"111110", 2},
                new object[] {"111111", 1},
                new object[] {"120000", 3},
                new object[] {"123000", 4},
                new object[] {"123400", 5},
                new object[] {"123450", 6},
                new object[] {"123456", 6}
            };
    }
}