﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace UI.Areas.Admin.Controllers
{
    public class FavController : Controller
    {
        FavBLL bll = new FavBLL();
        // GET: Admin/Fav
        public ActionResult UpdateFav()
        {
            FavDTO dto = new FavDTO();
            dto = bll.GetFav();
            return View(dto);
        }
        [HttpPost]
        public ActionResult UpdateFav(FavDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            else
            {
                if(model.FavImage != null)
                {
                    string favname = "";
                    HttpPostedFileBase postedfilefav = model.FavImage;
                    Bitmap FavImage = new Bitmap(postedfilefav.InputStream);
                    Bitmap resizeFavImage = new Bitmap(FavImage, 100, 100);
                    string ext = Path.GetExtension(postedfilefav.FileName).ToLower();
                    if(ext==".ico" || ext == ".jpg" || ext ==".jpeg" || ext == ".png")
                    {
                        string favunique = Guid.NewGuid().ToString();
                        favname = favunique + postedfilefav.FileName;
                        resizeFavImage.Save(Server.MapPath("~/Areas/Admin/Content/FavImages/" + favname));
                    }
                    else
                    {
                        ViewBag.ProcessState = General.Messages.ExtensionError;
                    }

                }
                if (model.LogoImage != null)
                {
                    string logoname = "";
                    HttpPostedFileBase postedfilelogo = model.LogoImage;
                    Bitmap LogoImage = new Bitmap(postedfilelogo.InputStream);
                    Bitmap resizeLogoImage = new Bitmap(LogoImage, 100, 100);
                    string ext = Path.GetExtension(postedfilelogo.FileName).ToLower();
                    if (ext == ".ico" || ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string favunique = Guid.NewGuid().ToString();
                        logoname = favunique + postedfilelogo.FileName;
                        resizeLogoImage.Save(Server.MapPath("~/Areas/Admin/Content/LogoImages/" + logoname));
                    }
                    else
                    {
                        ViewBag.ProcessState = General.Messages.ExtensionError;
                    }
                }
                FavDTO returndto = new FavDTO();
                returndto = bll.UpdateFav(model);
                if(model.FavImage!= null)
                {
                    if (System.IO.File.Exists("~/Areas/Admin/Content/FavImages/" + returndto.Fav))
                        System.IO.File.Delete("~/Areas/Admin/Content/FavImages/" + returndto.Fav);
                }
                if (model.LogoImage != null)
                {
                    if (System.IO.File.Exists("~/Areas/Admin/Content/LogoImages/" + returndto.Logo))
                        System.IO.File.Delete("~/Areas/Admin/Content/LogoImages/" + returndto.Logo);
                }
            }
            ViewBag.ProcessState = General.Messages.UpdateSuccess;
            return View(model);

        }

    }
}