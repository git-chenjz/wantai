using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class ADController : Controller
    {
        #region 字段
        private IADService _adService;
        #endregion

        #region 构造
        public ADController(IADService adService)
        {
            _adService = adService;
        }
        #endregion


        public ActionResult Index()
        {
            var ads = _adService.GetADs().OrderByDescending(a => a.CreateTime);

            return View(ads);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return View(new AD { });

            var ad = _adService.GetAD(id.Value);
            return View(ad == null ? new AD { } : ad);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(AD ad)
        {
            _adService.SaveAD(ad);
            return Json(new { msg = "编辑成功", success = true });
        }

        public ActionResult Delete(int id)
        {
            _adService.DeleteAD(id);
            return RedirectToAction("Index");
        }
    }
}