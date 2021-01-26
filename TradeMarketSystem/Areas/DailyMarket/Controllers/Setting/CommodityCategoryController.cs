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
    public class CommodityCategoryController : Controller
    {
        private TradeDbContext db = new TradeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CommodityCategories_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CommodityCategory> commoditycategories = db.CommodityCategories;
            DataSourceResult result = commoditycategories.ToDataSourceResult(request, commodityCategory => new {
                CommodityCategoryId = commodityCategory.CommodityCategoryId,
                Name = commodityCategory.Name,
                Code = commodityCategory.Code,
                Description = commodityCategory.Description,
                Remark = commodityCategory.Remark
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CommodityCategories_Create([DataSourceRequest]DataSourceRequest request, CommodityCategory commodityCategory)
        {
            if (ModelState.IsValid)
            {
                var entity = new CommodityCategory
                {
                    Name = commodityCategory.Name,
                    Code = commodityCategory.Code,
                    Description = commodityCategory.Description,
                    Remark = commodityCategory.Remark
                };

                db.CommodityCategories.Add(entity);
                db.SaveChanges();
                commodityCategory.CommodityCategoryId = entity.CommodityCategoryId;
            }

            return Json(new[] { commodityCategory }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CommodityCategories_Update([DataSourceRequest]DataSourceRequest request, CommodityCategory commodityCategory)
        {
            if (ModelState.IsValid)
            {
                var entity = new CommodityCategory
                {
                    CommodityCategoryId = commodityCategory.CommodityCategoryId,
                    Name = commodityCategory.Name,
                    Code = commodityCategory.Code,
                    Description = commodityCategory.Description,
                    Remark = commodityCategory.Remark
                };

                db.CommodityCategories.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { commodityCategory }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CommodityCategories_Destroy([DataSourceRequest]DataSourceRequest request, CommodityCategory commodityCategory)
        {
            if (ModelState.IsValid)
            {
                var entity = new CommodityCategory
                {
                    CommodityCategoryId = commodityCategory.CommodityCategoryId,
                    Name = commodityCategory.Name,
                    Code = commodityCategory.Code,
                    Description = commodityCategory.Description,
                    Remark = commodityCategory.Remark
                };

                db.CommodityCategories.Attach(entity);
                db.CommodityCategories.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { commodityCategory }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
