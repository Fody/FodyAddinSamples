using System;
using System.IO;
using System.Reflection;

namespace AutoBindingRedirect
{
    public static class ModuleInitializer
    {
        public static void Initialize()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var currentDirectory = CurrentDirectory();
            var assemblyName = new AssemblyName(args.Name);
            var assemblyPath = Path.Combine(currentDirectory, assemblyName.Name + ".dll");
            return Assembly.Load(File.ReadAllBytes(assemblyPath));
        }

        public static string CurrentDirectory()
        {
            var assembly = typeof(ModuleInitializer).Assembly;
            var uri = new UriBuilder(assembly.CodeBase);
            var path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }
    }
}