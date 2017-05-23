using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churchplus_Records
{
    public  interface IFileHelper
    {
        String GetLocalFilePath(string filename);
    }
}
