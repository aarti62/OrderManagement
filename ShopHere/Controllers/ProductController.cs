using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ShopHere;
using ShopHere.Models;

namespace ShopHere.Controllers
{
    public class ProductController : ApiController
    {
        private OrderManagementEntities db = new OrderManagementEntities();

        private IQueryable<ProductDTO> MapProducts()
        {
            return from p in db.PRODUCTs
                   select new ProductDTO()
                   { ID = p.ID, NAME = p.NAME, BRAND = p.BRAND, HEIGHT=p.HEIGHT, WEIGHT=p.WEIGHT };
        }
        // GET: api/Admin
        //[ResponseType(typeof(IEnumerable<PRODUCT>))]
        //[Route("api/GetProducts")]
        ////public IQueryable<PRODUCT> GetPRODUCTs()
        ////{
        ////    return db.PRODUCTs;
        ////}
        //public IEnumerable<ProductDTO> GetProducts()
        //{
        //    return MapProducts().AsEnumerable();
        //}

        //public ProductDTO GetProduct(int id)
        //{
        //    var product = (from p in MapProducts()
        //                   where p.ID == 1
        //                   select p).FirstOrDefault();
        //    if (product == null)
        //    {
        //        throw new HttpResponseException(
        //            Request.CreateResponse(HttpStatusCode.NotFound));
        //    }
        //    return product;
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTExists(int id)
        {
            return db.PRODUCTs.Count(e => e.ID == id) > 0;
        }
    }
}
