using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class IEnumerableTst : IEnumerable<int>, IEnumerator<int>
    {
        int indx = -1;
        int[] lst = new int[] { 1, 2, 3 };
        int IEnumerator<int>.Current => lst[indx];

        object IEnumerator.Current => ((IEnumerator<int>)this).Current;      //OK:  Tst();

        object Tst()
        {
            return null;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return this;
        }

        void IDisposable.Dispose()
        {
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool MoveNext()  //implicit implementation
        {
            indx++;
            return (indx < lst.Length);
        }

        void IEnumerator.Reset()  //explicit (public is default)
        {
            indx = -1;
        }
    }
}
