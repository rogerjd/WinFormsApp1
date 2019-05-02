using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class MyStrs : IEnumerable<string>
    {

        //        IEnumerator<string> IEnumerable<string>.GetEnumerator() => new StrEnum();
        public IEnumerator<string> GetEnumerator() => new StrEnum();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //public StrEnum GetEnumerator()
        //{
        //    return new StrEnum();
        //}
    }

    class StrEnum : IEnumerator<string>
    {
        int indx = -1;
        string[] lst = new string[] { "1", "2", "3" };

        string IEnumerator<string>.Current => lst[indx];

        object IEnumerator.Current => ((IEnumerator<string>)this).Current;      //OK:  Tst();

        void IDisposable.Dispose()
        {
        }

        public StrEnum()
        {
            //pass list to enum
        }

        public bool MoveNext()  //implicit implementation
        {
            indx++;
            return (indx < lst.Length);
        }

        void IEnumerator.Reset()  //explicit (public is default)
        {
            indx = -1;  //not really used. just create new Enumerator
        }
    }
}
