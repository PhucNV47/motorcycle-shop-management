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
        
            public DataTable GetAll()
            {
                var dt = new DataTable();
                using (var conn = Database.GetConnection())
                using (var da = new SqlDataAdapter("SELECT * FROM Xe", conn))
                {
                    // Open explicitly so connection-related exceptions point at conn.Open()
                    conn.Open();
                    da.Fill(dt);
                }

                return dt;
            }

            public bool Insert(XeDTO xe)
            {
                string sql = @"INSERT INTO Xe(TenXe, HangXe, Gia, SoLuong)
                           VALUES (@TenXe, @HangXe, @Gia, @SoLuong)";

                using (var conn = Database.GetConnection())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenXe", xe.TenXe);
                    cmd.Parameters.AddWithValue("@HangXe", xe.HangXe);
                    cmd.Parameters.AddWithValue("@Gia", xe.Gia);
                    cmd.Parameters.AddWithValue("@SoLuong", xe.SoLuong);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();

                    return result > 0;
                }
            }
            public bool Delete(int maXe)
        {
            string sql = @"DELETE FROM Xe WHERE MaXe =@MaXe";
            SqlConnection conn = Database.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaXe", maXe);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        } 
            public bool Update(XeDTO xe)
        {
            string sql = @"UPDATE Xe 
                   SET TenXe=@TenXe, HangXe=@HangXe, Gia=@Gia, SoLuong=@SoLuong
                   WHERE MaXe=@MaXe";

            SqlConnection conn = Database.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaXe", xe.MaXe);
            cmd.Parameters.AddWithValue("@TenXe", xe.TenXe);
            cmd.Parameters.AddWithValue("@HangXe", xe.HangXe);
            cmd.Parameters.AddWithValue("@Gia", xe.Gia);
            cmd.Parameters.AddWithValue("@SoLuong", xe.SoLuong);

            conn.Open() ;
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }
    }
}
