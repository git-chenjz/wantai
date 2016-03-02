using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccess.Domain;
using DataService;
using MyFrameWork.Mvc;
using MyFrameWork.Common;
using System.ComponentModel;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class CycleTableController : Controller
    {
        #region 字段

        private ICycleTableService _cycleTableService;
        private ILBSService _vaccineTypeService;

        #endregion

        #region 构造

        public CycleTableController(ICycleTableService cycleTableService,ILBSService vaccineTypeService)
        {
            _cycleTableService = cycleTableService;
            _vaccineTypeService = vaccineTypeService;
        }

        #endregion

        #region 方法

        public ActionResult Index(int? typeId)
        {
            ViewBag.Types = _vaccineTypeService.GetVaccineTypes();
            var lists = _cycleTableService.GetCycleTableList(typeId ?? -1);
            if (Request.IsAjaxRequest())
                return PartialView("CycleTableList", lists);
            return View(lists);
        }

        public ActionResult InsertCycleTable()
        {
            ViewBag.Types = _vaccineTypeService.GetVaccineTypes();
            return View();
        }

        public ActionResult UpdateCycleTable(int id)
        {
            ViewBag.Types = _vaccineTypeService.GetVaccineTypes();
            var list = _cycleTableService.GetCycleTableById(id);
            return View(list);
        }
        [Description("保存")]
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveCycleTable(CycleTable table)
        {
            var result = 0;

            if (table.Id > 0)
            {
                CycleTable model = _cycleTableService.GetCycleTableById(table.Id);
                model.Title = table.Title;
                model.Content = table.Content;
                model.IsShow = table.IsShow;
                model.Sponsor = table.Sponsor;
                model.CreateTime = DateTime.Now;
                result = _cycleTableService.Update(model);
            }
            else
            {
                table.CreateTime = DateTime.Now;
                result = _cycleTableService.Insert(table);
            }

            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "保存成功" : "保存失败"));
        }
        [Description("删除")]
        [HttpPost]
        public JsonResult DeleteCycleTable(int[] ids)
        {
            var result = 0;

            result = _cycleTableService.DeleteCycleTable(ids);

            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "删除成功" : "删除失败"));
        }

        #endregion

    }
}