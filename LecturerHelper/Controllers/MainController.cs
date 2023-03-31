using LecturerHelper.Services;
using Microsoft.AspNetCore.Mvc;

namespace LecturerHelper.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MainController : ControllerBase
    {
        readonly IDataManager _dataManager;

        public MainController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Faculties()
        {
            return Ok(_dataManager.Faculties());
        }

        [HttpGet]
        public IActionResult AutoHosqNumbers()
        {
            return Ok(_dataManager.AutoHosqNumbers());
        }

        [HttpGet]
        public IActionResult Loads()
        {
            return Ok(_dataManager.Loads());
        }

        [HttpGet]
        public IActionResult Kaefics()
        {
            return Ok(_dataManager.Kaefics());
        }

        [HttpGet]
        public IActionResult Patok1s()
        {
            return Ok(_dataManager.Patok1s());
        }

        [HttpGet]
        public IActionResult PatokNaras()
        {
            return Ok(_dataManager.PatokNaras());
        }

        [HttpGet]
        public IActionResult Groups()
        {
            return Ok(_dataManager.Groups());
        }

        [HttpGet]
        public IActionResult GetReport()
        {
            _dataManager.GetReport("a");
            return Ok();
        }
    }
}