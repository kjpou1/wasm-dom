using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using static WebAssembly.Runtime;

namespace Mono.WebAssembly
{

	public sealed class Runtime {
		
        public static string ExecuteJavaScript(string str)
        {
#if DEBUG
            Console.WriteLine($"CS::Mono.WebAssembly.Runtime::ExecuteJavaScript {str}");
#endif

            int exception = 0;
            var wrappedFunction = "return function () { return " + str + "};";
            var res = InvokeJSHook(wrappedFunction, out exception);
            if (exception != 0)
                throw new JSException(res);
            return res;
        }

		public static object DeserializeJSON (string str)
		{
			return MiniJSON.Json.Deserialize(str);
		}

		public static string SerializeJSON (object obj)
		{
			return MiniJSON.Json.Serialize(obj);
		}

		public class JSException : Exception {
			public JSException (string msg) : base (msg) {}
		}
		
	}


}

namespace WebAssembly
{

    internal static class Runtime
    {
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern string InvokeJS(string str, out int exceptional_result);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern string InvokeJSHook(string str, out int exceptional_result);

    }
}