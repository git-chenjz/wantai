using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using DataAccess.Domain;
using MyFrameWork.Mvc;
using DataService;
using MyFrameWork.Common;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    [AuthorizeFilter]
    public class PurviewController : GeneralController
    {
        #region 字段
        private IPurviewService _purviewService;
        private IUsersService _userService;
        #endregion

        #region 构造
        public PurviewController(IPurviewService purviewService, IUsersService userService)
        {
            _purviewService = purviewService;
            _userService = userService;
        }
        #endregion

        #region 功能管理
        [Description("功能管理：包括栏目、功能、外链")]
        public ActionResult Index()
        {
            var list = _purviewService.GetFeatures();
            return View(list);
        }

        [Description("新增功能")]
        public ActionResult FeaturesInsert()
        {
            var list = _purviewService.GetFeatures();
            ViewBag.FristFeatures = list.Where(c => c.Pid == 0);
            ViewBag.ReadAction = _purviewService.GetActionResult();
            return View();
        }

        [Description("编辑功能")]
        public ActionResult FeaturesUpdate(int id)
        {
            var list = _purviewService.GetFeatures();
            ViewBag.FristFeatures = list.Where(c => c.Pid == 0);
            ViewBag.ReadAction = _purviewService.GetActionResult();
            var item = _purviewService.GetFeatures(id);
            return View(item);
        }
        [Description("保存功能")]
        [HttpPost]
        public JsonResult FeaturesSave(Features item)
        {
            int result = 0;
            if (string.IsNullOrEmpty(item.Name)) return Json(new RetrunJsonMsg(false, "名称没有填写"));
            if (item.Pid != 0 && item.ID == item.Pid) return Json(new RetrunJsonMsg(false, "上级不可以是本身"));
            if (item.ID > 0) result = _purviewService.UpdateFeatures(item);
            else result = _purviewService.InsertFeatures(item);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "保存成功" : "保存失败"));
        }
        [Description("删除功能")]
        [HttpPost]
        public JsonResult FeaturesDelete(int[] id)
        {
            int result = 0;
            if (id != null)
                result = _purviewService.DeleteFeatures(id);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "删除成功" : "删除失败"));
        }
        #endregion

        #region 功能操作
        [Description("功能操作")]
        public ActionResult Operate(int id)
        {
            var list = _purviewService.GetOperate(id);
            ViewBag.FeaturesID = id;
            return View(list);
        }

        [Description("新增功能操作")]
        public ActionResult OperateInsert(int id)
        {
            ViewBag.FeaturesID = id;
            ViewBag.ReadAction = _purviewService.GetActionResult();
            return View();
        }

        [Description("编辑功能操作")]
        public ActionResult OperateUpdate(int id)
        {
            var item = _purviewService.GetOperateFrist(id);
            ViewBag.ReadAction = _purviewService.GetActionResult();
            return View(item);
        }
        [Description("保存功能操作")]
        [HttpPost]
        public JsonResult OperateSave(Operate item)
        {
            int result = 0;
            if (item.Name.IsNullOrEmpty()) return Json(new RetrunJsonMsg(false, "名称没有填写"));
            if (item.FeaturesID == 0) return Json(new RetrunJsonMsg(false, "功能没有选择"));
            if (item.ID > 0) result = _purviewService.UpdateOperate(item);
            else result = _purviewService.InsertOperate(item);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "保存成功" : "保存失败"));
        }
        [Description("删除功能操作")]
        [HttpPost]
        public JsonResult OperateDelete(int[] id)
        {
            int result = 0;
            if (id != null)
                result = _purviewService.DeleteOperate(id);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "删除成功" : "删除失败"));
        }
        #endregion

        #region 权限字段
        [Description("权限字段")]
        public ActionResult PurviewField(int id, int type)
        {
            var list = _purviewService.GetPurviewField(type, id);
            ViewBag.ObjID = id;
            ViewBag.Type = type;
            return View(list);
        }

        [Description("新增权限字段")]
        public ActionResult PurviewFieldInsert(int id, int type)
        {
            ViewBag.ObjID = id;
            ViewBag.Type = type;
            return View();
        }

        [Description("编辑权限字段")]
        public ActionResult PurviewFieldUpdate(int id)
        {
            var item = _purviewService.GetPurviewField(id);
            return View(item);
        }
        [Description("保存权限字段")]
        [HttpPost]
        public JsonResult PurviewFieldSave(PurviewField item)
        {
            int result = 0;
            if (item.Name.IsNullOrEmpty()) return Json(new RetrunJsonMsg(false, "名称没有填写"));
            if (item.ObjID == 0) return Json(new RetrunJsonMsg(false, "没有依赖的功能或操作"));
            if (item.ID > 0) result = _purviewService.UpdatePurviewField(item);
            else result = _purviewService.InsertPurviewField(item);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "保存成功" : "保存失败"));
        }
        [Description("删除权限字段")]
        [HttpPost]
        public JsonResult PurviewFieldDelete(int[] id)
        {
            int result = 0;
            if (id != null)
                result = _purviewService.DeletePurviewField(id);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "删除成功" : "删除失败"));
        }
        #endregion

        #region 管理员
        [Description("管理员")]
        public ActionResult AdminInfo()
        {
            var list = _purviewService.GetAdmin();
            return View(list);
        }

        [Description("新增管理员")]
        public ActionResult AdminInsert()
        {
            ViewBag.Role = _purviewService.GetRole();
            return View();
        }

        [Description("编辑管理员")]
        public ActionResult AdminUpdate(int id)
        {
            var item = _purviewService.GetAdmin(id);
            ViewBag.Role = _purviewService.GetRole();
            return View(item);
        }
        [Description("保存管理员")]
        [HttpPost]
        public JsonResult AdminSave(AdminDto item)
        {
            int result = 0;
            if (item.UserName.IsNullOrEmpty()) return Json(new RetrunJsonMsg(false, "名称没有填写"));
            if (!item.RoleID.HasValue) return Json(new RetrunJsonMsg(false, "角色没有选择"));
            if (item.ID > 0) result = _purviewService.UpdateAdmin(item);
            else result = _purviewService.InsertAdmin(item);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "保存成功" : "保存失败"));
        }
        [Description("删除管理员")]
        [HttpPost]
        public JsonResult AdminDelete(int[] id)
        {
            int result = 0;
            if (id != null)
                result = _purviewService.DeleteAdmin(id);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "删除成功" : "删除失败"));
        }
        [HttpPost]
        [@Authorize(AuthorizeEnum.CheckLogin)]
        public JsonResult CheckUserName(int? id, string username)
        {
            bool result = false;
            if (id.HasValue)
            {
                var item = _purviewService.GetAdmin(id.Value);
                result = username == item.UserName;
                if (!result)
                {
                    item = _purviewService.GetAdmin(username);
                    result = item == null;
                }
            }
            else
            {
                var item = _purviewService.GetAdmin(username);
                result = item == null;
            }
            return Json(new { valid = result });
        }
        #endregion

        #region 角色
        [Description("角色")]
        public ActionResult RoleInfo()
        {
            var list = _purviewService.GetRole();
            return View(list);
        }

        [Description("新增角色")]
        public ActionResult RoleInsert()
        {
            ViewBag.Features = _purviewService.GetFeatures();
            ViewBag.Operates = _purviewService.GetOperate();
            ViewBag.Fields = _purviewService.GetPurviewField();
            return View();
        }

        [Description("编辑角色")]
        public ActionResult RoleUpdate(int id)
        {
            var item = _purviewService.GetRole(id);
            ViewBag.Features = _purviewService.GetFeatures();
            ViewBag.Operates = _purviewService.GetOperate();
            ViewBag.Fields = _purviewService.GetPurviewField();
            return View(item);
        }
        [Description("保存角色")]
        [HttpPost]
        public JsonResult RoleSave(Role item, string[] role_feature, string[] role_actions, string[] role_field)
        {
            int result = 0;
            if (item.RoleName.IsNullOrEmpty()) return Json(new RetrunJsonMsg(false, "名称没有填写"));
            List<Permission> permission = new List<Permission>();
            if (role_feature != null)
            {
                foreach (var feature in role_feature)
                {
                    var arrs = feature.Split(',');
                    var per = new Permission { ID = int.Parse(arrs[0]), Url = arrs[1], Type = int.Parse(arrs[2]) };
                    if (role_field != null)
                    {
                        var f_0 = role_field.Where(c => c.IndexOf("0," + per.ID + ",") == 0).ToArray();
                        if (f_0.Length > 0)
                        {
                            foreach (var f in f_0)
                                per.Fields.Add(f.Split(',')[2]);
                        }
                    }
                    permission.Add(per);
                }
            }
            if (role_actions != null)
            {
                foreach (var actions in role_actions)
                {
                    var arrs = actions.Split(',');
                    var per = new Permission { ID = int.Parse(arrs[0]), Url = arrs[1], Type = int.Parse(arrs[2]) };
                    if (role_field != null)
                    {
                        var f_0 = role_field.Where(c => c.IndexOf("1," + per.ID + ",") == 0).ToArray();
                        if (f_0.Length > 0)
                        {
                            foreach (var f in f_0)
                                per.Fields.Add(f.Split(',')[2]);
                        }
                    }
                    permission.Add(per);
                }
            }
            if (permission.Count > 0)
                item.Actions = permission.ToJson();
            if (item.ID > 0) result = _purviewService.UpdateRole(item);
            else result = _purviewService.InsertRole(item);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "保存成功" : "保存失败"));
        }
        [Description("删除角色")]
        [HttpPost]
        public JsonResult RoleDelete(int[] id)
        {
            int result = 0;
            if (id != null)
                result = _purviewService.DeleteRole(id);
            return Json(new RetrunJsonMsg(result > 0, result > 0 ? "删除成功" : "删除失败"));
        }
        #endregion
    }
}