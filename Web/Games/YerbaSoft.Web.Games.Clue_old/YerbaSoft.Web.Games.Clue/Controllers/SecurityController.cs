using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YerbaSoft.Web.Games.Clue.Controllers
{
    public class SecurityController : BaseController
    {
        public ActionResult Usuario(Guid? id, Guid? obj)
        {
            using (var srv = BLL.Factory.GetSecurityService(CurrentUser))
            {
                DTO.Usuario dto = null;

                if (obj.HasValue)
                {
                    var result = Models.Site.Session.Pop<YerbaSoft.DTO.Result<DTO.Usuario>>(this.Session, obj.Value);
                    if (result != null) // ésto ocurre cuando apretan F5 ya que la variables PushPop no está más en memoria
                    {
                        dto = result.Data;
                        ViewBag.MsgErr = result.Messages.ToString(new YerbaSoft.DTO.Exceptions.ExceptionConvertTemplateOnlyMessage());
                    }
                }

                if (dto == null)
                {
                    dto = base.GetFromRequest<DTO.Usuario>(srv);
                }

                return View(dto);
            }
        }

        [HttpPost]
        public ActionResult SaveUsuario(HttpPostedFileBase UploadLogo)
        {
            using (var srv = BLL.Factory.GetSecurityService(CurrentUser))
            {
                var dto = base.GetFromRequest<DTO.Usuario>(srv);

                if (UploadLogo != null)
                {
                    var filename = Guid.NewGuid().ToString().Replace("-", "") + UploadLogo.FileName.Substring(UploadLogo.FileName.LastIndexOf('.'));
                    UploadLogo.SaveAs(Server.MapPath("~/Content/UserProfiles/" + filename));
                    dto.Logo = filename;
                }

                try
                {
                    if (dto.Id == default(Guid))
                        srv.Insert(dto, this.Request.Form["Password"]);
                    else
                        srv.Update(dto);

                    Models.Site.Session.SetUsuarioActivo(this.Session, dto);    // piso el usuario en session porque pudo haber cambiado
                }
                catch (Exception ex)
                {
                    var obj = new YerbaSoft.DTO.Result<DTO.Usuario>(dto).AddError(ex);
                    var idObj = Models.Site.Session.Push(this.Session, obj);
                    return RedirectToAction("Usuario", new { id = dto.Id, obj = idObj });
                }

                return RedirectToAction("Usuario", new { Id = dto.Id });
            }
        }
    }
}