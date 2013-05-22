using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using ScriptCs.Contracts;

namespace ScriptCs.MemberPrint
{
    public class MemberPrint : IScriptPackContext
    {
        public void Methods(Type t, BindingFlags flags, string regex, bool verbose = false)
        {
            var methods = FilterAndSortMemberInfo(t.GetMethods(flags), regex);
            foreach (var m in methods)
            {
                PrintLine(FormatMethod(m, verbose), ConsoleColor.Magenta);
            }
        }

        public void Constructors(Type t, BindingFlags flags, string regex, bool verbose = false)
        {

            var constructors = FilterAndSortMemberInfo(t.GetConstructors(flags), regex);
            foreach (var c in constructors)
            {
                PrintLine(FormatConstructor(c, verbose), ConsoleColor.White);
            }
            
        }

        public void Properties(Type t, BindingFlags flags, string regex, bool verbose = false)
        {
            var props = FilterAndSortMemberInfo(t.GetProperties(flags), regex);
            foreach (var p in props)
            {
                PrintLine(FormatProperty(p, verbose), ConsoleColor.Green);
            }
        }

        private void Events(Type t, BindingFlags flags, string regex, bool verbose = false)
        {
            var props = FilterAndSortMemberInfo(t.GetEvents(flags), regex);
            foreach (var p in props)
            {
                PrintLine(FormatEvent(p, verbose), ConsoleColor.DarkYellow);
            }
        }

        public void Members(Type t, BindingFlags flags, string regex, bool verbose = false)
        {
            Events(t, flags, regex, verbose);
            Constructors(t, flags, regex, verbose);
            Properties(t, flags, regex, verbose);
            Methods(t, flags, regex, verbose);
        }

        public void Methods(object o, bool verbose = false)
        {
            Methods(o.GetType(), DefaultBindingFlags, null, verbose);
        }
        public void Methods(object o, string regex, bool verbose = false)
        {
            Methods(o.GetType(), DefaultBindingFlags, regex, verbose);
        }
        public void Methods(Type type, bool verbose = false)
        {
            Methods(type, DefaultBindingFlags, null, verbose);
        }
        public void Methods(Type type, string regex, bool verbose = false)
        {
            Methods(type, DefaultBindingFlags, regex, verbose);
        }
        public void Methods(object o, BindingFlags flags, bool verbose = false)
        {
            Methods(o.GetType(), flags, null, verbose);
        }
        public void Methods(Type t, BindingFlags flags, bool verbose = false)
        {
            Methods(t, flags, null, verbose);
        }
        public void Methods(object o, BindingFlags flags, string regex, bool verbose = false)
        {
            Methods(o.GetType(), flags, regex, verbose);
        }



        public void Constructors(object o, bool verbose = false)
        {
            Constructors(o.GetType(), DefaultBindingFlags, null, verbose);
        }
        public void Constructors(object o, string regex, bool verbose = false)
        {
            Constructors(o.GetType(), DefaultBindingFlags, regex, verbose);
        }
        public void Constructors(Type type, bool verbose = false)
        {
            Constructors(type, DefaultBindingFlags, null, verbose);
        }
        public void Constructors(Type type, string regex, bool verbose = false)
        {
            Constructors(type, DefaultBindingFlags, regex, verbose);
        }
        public void Constructors(object o, BindingFlags flags, bool verbose = false)
        {
            Constructors(o.GetType(), flags, null, verbose);
        }
        public void Constructors(Type t, BindingFlags flags, bool verbose = false)
        {
            Constructors(t, flags, null, verbose);
        }
        public void Constructors(object o, BindingFlags flags, string regex, bool verbose = false)
        {
            Constructors(o.GetType(), flags, regex, verbose);
        }

        

        public void Properties(object o, bool verbose = false)
        {
            Properties(o.GetType(), DefaultBindingFlags, null, verbose);
        }
        public void Properties(object o, string regex, bool verbose = false)
        {
            Properties(o.GetType(), DefaultBindingFlags, regex, verbose);
        }
        public void Properties(Type t, bool verbose = false)
        {
            Properties(t, DefaultBindingFlags, null, verbose);
        }
        public void Properties(Type t, string regex, bool verbose = false)
        {
            Properties(t, DefaultBindingFlags, regex, verbose);
        }
        public void Properties(object o, BindingFlags flags, bool verbose = false)
        {
            Properties(o.GetType(), flags, null, verbose);
        }
        public void Properties(Type t, BindingFlags flags, bool verbose = false)
        {
            Properties(t, flags, null, verbose);
        }
        public void Properties(object o, BindingFlags flags, string regex, bool verbose = false)
        {
            Properties(o.GetType(), DefaultBindingFlags, regex, verbose);
        }


        public void Events(object o, bool verbose = false)
        {
            Events(o.GetType(), DefaultBindingFlags, null, verbose);
        }
        public void Events(object o, string regex, bool verbose = false)
        {
            Events(o.GetType(), DefaultBindingFlags, regex, verbose);
        }
        public void Events(Type t, bool verbose = false)
        {
            Events(t, DefaultBindingFlags, null, verbose);
        }
        public void Events(Type t, string regex, bool verbose = false)
        {
            Events(t, DefaultBindingFlags, regex, verbose);
        }
        public void Events(object o, BindingFlags flags, bool verbose = false)
        {
            Events(o.GetType(), flags, null, verbose);
        }
        public void Events(Type t, BindingFlags flags, bool verbose = false)
        {
            Events(t, flags, null, verbose);
        }
        public void Events(object o, BindingFlags flags, string regex, bool verbose = false)
        {
            Events(o.GetType(), DefaultBindingFlags, regex, verbose);
        }


        public void Members(object o, BindingFlags flags, bool verbose = false)
        {
            Members(o.GetType(), flags, null, verbose);
        }
        public void Members(Type t, BindingFlags flags, bool verbose = false)
        {
            Members(t, flags, null, verbose);
        }
        public void Members(object o, bool verbose = false)
        {
            Members(o.GetType(), DefaultBindingFlags, null, verbose);
        }
        public void Members(Type t, bool verbose = false)
        {
            Members(t, DefaultBindingFlags, null, verbose);
        }
        public void Members(object o, string regex, bool verbose = false)
        {
            Members(o.GetType(), DefaultBindingFlags, regex, verbose);            
        }
        public void Members(Type t, string regex, bool verbose = false)
        {
            Members(t, DefaultBindingFlags, regex, verbose);
        }



        private static string FormatProperty(PropertyInfo p, bool verbose)
        {
            var sb = new StringBuilder();
            sb.Append(verbose ? p.PropertyType.FullName : p.PropertyType.Name);
            sb.Append(" ");
            sb.Append(p.Name);
            sb.Append(" { ");
            if (p.GetGetMethod(false) != null) sb.Append("get; ");
            if (p.GetSetMethod(false) != null) sb.Append("set; ");
            sb.Append("}");

            return sb.ToString();
        }

        private static string FormatMethod(MethodInfo m, bool verbose = false)
        {
            var sb = new StringBuilder();
            sb.Append(m.IsPublic ? "+ " : "- ");
            sb.Append(m.IsStatic ? "# " : "  ");
            sb.Append(m.Name);
            sb.Append("(");
            sb.Append(string.Join(", ", m.GetParameters().Select(param => FormatParameter(param, verbose))));
            sb.Append(") : ");
            sb.Append(verbose ? m.ReturnType.FullName : m.ReturnType.Name);

            return sb.ToString();
        }

        private string FormatEvent(EventInfo e, bool verbose)
        {
            var sb = new StringBuilder();
            sb.Append(verbose ? e.EventHandlerType.FullName : e.EventHandlerType.Name);
            sb.Append(" ");
            sb.Append(e.Name);

            return sb.ToString();
        }

        private string FormatConstructor(ConstructorInfo c, bool verbose = false)
        {
            var sb = new StringBuilder();
            sb.Append(c.IsPublic ? "+ " : "- ");
            sb.Append(c.IsStatic ? "# " : "  ");
            sb.Append(c.Name);
            sb.Append("(");
            sb.Append(string.Join(", ", c.GetParameters().Select(param => FormatParameter(param, verbose))));
            sb.Append(")");

            return sb.ToString();
        }

        private static string FormatParameter(ParameterInfo p, bool verbose = false)
        {
            return string.Format("{0} {1}", verbose ? p.ParameterType.FullName : p.ParameterType.Name, p.Name);
        }

        private static BindingFlags DefaultBindingFlags
        {
            get { return BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static; }
        }

        private static IList<T> FilterAndSortMemberInfo<T>(IEnumerable<T> members, string regex) where T : MemberInfo
        {
            var result = members;
            if (regex != null)
            {
                result = result.Where(q => Regex.IsMatch(q.Name, regex));
            }
            result = result.OrderBy(q => q.Name);

            return result.ToList();
        }

        private static void PrintLine(object toPrint, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(toPrint);
            }
            finally
            {
                Console.ForegroundColor = previousColor;
            }
        }
    }
}
