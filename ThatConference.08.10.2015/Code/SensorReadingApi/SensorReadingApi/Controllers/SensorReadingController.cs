using SensorReadingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SensorReadingApi.Controllers
{
    public class SensorReadingController : ApiController
    {
        public static List<SensorReading> Readings = new List<SensorReading>
            {
                new SensorReading { SensorName = "Default Sensor", SensorValue = "Hello, Sensors!" }
            };

        //public SensorReadingController()
        //{
        //    readings = new List<SensorReading>();
        //}

        // GET: api/SensorReading
        public IHttpActionResult Get()
        {
            return Ok(Readings);
        }

        // GET: api/SensorReading/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/SensorReading
        public void Post([FromBody]SensorReading reading)
        {
            Readings.Add(reading);
        }

        // PUT: api/SensorReading/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/SensorReading/5
        //public void Delete(int id)
        //{
        //}
    }
}
