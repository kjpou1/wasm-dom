using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mono.WebAssembly
{
    public class JSObject
    {
        int handle;
        public int Handle { get => handle; private set {handle = value; } }

        internal JSObject() { }

        internal JSObject(int reference)
        {
            Handle = reference;
        }

        protected JSObject(string globalName) : this(GetGlobal(globalName))
        {

        }

        protected static int GetGlobal(string str)
        {
            var res = Runtime.ExecuteJavaScript("MonoDOMRuntime.mono_wasm_val_global(\"" + str + "\");");
            return (res == null || res == "undefined") ? -1 : Int32.Parse(res);
        }

        protected T GetProperty<T>(string expr)
        {
            var getPropOf = "MonoDOMRuntime.mono_wasm_get_property(" + Handle + ",\"" + expr + "\")";
            object propertyValue = null;
            var type = typeof(T);
            if (type.IsSubclassOf(typeof(JSObject)) || typeof(JSObject) == type)
            {
                propertyValue = Runtime.ExecuteJavaScript("MonoDOMRuntime.mono_wasm_register_obj(" 
                    + getPropOf
                    + ");");
            }
            else 
                propertyValue = Runtime.ExecuteJavaScript(getPropOf);

            return UnWrapObject<T>(propertyValue);
            
        }

        protected void SetProperty<T>(string expr, T value, bool createIfNotExists = true, bool hasOwnProperty = false)
        {
            var setPropOf = "MonoDOMRuntime.mono_wasm_set_property(" + Handle + ",\"" + expr + "\",";
            var setPropOptions = ", " + (createIfNotExists ? "true" : "false") + ", " + (hasOwnProperty ? "true" : "false") + ")";
            var objValue = WrapObject(value);
            Runtime.ExecuteJavaScript(setPropOf + objValue + setPropOptions);

        }

        private string WrapObject(object obj)
        {
            if (obj == null)
                return "null";

            var type = obj.GetType();
            if (type.IsPrimitive || typeof(Decimal) == type)
            {
                IConvertible c = obj as IConvertible;
                if (typeof(bool) == type)
                {
                    return c == null ? obj.ToString().ToLowerInvariant() : c.ToString().ToLowerInvariant();
                }
                else
                {
                    return c == null ? obj.ToString() : c.ToString();
                }
            }
            else if (type == typeof(string))
            {
                if (obj == null)
                {
                    return "null";
                }
                else
                {
                    return $"\"{obj.ToString()}\"";
                }

            }
            else if (type.IsSubclassOf(typeof(JSObject)) || type == typeof(JSObject))
            {
                if (obj == null)
                {
                    return "null";
                }
                else
                {
                    return "MonoDOMRuntime.mono_wasm_require_handle(" + ((JSObject)(object)obj).Handle + ")";
                }
            }
            return "";
        }

        private string WrapObject<T>(object obj)
        {
            if (obj == null)
                return "null";

            var type = typeof(T);
            if (type.IsPrimitive || typeof(Decimal) == type)
            {
                IConvertible c = obj as IConvertible;
                if (typeof(bool) == type)
                {
                    return c == null ? obj.ToString().ToLowerInvariant() : c.ToString().ToLowerInvariant();
                }
                else
                {
                    return c == null ? obj.ToString() : c.ToString();
                }
            }
            else if (type == typeof(string))
            {
                if (obj == null)
                {
                    return "null";
                }
                else
                {
                    return $"\"{obj.ToString()}\"";
                }

            }
            else if (type.IsSubclassOf(typeof(JSObject)) || type == typeof(JSObject))
            {
                if (obj == null)
                {
                    return "null";
                }
                else
                {
                    return "MonoDOMRuntime.mono_wasm_require_handle(" + ((JSObject)(object)obj).Handle + ")";
                }
            }
            return "";
        }

        T UnWrapObject<T>(object obj)
        {
            if (obj == null)
                return (T)(object)null;

            var type = typeof(T);
            if (typeof(T) == typeof(double))
            {
                var dblObject = obj;
                if (dblObject == null)
                    return (T)(object)0.0;
                return (T)(object)double.Parse(dblObject.ToString());
            }
            if (typeof(T) == typeof(double?))
            {
                var dblObject = obj;
                if (dblObject == null)
                    return (T)(object)null;
                return (T)(object)double.Parse(dblObject.ToString());
            }
            else if (typeof(T) == typeof(bool))
            {
                var boolObject = obj;
                if (boolObject == null)
                    return (T)(object)false;
                return (T)(object)bool.Parse(boolObject.ToString());
            }
            else if (typeof(T) == typeof(bool?))
            {
                var boolObject = obj;
                if (boolObject == null)
                    return (T)(object)null;
                return (T)(object)bool.Parse(boolObject.ToString());
            }
            else if (typeof(T) == typeof(string))
            {
                return (T)(object)(obj);
            }
            else if (typeof(T).IsSubclassOf(typeof(JSObject)) || type == typeof(JSObject))
            {
                var jsobject = obj.ToString();

                var jsobjectnew = typeof(T).GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                                null, new Type[] { typeof(Int32) }, null);

                return (T)jsobjectnew.Invoke(new object[] { (jsobject == null) ? -1 : Int32.Parse(jsobject) });

            }
            else
            {
                throw new NotSupportedException($"Type {type} not supported yet.");
            }

            
        }

        protected T InvokeMethod<T>(string methodName, params object[] args)
        {
            var wrappedParms = new List<string>();

            var invokeWith = "MonoDOMRuntime.mono_wasm_invoke(" + Handle + ",\"" + methodName + "\", [ ";
            var invokeWithEnd = "])";

            for (int x =0; x < args.Length; x++)
            {
                if (x > 0)
                    invokeWith += ", ";
                invokeWith += WrapObject(args[x]);                
            }

            invokeWith += invokeWithEnd;
            var type = typeof(T);

            if (type.IsSubclassOf(typeof(JSObject)) || type == typeof(JSObject))
            {
                invokeWith = "MonoDOMRuntime.mono_wasm_register_obj(" 
                    + invokeWith
                    + ");";
                
            }
            
            var res = Runtime.ExecuteJavaScript(invokeWith);


            return UnWrapObject<T>(res);
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Handle == (obj as JSObject).Handle;
        }

        public override int GetHashCode()
        {
            return Handle;
        }

        public override string ToString()
        {
            return $"JS Object {Handle}";
        }

    }
}