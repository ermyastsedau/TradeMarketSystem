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
    public class CommodityController : Controller
    {
        private TradeDbContext db = new TradeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Commodities_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Commodity> commodities = db.Commodities;
            DataSourceResult result = commodities.ToDataSourceResult(request, commodity => new {
                CommodityId = commodity.CommodityId,
                Name = commodity.Name,
                Code = commodity.Code,
                UnitOfMeasurementId = commodity.UnitOfMeasurementId,
                CommodityCategoryId = commodity.CommodityCategoryId
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Commodities_Create([DataSourceRequest]DataSourceRequest request, Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                var entity = new Commodity
                {
                    Name = commodity.Name,
                    Code = commodity.Code,
                    UnitOfMeasurementId = commodity.UnitOfMeasurementId,
                    CommodityCategoryId = commodity.CommodityCategoryId
                };

                db.Commodities.Add(entity);
                db.SaveChanges();
                commodity.CommodityId = entity.CommodityId;
            }

            return Json(new[] { commodity }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Commodities_Update([DataSourceRequest]DataSourceRequest request, Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                var entity = new Commodity
                {
                    CommodityId = commodity.CommodityId,
                    Name = commodity.Name,
                    Code = commodity.Code,
                    UnitOfMeasurementId = commodity.UnitOfMeasurementId,
                    CommodityCategoryId = commodity.CommodityCategoryId
                };

                db.Commodities.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { commodity }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Commodities_Destroy([DataSourceRequest]DataSourceRequest request, Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                var entity = new Commodity
                {
                    CommodityId = commodity.CommodityId,
                    Name = commodity.Name,
                    Code = commodity.Code,
                    UnitOfMeasurementId = commodity.UnitOfMeasurementId,
                    CommodityCategoryId = commodity.CommodityCategoryId
                };

                db.Commodities.Attach(entity);
                db.Commodities.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { commodity }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
