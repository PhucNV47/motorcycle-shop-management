using MotorcycleShop.BUS;
using MotorcycleShop.DTO;
using Microsoft.AspNetCore.Mvc;
namespace MotorcycleShop.API.Controllers

{
    public class Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class  XeController : ControllerBase
        {
            private readonly XeBUS _bus = new XeBUS();

            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(_bus.LayDanhSachXe());
            }

            [HttpPost]
            public IActionResult Create(XeDTO xe)
            {
                if (_bus.ThemXe(xe))
                    return Ok("Thêm xe thành công");

                return BadRequest("Dữ liệu không hợp lệ");
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, XeDTO xe)
            {
                xe.MaXe = id;
                if (_bus.SuaXe(xe))
                    return Ok("Cập nhật thành công");

                return NotFound();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                if (_bus.XoaXe(id))
                    return Ok("Xóa thành công");

                return NotFound();
            }
        }
    }
}
