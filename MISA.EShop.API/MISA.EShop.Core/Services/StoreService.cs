using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Services
{
    public class StoreService : BaseService<Store>, IStoreService
    {
        IUnitOfWork _unitOfWork;
        public StoreService(IUnitOfWork unitOfWork, IBaseRepository<Store> baseRepository) : base(baseRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public ResponseResult GetCountStores()
        {
            var result = new ResponseResult();
            var total = _unitOfWork.Store.GetCountStores();
            if (total > 0)
            {
                result.Data = total;
                result.ErrorCode = Enum.ErrorCode.NONE;
                result.IsSuccess = true;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.NOCONTENT;
                result.Data = null;
            }

            return result;
        }

        public ResponseResult GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int status)
        {
            var result = new ResponseResult();
            var stores = _unitOfWork.Store.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);
            if (stores != null)
            {
                result.IsSuccess = true;
                result.ErrorCode = Enum.ErrorCode.NONE;
                result.Data = stores;
                result.DevMsg = Resources.ResourceMessage.Get_Success;
                result.UserMsg = Resources.ResourceMessage.Get_Success;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.NOTFOUND;
                result.UserMsg = Resources.ResourceMessage.Error_NotFound;

            }
            return result;
        }

        public ResponseResult GetStoreByStoreCode(string storeCode)
        {
            var result = new ResponseResult();
            var store = _unitOfWork.Store.GetStoreByStoreCode(storeCode);
            if (store != null)
            {
                result.Data = store;
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.BADREQUEST;
                result.UserMsg = Resources.ResourceMessage.Error_Duplicate;
                result.DevMsg = Resources.ResourceMessage.Error_Duplicate;
            }
            else
            {
                result.IsSuccess = true;
                result.ErrorCode = Enum.ErrorCode.NONE;

            }
            return result;
        }

        public ResponseResult GetStoreFilter(string storeCode, 
                string storeName, 
                string address, 
                string phoneNumber, 
                int? status)
        {
            var result = new ResponseResult();

            var stores = _unitOfWork.Store.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);

            if (stores != null)
            {
                result.Data = stores;
                result.IsSuccess = true;
                result.ErrorCode = Enum.ErrorCode.NONE;
                result.UserMsg = Resources.ResourceMessage.Get_Success;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.NOCONTENT;
                result.UserMsg = Resources.ResourceMessage.Error_Filter;
                result.DevMsg = Resources.ResourceMessage.Error_Filter;
            }
            return result;
        }


        public ResponseResult GetStoreByIndexOffset(int positionStart, int offset)
        {
            var result = new ResponseResult();
            var list = _unitOfWork.Store.GetStoreByIndexOffset(positionStart, offset);

            if (list != null)
            {
                result.IsSuccess = true;
                result.Data = list;
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorCode = Enum.ErrorCode.NOCONTENT;
                result.UserMsg = Resources.ResourceMessage.Error_NotFound;
            }

            return result;
        }

        public ResponseResult GetStorePaging(int pageSize, int pageIndex)
        {
            var result = new ResponseResult();
            var pagingResult = _unitOfWork.Store.GetStorePaging(pageSize, pageIndex);

            if (pagingResult != null)
            {
                result.IsSuccess = true;
                result.Data = pagingResult;
                result.ErrorCode = Enum.ErrorCode.NONE;
            }
            else
            {
                result.ErrorCode = Enum.ErrorCode.NOCONTENT;
                result.UserMsg = Resources.ResourceMessage.Error_NotFound;
                result.DevMsg = Resources.ResourceMessage.Error_Paging;
            }
            return result;
        }

        /// <summary>
        /// Hàm validate dữ liệu 
        /// </summary>
        /// <param name="responseResult">Kết quả trả về xem có </param>
        /// <param name="entity"></param>
        public override void Validate(ResponseResult responseResult, Store entity, Guid? entityID, string functionName)
        {
            var propertyUnique = "Mã cửa hàng";
            var propertyRequired = new Dictionary<string, string>();
            propertyRequired.Add("Mã cửa hàng", entity.StoreCode);
            propertyRequired.Add("Tên cửa hàng", entity.StoreName);
            propertyRequired.Add("Địa chỉ", entity.Address);

            foreach (var property in propertyRequired)
            {
                if (string.IsNullOrEmpty(property.Value))
                {
                    responseResult.IsSuccess = false;
                    responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                    responseResult.DevMsg = property.Key + " " + Resources.ResourceMessage.Error_Required;
                    responseResult.UserMsg = property.Key + " " + Resources.ResourceMessage.Error_Required;
                }
            }

            // kiểm tra xem trường nào là duy nhất (có thuộc tính Unique) thì check duplicate

            bool checkDuplicateCode = _unitOfWork.Store.CheckStoreCode(entityID, entity.StoreCode, functionName);

            if (checkDuplicateCode)
            {
                responseResult.IsSuccess = false;
                responseResult.ErrorCode = Enum.ErrorCode.BADREQUEST;
                responseResult.DevMsg = propertyUnique + " " + Resources.ResourceMessage.Error_Duplicate;
                responseResult.UserMsg = propertyUnique + " " + Resources.ResourceMessage.Error_Duplicate;
            }

        }
    }

}
