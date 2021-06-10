using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Test_Web_Application.Code;
using Test_Web_Application.Code.IRepository;
using Test_Web_Application.Models;

namespace Test_Web_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployeeRepository _employeeRepository;
        private IEmployeeSlotsRepository _employeeSlotsRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository, IEmployeeSlotsRepository employeeSlotsRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _employeeSlotsRepository = employeeSlotsRepository;
        }
        public IActionResult BookMeeting(int id)
        {
            var empList = _employeeRepository.GetAllEmployees().Where(s => s.EmployeeId != id).ToList();
            EmployeeSlots obj = new EmployeeSlots();
            obj.EmployeeId1 = id;
            ViewBag.Emp = new SelectList(empList, "EmployeeId", "FirstName");
            return PartialView("_BookMeetingPartial", obj);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult BookMeeting(EmployeeSlots dtoEmp)
        {
            if (ModelState.IsValid)
            {
                DateTime dt;
                if (!DateTime.TryParseExact(dtoEmp.Meeting_FromTime, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                }
                TimeSpan time = dt.TimeOfDay;
                dtoEmp.MeetingFromTime = time;
                if (!DateTime.TryParseExact(dtoEmp.Meeting_ToTime, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                }
                time = dt.TimeOfDay;
                dtoEmp.MeetingToTime = time;
                dt = Convert.ToDateTime(dtoEmp.Meeting_Date);
                dtoEmp.MeetingDate = dt.Date;
                var empList = _employeeRepository.GetAllEmployees().Where(s => s.EmployeeId != dtoEmp.EmployeeId1).ToList();
                ViewBag.Emp = new SelectList(empList, "EmployeeId", "FirstName");
                dtoEmp.CreatedOn = DateTime.Now;
                _employeeSlotsRepository.SaveEmployeeSlots(dtoEmp);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var empList = _employeeRepository.GetAllEmployees();
            foreach (var emp in empList)
            {
                emp.employeeSlots = new List<EmployeeSlots>();
                var empSlot = _employeeSlotsRepository.GetEmployeeSlotsByTodayEmpId(empId: emp.EmployeeId).ToList();
                if (empSlot != null && empSlot.Count > 0)
                {
                    emp.employeeSlots.AddRange(empSlot);
                }
            }
            return View(empList);
        }
        public ActionResult GetEmployeeSlot(int empId, string dt)
        {
            string st = "";
            DateTime DateData = Convert.ToDateTime(dt);
            var empSlotL = _employeeSlotsRepository.GetEmployeeSlotsByEmpId(empId, DateData).ToList();
            foreach (var empSlot in empSlotL)
            {
                TimeSpan storedTime = (TimeSpan)empSlot.MeetingFromTime;
                string fromTime = storedTime.TotalSeconds.ToString();
                storedTime = (TimeSpan)empSlot.MeetingToTime;
                string ToTime = (storedTime.TotalSeconds - 1).ToString();
                st = st + "" + fromTime + "," + ToTime + "-";
            }
            st = st == "" ? st : st.Remove(st.Length - 1, 1);
            return Content(st);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
