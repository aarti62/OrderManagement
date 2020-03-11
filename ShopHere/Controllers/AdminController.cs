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

namespace ShopHere.Controllers
{
    public class AdminController : ApiController
    {
        private OrderManagementEntities db = new OrderManagementEntities();

        // GET: api/Admin
        [ResponseType(typeof(IEnumerable<PRODUCT>))]
        [Route("api/GetProducts")]
        public IQueryable<PRODUCT> GetPRODUCTs()
        {
            return db.PRODUCTs;
        }

        // GET: api/Admin/5
        [ResponseType(typeof(PRODUCT))]
        [HttpGet]
        [Route("api/GetProduct/{id}")]
        public IHttpActionResult GetPRODUCT(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            return Ok(pRODUCT);
        }

        // PUT: api/Admin/5
        [ResponseType(typeof(void))]
        [Route("api/PutProduct")]
        public IHttpActionResult PutPRODUCT(int id, PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCT.ID)
            {
                return BadRequest();
            }

            db.Entry(pRODUCT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTExists(id))
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

        // POST: api/Admin
        [ResponseType(typeof(PRODUCT))]
        [Route("api/PostProduct")]
        public HttpResponseMessage PostPRODUCT(PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.PRODUCTs.Add(pRODUCT);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = pRODUCT.ID }, pRODUCT);
            var response = Request.CreateResponse(HttpStatusCode.Created);

            // Generate a link to the new book and set the Location header in the response.
            //string uri = Url.Link("DefaultApi", new { id = pRODUCT.ID });
            //response.Headers.Location = new Uri(uri);
            return Request.CreateResponse(response.StatusCode);
        }

        // DELETE: api/Admin/5
        [ResponseType(typeof(PRODUCT))]
        [HttpDelete]
        [Route("api/DeleteProduct/{id}")]
        public IHttpActionResult DeletePRODUCT(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            db.PRODUCTs.Remove(pRODUCT);
            db.SaveChanges();

            return Ok(pRODUCT);
        }

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