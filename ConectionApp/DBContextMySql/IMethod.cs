using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectionApp.DBContextMySql
{
  
    public interface IMethod
    { // Todo: Poner codigo aqui
        bool GetDataId();
        bool GetDataAll();
        bool SaveData();
        
    }
}
