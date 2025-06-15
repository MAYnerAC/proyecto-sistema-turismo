using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//
using DotNetEnv;

namespace ProyectoSistemaTurismo.IntegrationTests
{
    [TestClass]
    public class TestSetup
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Env.Load();
        }

        //
    }
}
