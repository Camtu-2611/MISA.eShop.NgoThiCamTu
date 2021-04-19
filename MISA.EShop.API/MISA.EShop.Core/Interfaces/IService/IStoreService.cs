using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Interfaces
{
    public interface IStoreService : IBaseService<Store>
    {
        /// <summary>
        /// Lấy ra số lượng cửa hàng
        /// </summary>
        /// <returns>tổng số cửa hàng</returns>
        /// CreatedBy: nctu 14.04.2021
        ResponseResult GetCountStores();

        /// <summary>
        /// Lấy thông tin cửa hàng theo mã cửa hàng
        /// </summary>
        /// <param name="storeCode">Mã cửa hàng</param>
        /// <returns>Thông tin cửa hàng có mã là tham số truyền vào</returns>
        /// CreatedBy: nctu 14.04.2021
        ResponseResult GetStoreByStoreCode(string storeCode);

        /// <summary>
        /// Lọc thông tin theo các tiêu chí
        /// </summary>
        /// <param name="storeCode">Mã cửa hàng</param>
        /// <param name="storeName">Tên cửa hàng</param>
        /// <param name="address">Địa chỉ</param>
        /// <param name="phoneNumber">Số điện thoại</param>
        /// <param name="status">Trạng thái hoạt động</param>
        /// <returns>Danh sách cửa hàng tìm thấy</returns>
        /// CreatedBy: nctu 14.04.2021
        ResponseResult GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status);

        /// <summary>
        /// Lấy thông tin cửa hàng theo vị trí đầu vào và số lượng
        /// </summary>
        /// <param name="positionStart">Vị trí bắt đầu</param>
        /// <param name="offset">Số lượng</param>
        /// <returns>Danh sách cửa hàng</returns>
        /// CreatedBy: nctu 14.04.2021
        ResponseResult GetStoreByIndexOffset(int positionStart, int offset);

        /// <summary>
        /// Lấy danh sách cửa hàng theo số lượng bản ghi và chỉ số trang
        /// </summary>
        /// <param name="pageSize">Số lượng bản ghi trong 1 trang</param>
        /// <param name="pageIndex">Chỉ số bản ghi</param>
        /// <returns>Danh sách cửa hàng</returns>
        /// CreatedBy: nctu 20.04.2021
        ResponseResult GetStorePaging(int pageSize, int pageIndex);
    }
}
