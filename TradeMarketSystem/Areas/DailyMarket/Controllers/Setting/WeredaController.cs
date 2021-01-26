﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TradeMarketSystem.Core.Model.Daily_Market;
using TradeMarketSystem.DataAccess.Context;

namespace TradeMarketSystem.Areas.DailyMarket.Controllers.Setting
{
    public class WeredaController : Controller
    {
        private TradeDbContext db = new TradeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weredas_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Wereda> weredas = db.Weredas;
            DataSourceResult result = weredas.ToDataSourceResult(request, wereda => new {
                WeredaId = wereda.WeredaId,
                Code = wereda.Code,
                Name = wereda.Name,
                SubcityId = wereda.SubcityId,
                Description = wereda.Description,
                Remark = wereda.Remark
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Weredas_Create([DataSourceRequest]DataSourceRequest request, Wereda wereda)
        {
            if (ModelState.IsValid)
            {
                var entity = new Wereda
                {
                    Code = wereda.Code,
                    Name = wereda.Name,
                    SubcityId = wereda.SubcityId,
                    Description = wereda.Description,
                    Remark = wereda.Remark
                };

                db.Weredas.Add(entity);
                db.SaveChanges();
                wereda.WeredaId = entity.WeredaId;
            }

            return Json(new[] { wereda }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Weredas_Update([DataSourceRequest]DataSourceRequest request, Wereda wereda)
        {
            if (ModelState.IsValid)
            {
                var entity = new Wereda
                {
                    WeredaId = wereda.WeredaId,
                    Code = wereda.Code,
                    Name = wereda.Name,
                    SubcityId = wereda.SubcityId,
                    Description = wereda.Description,
                    Remark = wereda.Remark
                };

                db.Weredas.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { wereda }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Weredas_Destroy([DataSourceRequest]DataSourceRequest request, Wereda wereda)
        {
            if (ModelState.IsValid)
            {
                var entity = new Wereda
                {
                    WeredaId = wereda.WeredaId,
                    Code = wereda.Code,
                    Name = wereda.Name,
                    SubcityId = wereda.SubcityId,
                    Description = wereda.Description,
                    Remark = wereda.Remark
                };

                db.Weredas.Attach(entity);
                db.Weredas.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { wereda }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
