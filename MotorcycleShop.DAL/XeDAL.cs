using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MotorcycleShop.DAL.XeDAL;
using MotorcycleShop.DTO;
namespace MotorcycleShop.DAL
{
    public class XeDAL
    {

        // Lấy danh sách tất cả xe
        public DataTable GetAll()
        {
            string sql = "SELECT MaXe, TenXe, Gia, SoLuong FROM Xe";
            return Database.ExecuteQuery(sql);
        }

        // Lấy xe theo mã
        public DataTable GetById(int maXe)
        {
            string sql = "SELECT MaXe, TenXe, Gia, SoLuong FROM Xe WHERE MaXe = @MaXe";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaXe", maXe)
            };

            return Database.ExecuteQuery(sql, parameters);
        }

        // Thêm xe
        public int Insert(XeDTO xe)
        {
            string sql = @"
                INSERT INTO Xe (TenXe, Gia, SoLuong)
                VALUES (@TenXe, @Gia, @SoLuong)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TenXe", xe.TenXe),
                new SqlParameter("@Gia", xe.Gia),
                new SqlParameter("@SoLuong", xe.SoLuong)
            };

            return Database.ExecuteNonQuery(sql, parameters);
        }

        // Cập nhật xe
        public int Update(XeDTO xe)
        {
            string sql = @"
                UPDATE Xe
                SET TenXe = @TenXe,
                    Gia = @Gia,
                    SoLuong = @SoLuong
                WHERE MaXe = @MaXe";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaXe", xe.MaXe),
                new SqlParameter("@TenXe", xe.TenXe),
                new SqlParameter("@Gia", xe.Gia),
                new SqlParameter("@SoLuong", xe.SoLuong)
            };

            return Database.ExecuteNonQuery(sql, parameters);
        }

        // Xóa xe
        public int Delete(int maXe)
        {
            string sql = "DELETE FROM Xe WHERE MaXe = @MaXe";

            SqlParameter[] parameters =
            {
                new SqlParameter("@MaXe", maXe)
            };

            return Database.ExecuteNonQuery(sql, parameters);
        }
    }

}

