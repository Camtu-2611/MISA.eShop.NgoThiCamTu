using Microsoft.AspNetCore.Mvc;
using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.EShop.WebAPI.Controllers
{

    public class StoreController : BaseEntityController<Store>
    {
        private IStoreService _storeService;
        public StoreController(IStoreService storeService) : base(storeService)
        {
            _storeService = storeService;
        }

        // Lấy thông tin đối tượng theo mã
        [HttpGet("getbycode")]
        public IActionResult Get(string storeCode)
        {
            var responseResult = new ResponseResult();
            try
            {
                responseResult = _storeService.GetStoreByStoreCode(storeCode);
            }
            catch (Exception e)
            {
                responseResult.OnException(responseResult, e);
            }

            return Ok(responseResult);
        }
        [HttpGet("Filter")]
        public IActionResult Get([FromQuery] FilterStoreParams filterparams)
        {
            var responseResult = new ResponseResult();
            try
            {
                responseResult = _storeService.GetStoreFilter(filterparams.storeCode, filterparams.storeName, filterparams.address, filterparams.phoneNumber, filterparams.status);
            }
            catch (Exception e)
            {
                responseResult.OnException(responseResult, e);
            }
            return Ok(responseResult);
        }

        [HttpGet("paging")]
        public IActionResult Get(int pageSize, int pageIndex)
        {
            var responseResult = new ResponseResult();
            try
            {
                responseResult = _storeService.GetStorePaging(pageSize, pageIndex);
            }
            catch (Exception e)
            {
                responseResult.OnException(responseResult, e);
            }            

            return Ok(responseResult);
        }

    }
}
