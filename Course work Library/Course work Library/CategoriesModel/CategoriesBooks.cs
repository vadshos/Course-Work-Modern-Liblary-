using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_work_Library.CategoriesModel
{
    class CategoriesBooks
    {
        public string NameCategory { get; set; }
        public string PathToBooks { get; set; }
        public override string ToString()
        {
            return NameCategory;
        }
    }
}
