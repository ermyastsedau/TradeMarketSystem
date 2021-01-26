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
    public class UnitOfMeasurementController : Controller
    {
        private TradeDbContext db = new TradeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UnitOfMeasurements_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<UnitOfMeasurement> unitofmeasurements = db.UnitOfMeasurements;
           
            DataSourceResult result = unitofmeasurements.ToDataSourceResult(request, unitOfMeasurement => new {
              
                UnitOfMeasurementId = unitOfMeasurement.UnitOfMeasurementId,
                Name = unitOfMeasurement.Name,
                Code = unitOfMeasurement.Code,
                Symbol = unitOfMeasurement.Symbol,
                Weight = unitOfMeasurement.Weight
            }
            );

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UnitOfMeasurements_Create([DataSourceRequest]DataSourceRequest request, UnitOfMeasurement unitOfMeasurement)
        {
            if (ModelState.IsValid)
            {
                var entity = new UnitOfMeasurement
                {
                    Name = unitOfMeasurement.Name,
                    Code = unitOfMeasurement.Code,
                    Symbol = unitOfMeasurement.Symbol,
                    Weight = unitOfMeasurement.Weight
                };

                db.UnitOfMeasurements.Add(entity);
                db.SaveChanges();
                unitOfMeasurement.UnitOfMeasurementId = entity.UnitOfMeasurementId;
            }

            return Json(new[] { unitOfMeasurement }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UnitOfMeasurements_Update([DataSourceRequest]DataSourceRequest request, UnitOfMeasurement unitOfMeasurement)
        {
            if (ModelState.IsValid)
            {
                var entity = new UnitOfMeasurement
                {
                    UnitOfMeasurementId = unitOfMeasurement.UnitOfMeasurementId,
                    Name = unitOfMeasurement.Name,
                    Code = unitOfMeasurement.Code,
                    Symbol = unitOfMeasurement.Symbol,
                    Weight = unitOfMeasurement.Weight
                };

                db.UnitOfMeasurements.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { unitOfMeasurement }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UnitOfMeasurements_Destroy([DataSourceRequest]DataSourceRequest request, UnitOfMeasurement unitOfMeasurement)
        {
            if (ModelState.IsValid)
            {
                var entity = new UnitOfMeasurement
                {
                    UnitOfMeasurementId = unitOfMeasurement.UnitOfMeasurementId,
                    Name = unitOfMeasurement.Name,
                    Code = unitOfMeasurement.Code,
                    Symbol = unitOfMeasurement.Symbol,
                    Weight = unitOfMeasurement.Weight
                };

                db.UnitOfMeasurements.Attach(entity);
                db.UnitOfMeasurements.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { unitOfMeasurement }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
