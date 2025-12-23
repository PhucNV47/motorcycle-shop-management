using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleShop.DAL;
using MotorcycleShop.DTO;
namespace MotorcycleShop.BUS
{
    public class XeBUS
    {
        private readonly XeDAL dal = new XeDAL();
        
        public DataTable LayDanhSachXe()
        {
            return dal.GetAll();
        }

        public bool ThemXe(XeDTO xe)
        {
            // Validate nghiệp vụ
            if (xe == null) return false;

            if (string.IsNullOrWhiteSpace(xe.TenXe))
                return false;

            if (xe.Gia <= 0)
                return false;

            if (xe.SoLuong < 0)
                return false;

            // DAL trả int → BUS trả bool
            return dal.Insert(xe) > 0;
        }

        public bool XoaXe(int maXe)
        {
            if (maXe <= 0)
                return false;

            return dal.Delete(maXe) > 0;
        }
        public bool SuaXe(XeDTO xe)
        {
            if (xe == null) 
                return false;

            if (xe.MaXe <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(xe.TenXe))
                return false;

            if (xe.Gia <= 0 || xe.SoLuong < 0)
                return false;

            return dal.Update(xe) > 0;
        }
    }
}
