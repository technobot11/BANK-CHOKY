using BNIWebServiceTest.BusinessLogic;
using BNIWebServiceTest.Models;
using BNIWebServiceTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BNIWebServiceTest.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private StoreProcedure sp = new StoreProcedure();
        // GET: api/Customer
        public IHttpActionResult Get()
        {
            try
            {
                GetSummaryWikipediaAPI svc = new GetSummaryWikipediaAPI();
                var getData = sp.GetAllDataNasabah();

                foreach (var item in getData)
                {
                    item.DeskripsiKota = svc.GetDeskripsiKota(item.Kota).extract;
                }
                
                return Json(getData);
            }
            catch (Exception err)
            {
                return Json(err.Message);
            }
        }

        [Route("GetByNoKTP")]
        public IHttpActionResult Get(string NomorKTP)
        {
            try
            {
                GetSummaryWikipediaAPI svc = new GetSummaryWikipediaAPI();
                var getData = sp.GetAllDataNasabah().Find(e => e.NomorKTP == NomorKTP); //sp.GetDataNasabahByNoKTP(NomorKTP);
                getData.DeskripsiKota = svc.GetDeskripsiKota(getData.Kota).extract;

                return Json(getData);
            }
            catch (Exception err)
            {
                return Json(err.Message);
            }
        }

        [Route("Create")]
        public IHttpActionResult Post([FromBody] CreateModelDataNasabah model)
        {
            try
            {
                sp.InsertDataNasabah(model);
                return Json(new Result(true, "Success"));
            }
            catch (Exception err)
            {
                return Json(new Result(false, "Failed"));
            }
        }

        [Route("Update")]
        public IHttpActionResult Put(UpdateModelDataNasabah model)
        {
            try
            {
                sp.UpdateDataNasabah(model);
                return Json(new Result(true, "Success"));
            }
            catch (Exception err)
            {
                return Json(new Result(false, "Failed"));
            }
        }

        [Route("Delete")]
        public IHttpActionResult Delete([FromBody] DeleteModelDataNasabah model)
        {
            try
            {
                var a = sp.DeleteDataNasabah(model);
                return Json(new Result(true, "Success"));
            }
            catch (Exception err)
            {
                return Json(new Result(false, "Failed"));
            }
        }
    }
}
