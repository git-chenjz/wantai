using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WanTaiWeb.Areas.Web.Models;

namespace WanTaiWeb.Areas.Web.Controllers
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

        public ActionResult Index(LBSModel model)
        {
            model.SetData();

            return View(model);
        }

        public ActionResult Map(int id)
        {
            var lbs = _lbsService.GetLBS(id);

            ViewBag.LBSes = _lbsService.GetLBSByArea(null, lbs.Province, lbs.City, lbs.District);

            return View(lbs);
        }
    }
}