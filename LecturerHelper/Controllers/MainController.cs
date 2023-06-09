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
        public IActionResult GetGroupPlan()
        {
            return Ok(_dataManager.GetAllGroupPlan());
        }

        [HttpGet]
        public IActionResult GetGroupPlanByFakulty(string fak)
        {
            return Ok(_dataManager.GetGroupPlanByFakName(fak));
        }

        [HttpGet]
        public IActionResult GetGroupPlanByGroup(string group)
        {
            return Ok(_dataManager.GetGroupPlanByGroup(group));
        }

        [HttpGet]
        public IActionResult GetHosq()
        {
            return Ok(_dataManager.Hosq());
        }

        [HttpGet]
        public IActionResult GetHosqPlan()
        {
            return Ok(_dataManager.GetHosqPlan());
        }

        [HttpGet]
        public IActionResult GetLoadByCode(string code)
        {
            return Ok(_dataManager.GetLoadByCode(code));
        }
    }
}