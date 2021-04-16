using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IStoreRepository Store { get; }
        ICountryRepository Country { get; }
        IProvinceRepository Province { get; }
        IDistrictRepository District { get; }
        IWardRepository Ward { get; }
    }
}
