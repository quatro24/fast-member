using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public DataColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
