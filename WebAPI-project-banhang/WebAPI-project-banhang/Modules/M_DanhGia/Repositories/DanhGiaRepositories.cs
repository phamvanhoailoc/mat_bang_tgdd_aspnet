using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_DanhGia.Models;
using WebAPI_project_banhang.Modules.M_DanhGia.ViewModels;



namespace WebAPI_project_banhang.Modules.M_DanhGia.Repositories
{
    public class DanhGiaRepositories : IDanhGiaRepositories
    {
        private readonly DanhGiaContext _context;
        private string _connectionString;

        public DanhGiaRepositories(IConfiguration configuration, DanhGiaContext context)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //xử lí lấy danh sách siêu thị theo bộ lọc
        public async Task<List<DanhGia>> FilterDanhGiaAsync(FilterDanhGiaViewModel filterDanhGiaViewModel, string fromDate, string toDate)
        {

            string sql = "EXECUTE dbo.FilterDotDanhGia @keyword, @page, @limit, @fromDate, @toDate, @tinhst ";
            int limit = filterDanhGiaViewModel?.pageSize ?? 10;
            int page = filterDanhGiaViewModel?.page - 1 ?? 0;
            int index = page * limit;

            return await _context.DanhGia.FromSqlRaw(sql,
                    new SqlParameter("@keyword", filterDanhGiaViewModel?.keyword ?? ""),
                    new SqlParameter("@page", index),
                    new SqlParameter("@limit", limit),
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate),
                    new SqlParameter("@tinhst", filterDanhGiaViewModel.tinhst ?? "")

                ).ToListAsync();
        }

        //xử lí đếm bản ghi của siêu thị theo bộ lọc
        public async Task<int> CountRecordDanhGiaAsync(FilterDanhGiaViewModel filterDanhGiaViewModel, string fromDate, string toDate)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("EXECUTE dbo.CountRecordDanhGia @keyword, @tinhst, @fromDate, @toDate", con);
                cmd.CommandType = CommandType.Text;

                //truyền params
                cmd.Parameters.AddWithValue("@keyword", filterDanhGiaViewModel?.keyword ?? "");
                cmd.Parameters.AddWithValue("@tinhst", filterDanhGiaViewModel?.tinhst ?? "");
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);

                con.Open();
                object record = await cmd.ExecuteScalarAsync();

                con.Close();

                return record != null ? Convert.ToInt32(record) : 0;
            }
        }
  
    }
}
