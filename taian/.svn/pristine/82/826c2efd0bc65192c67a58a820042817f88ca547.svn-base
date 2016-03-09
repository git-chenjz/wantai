using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class InoculationController : Controller
    {
        #region 字段
        private IInoculationService _inoculationService;
        private ILBSService _lbsService;
        #endregion

        #region 构造
        public InoculationController(IInoculationService inoculationService, ILBSService lbsService)
        {
            _inoculationService = inoculationService;
            _lbsService = lbsService;
        }
        #endregion

        #region 配置
        public ActionResult Index()
        {
            var configs = _inoculationService.GetInoculationConfigs().OrderBy(a=>a.VaccineTypeID).ThenBy(a=>a.PhaseCode);

            return View(configs);
        }

        public ActionResult EditConfig(int? id)
        {
            ViewBag.types = _lbsService.GetVaccineTypes();

            if (id == null)
                return View(new InoculationConfig { });

            var config = _inoculationService.GetInoculationConfig(id.Value);
            return View(config == null ? new InoculationConfig { } : config);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveConfig(InoculationConfig config)
        {
            _inoculationService.EditInoculationConfig(config);

            return Json(new { success = true, msg = "保存成功" });
        }

        public ActionResult DeleteConfig(int id)
        {
            _inoculationService.DeleteInoculationConfig(id);

            return RedirectToAction("Index");
        }
        #endregion

        #region 用户数据
        public new ActionResult User(int page=1,InoculationStatus? status=null)
        {
            var records = _inoculationService.GetInoculationRecords(page, status);
            ViewBag.status = status;

            return View(records);
        }
        #endregion
    }
}