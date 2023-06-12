using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();
        
        [HttpGet]   
        
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet ("{id}")]

        public IActionResult GetByID(string id)
        {
            try
            {//LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }

            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost]

        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia,
        };
            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Succ = true, Data = hanghoa
            });
        }

        [HttpPut ("{id}")]

        public IActionResult Edit(string id, HangHoa hangHoaEidt)
        {
            try
            {//LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }

                if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                //Update
                hangHoa.TenHangHoa = hangHoaEidt.TenHangHoa;
                hangHoa.DonGia = hangHoaEidt.DonGia;

                return Ok();
            }

            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Remove(string id)
        {
            try
            {//LINQ [Object] Query
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound();
                }
                hangHoas.Remove(hangHoa);

                return Ok();
            }

            catch
            {
                return BadRequest();
            }
        }
    }
}
