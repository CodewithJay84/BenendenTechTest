using System;
using System.Collections.Generic;
using System.Text;

namespace Benenden.Core.Interface
{
    public interface IGenericRespository <T>
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        IEnumerable<T> GetProductperMember(int MemberId);
    }
}
