﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TradeMarketSystem.DataAccess.Context;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TradeMarketSystem.Core.Model.Daily_Market;
using TradeMarketSystem.Core.Model.Common;

namespace TradeMarketSystem.Areas.DailyMarket.Setting.Controllers
{
    public class SubcityController : Controller
    {
        private TradeDbContext db = new TradeDbContext();

        public ActionResult Index()
        {
            ViewBag.page = "Sub City";
            return View();
        }

        public ActionResult SubCities_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Core.Model.Common.SubCity> subcities = db.SubCities;
            DataSourceResult result = subcities.ToDataSourceResult(request, subCity => new {
                SubCityId = subCity.SubCityId,
                Name = subCity.Name,
                Code = subCity.Code
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SubCities_Create([DataSourceRequest]DataSourceRequest request, SubCity subCity)
        {
            if (ModelState.IsValid)
            {
                var entity = new SubCity
                {
                    Name = subCity.Name,
                    Code = subCity.Code
                };

                db.SubCities.Add(entity);
                db.SaveChanges();
                subCity.SubCityId = entity.SubCityId;
            }

            return Json(new[] { subCity }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SubCities_Update([DataSourceRequest]DataSourceRequest request, SubCity subCity)
        {
            if (ModelState.IsValid)
            {
                var entity = new SubCity
                {
                    SubCityId = subCity.SubCityId,
                    Name = subCity.Name,
                    Code = subCity.Code
                };

                db.SubCities.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { subCity }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SubCities_Destroy([DataSourceRequest]DataSourceRequest request, SubCity subCity)
        {
            if (ModelState.IsValid)
            {
                var entity = new SubCity
                {
                    SubCityId = subCity.SubCityId,
                    Name = subCity.Name,
                    Code = subCity.Code
                };

                db.SubCities.Attach(entity);
                db.SubCities.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { subCity }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
