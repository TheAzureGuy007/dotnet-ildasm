﻿using System.Linq;
using DotNet.Ildasm.Infrastructure;
using Xunit;

namespace DotNet.Ildasm.Tests.Infrastructure
{
    public class TypeFormatExtensionsShould
    {
        [Fact]
        public void Return_IL_Type_For_Void()
        {
            var type = DataHelper.SampleAssembly.Value.Modules.First().Types.First(x => x.Name == "Program");
            var methoDefinition = type.Methods.First(x => x.Name == "Main");

            var actual = methoDefinition.ReturnType.ToIL();

            Assert.Equal("void", actual);
        }

        [Fact]
        public void Return_IL_Type_For_String()
        {
            var type = DataHelper.SampleAssembly.Value.Modules.First().Types.First(x => x.Name == "PublicClass");
            var propertyDefinition = type.Properties.First(x => x.Name == "Property1");

            var actual = propertyDefinition.GetMethod.ReturnType.ToIL();

            Assert.Equal("string", actual);
        }

        [Fact]
        public void Return_IL_Type_For_StringArray()
        {
            var type = DataHelper.SampleAssembly.Value.Modules.First().Types.First(x => x.Name == "PublicClass");
            var methodDefinition = type.Methods.First(x => x.Name == "PublicVoidMethodParams");

            var actual = methodDefinition.Parameters.First().ParameterType.ToIL();

            Assert.Equal("string[]", actual);
        }

        [Fact]
        public void Return_IL_Type_For_Int32()
        {
            var type = DataHelper.SampleAssembly.Value.Modules.First().Types.First(x => x.Name == "PublicClass");
            var methodDefinition = type.Methods.First(x => x.Name == "UsingIF");

            var actual = methodDefinition.Parameters.First().ParameterType.ToIL();

            Assert.Equal("int32", actual);
        }
    }
}
