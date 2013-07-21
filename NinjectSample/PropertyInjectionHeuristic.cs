using System.Reflection;
using Ninject;
using Ninject.Components;
using Ninject.Selection.Heuristics;

namespace NinjectFodySample
{
    /// <summary>
    /// This class is NOT required by Ninject.Fody, this is only used to avoid using [Inject] attributes
    /// </summary>
    public class PropertyInjectionHeuristic : NinjectComponent, IInjectionHeuristic
    {
        private readonly IKernel kernel;

        public PropertyInjectionHeuristic(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public bool ShouldInject(MemberInfo member)
        {
            var propertyInfo = member.ReflectedType.GetProperty(member.Name);

            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                object service = kernel.TryGet(propertyInfo.PropertyType);

                return service != null;
            }

            return false;
        }
    }
}
