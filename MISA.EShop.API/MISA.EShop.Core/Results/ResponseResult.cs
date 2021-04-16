using MISA.EShop.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Results
{
    public class ResponseResult
    {
        // thông báo thao tác thành công hay thất bại, default là true
        public bool IsSuccess { get; set; } = true;

        // nội dung thông báo cho người lập trình
        public string DevMsg { get; set; }

        // nội dung thông báo cho user
        public string UserMsg { get; set; }

        // mã code lỗi của thao tác, mặc định ban đầu là NONE - không có lỗi
        public ErrorCode ErrorCode { get; set; } = ErrorCode.NONE;

        // thông tin tìm hiểu thêm cho dev
        public string MoreInfo { get; set; }

        // mã lỗi để tìm kiếm trên trang web nào đó ví dụ abc.com.vn
        public string TraceId { get; set; }

        // dữ liệu của kết quả trả về
        public object Data { get; set; }

        
    }
}
