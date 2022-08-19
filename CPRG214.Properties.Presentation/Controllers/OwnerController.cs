using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.Properties.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CPRG214.Properties.BLL;
using Microsoft.AspNetCore.Authorization;

namespace CPRG214.Properties.Presentation.Controllers
{
    [Authorize]
    public class OwnerController : Controller
    {
        // GET: OwnerController
        public ActionResult Index()
        {
            var owners = OwnerManager.GetAll();
            return View(owners);
        }

        // GET: OwnerController/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                //call the OwnerManager to add

                OwnerManager.Add(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var owner = OwnerManager.Find(id);
            return View(owner);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Owner owner)
        {
            try
            {
                //call the OwnerManager to add
                OwnerManager.Update(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
