using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    
    public class AddressController : Controller
    {
        AddressBLL bll = new AddressBLL();
        // GET: Admin/Address
        public ActionResult AddAddress()
        {
            AddressDTO model = new AddressDTO();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddAddress(AddressDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            else
            {
                if (bll.AddAddress(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new AddressDTO();
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }
            }
            return View(model);
        }

        public ActionResult AddressList()
        {
            List<AddressDTO> model = bll.GetAddresses();
            return View(model);
        }

        public ActionResult UpdateAddress(int ID)
        {
            AddressDTO model = bll.GetAddressByID(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateAddress(AddressDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateAddress(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            
            return View(model);
        }
       
    }
}