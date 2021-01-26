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
    public class MarketController : Controller
    {
        private TradeDbContext db = new TradeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Markets_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Market> markets = db.Markets;
            DataSourceResult result = markets.ToDataSourceResult(request, market => new {
                MarketId = market.MarketId,
                Name = market.Name,
                Code = market.Code,
                WeredaId = market.WeredaId,
                SubcityId = market.SubcityId,
                Description = market.Description,
                Remark = market.Remark
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Markets_Create([DataSourceRequest]DataSourceRequest request, Market market)
        {
            if (ModelState.IsValid)
            {
                var entity = new Market
                {
                    Name = market.Name,
                    Code = market.Code,
                    WeredaId = market.WeredaId,
                    SubcityId = market.SubcityId,
                    Description = market.Description,
                    Remark = market.Remark
                };

                db.Markets.Add(entity);
                db.SaveChanges();
                market.MarketId = entity.MarketId;
            }

            return Json(new[] { market }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Markets_Update([DataSourceRequest]DataSourceRequest request, Market market)
        {
            if (ModelState.IsValid)
            {
                var entity = new Market
                {
                    MarketId = market.MarketId,
                    Name = market.Name,
                    Code = market.Code,
                    WeredaId = market.WeredaId,
                    SubcityId = market.SubcityId,
                    Description = market.Description,
                    Remark = market.Remark
                };

                db.Markets.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { market }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Markets_Destroy([DataSourceRequest]DataSourceRequest request, Market market)
        {
            if (ModelState.IsValid)
            {
                var entity = new Market
                {
                    MarketId = market.MarketId,
                    Name = market.Name,
                    Code = market.Code,
                    WeredaId = market.WeredaId,
                    SubcityId = market.SubcityId,
                    Description = market.Description,
                    Remark = market.Remark
                };

                db.Markets.Attach(entity);
                db.Markets.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { market }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
