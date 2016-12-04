using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKmzdy.Schema
{
    public abstract class NameInfo
    {
        public abstract string Name { get; }
        public abstract string Alias { get; }
        public abstract string Function { get; }
    }

    public sealed class SimpleName : NameInfo
    {
        private string m_name;

        private string m_function;
        private SimpleName(string name)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }

            this.m_name = name;

            this.m_function = DBConstants.EMPTY_STRING;
        }

        private SimpleName(string name, string function)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }

            this.m_name = name;

            if (function == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }

            this.m_function = function;
        }

        public static NameInfo Create(string name)
        {
            return new SimpleName(name);
        }

        public static NameInfo Create(string name, string function)
        {
            return new SimpleName(name, function);
        }

        public override string Name
        {
            get { return m_name; }
        }
        public override string Alias
        {
            get { return m_name; }
        }
        public override string Function
        {
            get { return m_function; }
        }
    }

    public sealed class AliasName : NameInfo
    {
        private string m_name;

        private string m_alias;

        private string m_function;
        private AliasName(string name, string alias)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }

            this.m_name = name;

            if (alias == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }

            this.m_alias = alias;

            this.m_function = DBConstants.EMPTY_STRING;
        }

        private AliasName(string name, string alias, string function)
        {
            if (name == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }
            this.m_name = name;

            if (alias == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }
            this.m_alias = alias;

            if (function == null)
            {
                throw new System.ArgumentNullException("value", "Some value was null, use None instead");
            }

            this.m_function = function;
        }

        public static AliasName Create(string name, string alias)
        {
            return new AliasName(name, alias);
        }

        public static AliasName Create(string name, string alias, string function)
        {
            return new AliasName(name, alias, function);
        }

        public override string Name
        {
            get { return m_name; }
        }
        public override string Alias
        {
            get { return m_alias; }
        }
        public override string Function
        {
            get { return m_function; }
        }
   }
}
