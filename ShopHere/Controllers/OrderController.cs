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
    public class OrderController : ApiController
    {
        private OrderManagementEntities db = new OrderManagementEntities();

        // GET: api/Order
        [Route("api/GetOrderDetails")]
        public IQueryable<ORDER_DETAILS> GetORDER_DETAILS()
        {
            return db.ORDER_DETAILS.Where(o => o.USERID == o.USER_RECORD.ID);
            // return db.ORDER_DETAILS;
        }

        // GET: api/Order/5
        [Route("api/GetOrderDetail/{id}")]
        [ResponseType(typeof(ORDER_DETAILS))]
        public OrderDTO GetORDER_DETAILS(int id)
        {
            ORDER_DETAILS oRDER_DETAILS = db.ORDER_DETAILS.Include("ORDER_DETAILS.")
        .First(o => o.ID == id && o.USERID == o.USER_RECORD.ID);
            if (oRDER_DETAILS == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new OrderDTO()
            {
                Details = from d in oRDER_DETAILS.ORDER_ITEM
                          select new OrderDTO.Detail()
                          {
                              ProductID = d.PRODUCT.ID,
                              ProductName = d.PRODUCT.NAME,
                              // Price = d.Product.Price,
                              Quantity = d.QUANTITY
                          }
            };
        }


        // PUT: api/Order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORDER_DETAILS(int id, ORDER_DETAILS oRDER_DETAILS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRDER_DETAILS.ID)
            {
                return BadRequest();
            }

            db.Entry(oRDER_DETAILS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDER_DETAILSExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Order
        [ResponseType(typeof(ORDER_DETAILS))]
        [Route("api/PostOrder")]
        public IHttpActionResult PostORDER_DETAILS(ORDER_DETAILS oRDER_DETAILS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORDER_DETAILS.Add(oRDER_DETAILS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = oRDER_DETAILS.ID }, oRDER_DETAILS);
        }

        // DELETE: api/Order/5
        [ResponseType(typeof(ORDER_DETAILS))]
        public IHttpActionResult DeleteORDER_DETAILS(int id)
        {
            ORDER_DETAILS oRDER_DETAILS = db.ORDER_DETAILS.Find(id);
            if (oRDER_DETAILS == null)
            {
                return NotFound();
            }

            db.ORDER_DETAILS.Remove(oRDER_DETAILS);
            db.SaveChanges();

            return Ok(oRDER_DETAILS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORDER_DETAILSExists(int id)
        {
            return db.ORDER_DETAILS.Count(e => e.ID == id) > 0;
        }
    }
}