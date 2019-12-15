using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface ILibraryList<T>
    {
        void Add(T obj);

        void RemoveAt(int index);

        void Remove(T book);

        void ReplaceAt(int index, T book);

        List<T> FindByKeyWord(string key);

        void GetInfo();

        void SaveInfo();
    }
}
