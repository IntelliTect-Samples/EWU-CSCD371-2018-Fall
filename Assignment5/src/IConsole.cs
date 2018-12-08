using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public interface IConsole
    {

        int ReadInt();
        String ReadLine();
        void Write(String str);
        void WriteLine(String str);
    }
}