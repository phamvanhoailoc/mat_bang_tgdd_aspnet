using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_MatBang.Models;
using WebAPI_project_banhang.Modules.M_MatBang.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_project_banhang.Modules.M_MatBang.Repositories
{
    public class GetMatBangListRepositories : IGetMatBangListRepositories
    {
        private readonly MatBangContext _context;
        private string _connectionString;

        public GetMatBangListRepositories(IConfiguration configuration, MatBangContext context)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        //xử lí lấy danh sách siêu thị theo bộ lọc
        public async Task<List<MatBang>> FilterMatBangAsync(MatBangInputViewModel matBangInputViewModel, string fromDate, string toDate)
        {

            string sql = "EXECUTE dbo.FilterMatBang @keyword, @page, @limit, @fromDate, @toDate, @tinhmb, @huyenmb, @xamb ";
            int limit = matBangInputViewModel?.pageSize ?? 10;
            int page = matBangInputViewModel?.page - 1 ?? 0;
            int index = page * limit;

            return await _context.MatBangs.FromSqlRaw(sql,
                    new SqlParameter("@keyword", matBangInputViewModel?.keyword ?? ""),
                    new SqlParameter("@page", index),
                    new SqlParameter("@limit", limit),
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate),
                    new SqlParameter("@tinhmb", matBangInputViewModel.tinhst ?? ""),
                    new SqlParameter("@huyenmb", matBangInputViewModel.huyenst ?? ""),
                    new SqlParameter("@xamb", matBangInputViewModel.xast ?? "")

                ).ToListAsync();
        }

        //xử lí đếm bản ghi của siêu thị theo bộ lọc
        public async Task<int> CountRecordMatBangAsync(MatBangInputViewModel matBangInputViewModel, string fromDate, string toDate)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("EXECUTE dbo.CountRecordMatBang @keyword, @tinhmb, @huyenmb, @xamb, @fromDate, @toDate", con);
                cmd.CommandType = CommandType.Text;

                //truyền params
                cmd.Parameters.AddWithValue("@keyword", matBangInputViewModel?.keyword ?? "");
                cmd.Parameters.AddWithValue("@tinhmb", matBangInputViewModel?.tinhst ?? "");
                cmd.Parameters.AddWithValue("@huyenmb", matBangInputViewModel?.huyenst ?? "");
                cmd.Parameters.AddWithValue("@xamb", matBangInputViewModel?.xast ?? "");
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