using System;
using System.Collections.Generic;

namespace Callables
{
    // Copyright (c) 2016 All Rights Reserved
    // <author> Elliot Bewey </author>
    // <date> 27/12/2016 </date>
    // <summary> Callables allow for advanced method control </summary>
    public class Callables
    {

        //Storage

        private static Dictionary<string, Delegate> callableDictionary = new Dictionary<string, Delegate>();
        private static Dictionary<string, string[]> callableGroups = new Dictionary<string, string[]>();

        //Gets

        public static Dictionary<string, Delegate> GetCallables()
        {
            return callableDictionary;
        }

        public static Dictionary<string, string[]> GetCallableGroups()
        {
            return callableGroups;
        }

        public static string[] GetCallableGroupMembers(string name)
        {
            return callableGroups[name];
        }

        //Callable Main Methods

        public static void AddCallable(string name, Delegate dele)
        {
            callableDictionary.Add(name, dele);
        }

        public static void AddCallable(Delegate dele)
        {
            callableDictionary.Add(dele.Method.Name, dele);
        }

        public static void RemoveCallable(string name)
        {
            callableDictionary.Remove(name);
        }

        public static void ModifyCallable(string name, Delegate dele)
        {
            callableDictionary[name] = dele;
        }

        //Callable Group Main Methods

        public static void AddCallableGroup(string name, params string[] methods)
        {
            callableGroups.Add(name, methods);
        }

        public static void AddCallableGroup(string name, params Delegate[] methods)
        {
            string[] methodList = new string[methods.Length];
            var index = 0;
            foreach (Delegate method in methods)
            {
                string m_name = method.Method.Name;
                AddCallable(m_name, method);
                methodList[index] = m_name;
                index += 1;
            }
            callableGroups.Add(name, methodList);
        }


        public static void RemoveCallableGroup(string name)
        {
            callableGroups.Remove(name);
        }

        //Calling

        private static TResult Call<TResult>(Delegate f, params object[] args)
        {
            var result = f.DynamicInvoke(args);
            return (TResult)Convert.ChangeType(result, typeof(TResult));
        }

        private static void CallNoReturn(Delegate f, params object[] args)
        {
            f.DynamicInvoke(args);
        }

        public static TResult InvokeCallable<TResult>(string name, params object[] args)
        {
            return Call<TResult>(callableDictionary[name], args);
        }

        public static void InvokeCallable(string name, params object[] args)
        {
            CallNoReturn(callableDictionary[name], args);
        }

        public static void InvokeCallableGroup(string name)
        {
            foreach (string method in callableGroups[name])
            {
                CallNoReturn(callableDictionary[method]);
            }
        }
    }
}