using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class LBSController : Controller
    {
        #region 字段
        private ILBSService _lbsService;
        #endregion

        #region 构造
        public LBSController(ILBSService lbsService)
        {
            _lbsService = lbsService;
        }
        #endregion

        #region 位置
        public ActionResult Index(int page = 1)
        {
            var result = _lbsService.GetPagedLBS(page);
            return View(result);
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.types = _lbsService.GetVaccineTypes();

            if (id == null)
                return View(new LBS { Latitude = 24.500655, Longitude = 118.147288 });

            var lbs = _lbsService.GetLBS(id.Value);
            return View(lbs == null ? new LBS { Latitude = 24.500655, Longitude = 118.147288 } : lbs);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(LBS lbs)
        {
            var typeid = string.IsNullOrWhiteSpace(Request.Params["TypeID"]) ? "" : Request.Params["TypeID"];

            var ids = typeid.Split(',').Where(a => string.IsNullOrWhiteSpace(a) == false).Distinct().Select(a => int.Parse(a)).ToList();

            _lbsService.EditLBS(lbs, ids);
            return Json(new { msg = "编辑成功", success = true });
        }
        public ActionResult Delete(int id)
        {
            _lbsService.DeleteLBS(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region 疫苗类型
        public ActionResult Vaccine()
        {
            var types = _lbsService.GetVaccineTypes().OrderBy(a => a.Name);

            return View(types);
        }
        public ActionResult VaccineEdit(int? id)
        {
            if (id == null)
                return View(new VaccineType { });

            var type = _lbsService.GetVaccineType(id.Value);
            return View(type == null ? new VaccineType { } : type);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult VaccineSave(VaccineType type)
        {
            _lbsService.EditVaccineType(type);
            return Json(new { msg = "编辑成功", success = true });
        }

        public ActionResult VaccineDelete(int id)
        {
            _lbsService.DeleteVaccineType(id);
            return RedirectToAction("Vaccine");
        }
        #endregion
    }
}