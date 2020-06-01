using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConectionApp.DBContextMySql
{
    abstract class ClassFather
    {
        public abstract DataTable Read();
        public abstract bool Delete();
        public abstract bool Update();
        public abstract bool Create();

    }
}
