using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПаттернСвойств
{
    internal class Company
    {
        public string Title { get; }
        public Company(string title) => Title = title;
    }
}
