using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService
{
    public interface IBaseService
    {
        AdminDto AdminInfo { get; }
    }
}
