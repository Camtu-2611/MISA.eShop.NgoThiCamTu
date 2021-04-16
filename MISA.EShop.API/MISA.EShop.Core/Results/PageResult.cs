using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Results
{
    /// <summary>
    /// Lớp lưu trữ thông tin của một trang danh sách
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T>
    {
        /// <summary>
        /// Danh sách đối tượng trả về
        /// </summary>
        public IEnumerable<T> ListItems { get; set; }

        /// <summary>
        /// Tổng số bản ghi của trang đó
        /// </summary>
        public int TotalRecord { get; set; }
    }
}
