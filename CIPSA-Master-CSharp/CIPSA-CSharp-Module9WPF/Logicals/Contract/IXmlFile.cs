using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA_CSharp_Module9WPF.Logicals.Contract
{
    public interface IXmlFile<T>
    {
        T Add(T generic);
        T Get(Guid genericId);
        List<T> GetAll();
        T Update(T generic);
        void Remove(Guid genericId);
    }
}
