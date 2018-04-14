using System;
namespace Mono.WebAssembly.DOM
{
    public static class Extensions
    {
        public static T As<T>(this Element htmlElement) where T : Element
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type, new object[] { htmlElement.Handle });

            return (T)instance;
        }
    }
}
