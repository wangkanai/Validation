using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Wangkanai.Validation.Tests
{
    public class RequireBooleanTests
    {
        private readonly ITestOutputHelper _output;

        public RequireBooleanTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ExpectedTrue_ActualTrue()
        {
            var vm = new RegisterViewModel
            {
                WannaTrue = true
            };

            var property    = RegisterViewModel.GetProperty(nameof(RegisterViewModel.WannaTrue));
            var validations = vm.Validate(vm.WannaTrue, property);
            validations.Print(_output);
            
            Assert.Empty(validations);
        }

        [Fact]
        public void ExpectedTrue_ActualFalse()
        {
            var vm = new RegisterViewModel
            {
                WannaTrue = false
            };
            var property    = RegisterViewModel.GetProperty(nameof(RegisterViewModel.WannaTrue));
            var validations = vm.Validate(vm.WannaTrue, property);
            validations.Print(_output);
            
            Assert.Collection(validations, v => v.ErrorMessage = "Checked is required");
        }

        [Fact]
        public void ExpectedFalse_ActualTrue()
        {
            var vm = new RegisterViewModel
            {
                WannaFalse = true
            };

            var property    = RegisterViewModel.GetProperty(nameof(RegisterViewModel.WannaFalse));
            var validations = vm.Validate(vm.WannaFalse, property);
            validations.Print(_output);
            
            Assert.Collection(validations, v => v.ErrorMessage = "Unchecked is required");
        }

        [Fact]
        public void ExpectedFalse_ActualFalse()
        {
            var vm = new RegisterViewModel
            {
                WannaFalse = false
            };
            var property    = RegisterViewModel.GetProperty(nameof(RegisterViewModel.WannaFalse));
            var validations = vm.Validate(vm.WannaFalse, property);
            validations.Print(_output);
            
            Assert.Empty(validations);
        }
    }
}