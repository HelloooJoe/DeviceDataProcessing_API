using Application.DeviceData.Contracts;
using Application.DeviceData.services;
using CrossCutting.Response;
using Domain.Devices.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.ApiControllers.Iridium
{
    /// <summary>
    /// The Device Controller
    /// </summary>
    /// <seealso cref="BaseApiController" />
    public class IoTController : BaseApiController
    {
        private readonly IDeviceDataService _deviceDataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTController"/> class.
        /// </summary>
        /// <param name="deviceDataService">The device data service.</param>
        public IoTController(IDeviceDataService deviceDataService)
        {
            _deviceDataService = deviceDataService;
        }

        /// <summary>
        /// Gets the data asynchronously.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>IoTData</returns>
        [HttpGet]
        [Route(nameof(GetDataAsync))]
        public async Task<IActionResult> GetDataAsync([FromQuery] GetDataSummaryRequest request)
        {
            var response = new Response<List<IoTData>>
            {
                Data = await _deviceDataService.GetDataAsync(request)
            };
            return Ok(response);
        }

        /// <summary>
        /// Merges the device data asynchronously.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>IoTData</returns>
        [HttpPost]
        [Route(nameof(MergeIoTDataAsync))]
        public async Task<IActionResult> MergeIoTDataAsync(IEnumerable<IFormFile> files)
        {
            var response = new Response<List<IoTData>>
            {
                Data = await _deviceDataService.MergeIoTDataAsync(files)
            };
            return Ok(response);
        }
    }
}
