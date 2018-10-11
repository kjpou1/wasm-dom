using System;
using System.Reflection;

using WebAssembly;

namespace WebAssembly.Browser.DOM
{
    public static class Extensions
    {
        public static T As<T>(this Element htmlElement) where T : Element
        {
            var type = typeof(T);
            var jsobjectnew = typeof(T).GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                            null, new Type[] { typeof(JSObject) }, null);

            return (T)jsobjectnew.Invoke(new object[] { htmlElement.ManagedJSObject });
        }

        public static T As<T>(this EventTarget eventTarget) where T : EventTarget
        {
            var type = typeof(T);
            return (T)CreateDOMObjectFrom(type, eventTarget, true);

        }

        public static T ConvertTo<T>(this EventTarget eventTarget) where T : EventTarget
        {
            var type = typeof(T);
            return (T)CreateDOMObjectFrom(type, eventTarget, true);

        }

        static internal object CreateDOMObjectFrom(Type targetType, DOMObject parentObject, bool inheritFrom = true)
        {

            var jsObjectConstructor = targetType.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                null, new Type[] { typeof(JSObject) }, null);

            var newJSObject = jsObjectConstructor.Invoke(new object[] { parentObject.ManagedJSObject });
            //if (inheritFrom)
                //((DOMObject)newJSObject).ManagedJSObject = parentObject;

            return newJSObject;

        }

    }
}
