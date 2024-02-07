using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RashakaGroupsAdmin.Repository.Interfaces
{
 public interface IRashakaUniteOfWork:IDisposable
    {
        IRashaka<T> iRashaka<T>() where T : class;
        void Save();

    }
}
