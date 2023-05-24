using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DI
{
    public interface IData<T>
    {
        IEnumerable<T> ReadAll();
        void Add(T item);
        void Remove(T item);
    }
}
