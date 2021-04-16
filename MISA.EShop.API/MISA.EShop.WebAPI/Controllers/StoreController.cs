using Microsoft.AspNetCore.Mvc;
using MISA.EShop.Core.Entities;
using MISA.EShop.Core.Interfaces;
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

        /// <summary>
        /// lay du lieu filter
        /// </summary>
        /// <param name="storeCode"></param>
        /// <param name="storeName"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        //[HttpGet]
        //public IActionResult Get([FromBody] string storeCode = "",
        //    [FromBody] string storeName = "",
        //    [FromBody] string address = "",
        //    [FromBody] string phoneNumber = "",
        //    [FromBody] int status = 0)
        //{
        //    var responseResult = _storeService.GetStoreFilter(storeCode, storeName, address, phoneNumber, status);
        //    return Ok(responseResult);
        //}

        [HttpGet("getbycode")]
        public IActionResult Get(string storeCode)
        {
            var responseResult = _storeService.GetStoreByStoreCode(storeCode);
            return Ok(responseResult);
        }
    }
}
