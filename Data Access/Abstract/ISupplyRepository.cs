using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Abstract
{
    public interface ISupplyRepository :IEntityRepositoryBase<Supply>
    {
    }
}
