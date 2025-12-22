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
        XeDAL dal = new XeDAL();
        
        public DataTable LayDanhSachXe()
        {
            return dal.GetAll();
        }

        public bool ThemXe(XeDTO xe)
        {
            if(string.IsNullOrEmpty(xe.TenXe))
                return false;
            if(xe.Gia <= 0 || xe.SoLuong < 0 )
                return false;

            return dal.Insert(xe);
        }

        public bool XoaXe(int maXe)
        {
            if(maXe <=0) return false; 
            return dal.Delete(maXe);
        }
        public bool SuaXe(XeDTO xe)
        {
            if (xe.MaXe <= 0) return false;
            return dal.Update(xe);
        }
    }
}
