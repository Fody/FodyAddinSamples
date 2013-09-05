using System;
using System.Reflection;
using NUnit.Framework;
using System.Linq;

namespace RemoveReferenceSample
{
    [TestFixture]
    public class Sample
    {
        [Test]
        public void Run()
        {
            /*
            ------ Test started: Assembly: RemoveReferenceSample.dll ------

            Test 'M:RemoveReferenceSample.Sample.Run' failed: Could not load type 'RemoveReference.RemoveReferenceAttribute' from assembly 'nunit.framework, Version=2.6.2.12296, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77'.
                System.TypeLoadException: Could not load type 'RemoveReference.RemoveReferenceAttribute' from assembly 'nunit.framework, Version=2.6.2.12296, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77'.
                at System.ModuleHandle.ResolveType(RuntimeModule module, Int32 typeToken, IntPtr* typeInstArgs, Int32 typeInstCount, IntPtr* methodInstArgs, Int32 methodInstCount, ObjectHandleOnStack type)
                at System.ModuleHandle.ResolveTypeHandleInternal(RuntimeModule module, Int32 typeToken, RuntimeTypeHandle[] typeInstantiationContext, RuntimeTypeHandle[] methodInstantiationContext)
                at System.Reflection.RuntimeModule.ResolveType(Int32 metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
                at System.Reflection.CustomAttribute.FilterCustomAttributeRecord(CustomAttributeRecord caRecord, MetadataImport scope, Assembly& lastAptcaOkAssembly, RuntimeModule decoratedModule, MetadataToken decoratedToken, RuntimeType attributeFilterType, Boolean mustBeInheritable, Object[] attributes, IList derivedAttributes, RuntimeType& attributeType, IRuntimeMethodInfo& ctor, Boolean& ctorHasParameters, Boolean& isVarArg)
                at System.Reflection.CustomAttribute.GetCustomAttributes(RuntimeModule decoratedModule, Int32 decoratedMetadataToken, Int32 pcaCount, RuntimeType attributeFilterType, Boolean mustBeInheritable, IList derivedAttributes, Boolean isDecoratedTargetSecurityTransparent)
                at System.Reflection.CustomAttribute.GetCustomAttributes(RuntimeAssembly assembly, RuntimeType caType)
                at System.Reflection.RuntimeAssembly.GetCustomAttributes(Type attributeType, Boolean inherit)
                at NUnit.Core.ActionsHelper.GetActionsFromAttributeProvider(ICustomAttributeProvider attributeProvider)
                at NUnit.Core.TestAssembly..ctor(Assembly assembly, String path)
                at NUnit.Core.Builders.TestAssemblyBuilder.BuildTestAssembly(Assembly assembly, String assemblyName, IList fixtures, Boolean autoSuites)
                at NUnit.Core.Builders.TestAssemblyBuilder.Build(String assemblyName, Boolean autoSuites)
                at NUnit.Core.Builders.TestAssemblyBuilder.Build(String assemblyName, String testName, Boolean autoSuites)
                at NUnit.Core.TestSuiteBuilder.BuildSingleAssembly(TestPackage package)
                at NUnit.Core.TestSuiteBuilder.Build(TestPackage package)
                at NUnit.AddInRunner.NUnitTestRunner.run(ITestListener testListener, Assembly assembly, ITestFilter filter)
                at NUnit.AddInRunner.NUnitTestRunner.runMethod(ITestListener testListener, Assembly assembly, MethodInfo method)
                at NUnit.AddInRunner.NUnitTestRunner.MemberRun.Run(NUnitTestRunner testRunner, ITestListener testListener, Assembly assembly)
                at NUnit.AddInRunner.NUnitTestRunner.run(ITestListener testListener, Assembly assembly, IRun run)
                at NUnit.AddInRunner.NUnitTestRunner.RunMember(ITestListener testListener, Assembly assembly, MemberInfo member)
                at TestDriven.TestRunner.AdaptorTestRunner.Run(ITestListener testListener, ITraceListener traceListener, String assemblyPath, String testPath)
                at TestDriven.TestRunner.ThreadTestRunner.Runner.Run()

            0 passed, 1 failed, 0 skipped, took 0.29 seconds (NUnit 2.6).
             */
            Assembly assembly = Assembly.GetExecutingAssembly();

            Assert.IsTrue(!assembly.GetReferencedAssemblies().Any(x => x.Name == "RemoveReferences"));
        }
    }
}
