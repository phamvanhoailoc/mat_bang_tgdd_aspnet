using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_MatBang.Models;
using WebAPI_project_banhang.Modules.M_MatBang.ViewModels;
using Microsoft.EntityFrameworkCore;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;

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

        public async Task<bool> CreateMatBang(CreateMatBangInputViewModel createMatBangInputViewModel)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                //mở connect db

                SqlCommand cmd = new SqlCommand("dbo.CreateMatBang", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@machiphi", createMatBangInputViewModel.MaChiPhi);
                cmd.Parameters.AddWithValue("@tenmb", createMatBangInputViewModel.TenMB);
                cmd.Parameters.AddWithValue("@dcmb", createMatBangInputViewModel.DcMB);
                cmd.Parameters.AddWithValue("@tinhmb", createMatBangInputViewModel.TinhMB);
                cmd.Parameters.AddWithValue("@huyenmb", createMatBangInputViewModel.HuyenMB);
                cmd.Parameters.AddWithValue("@xamb", createMatBangInputViewModel.XaMB);
                cmd.Parameters.AddWithValue("@dtmb", createMatBangInputViewModel.dientichMB);
                cmd.Parameters.AddWithValue("@ttmb", createMatBangInputViewModel.thetichMB);
                cmd.Parameters.AddWithValue("@phaplymb", createMatBangInputViewModel.phaplymb);
                cmd.Parameters.AddWithValue("@hethonggiaothongmb", createMatBangInputViewModel.hethonggiaothongmb);
                cmd.Parameters.AddWithValue("@pcccmb", createMatBangInputViewModel.pcccmb);
                cmd.Parameters.AddWithValue("@ngayCN", createMatBangInputViewModel.ngayCN);
                // Thêm tham số output
                SqlParameter successParam = new SqlParameter("@KetQua", SqlDbType.Bit);
                successParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(successParam);
                con.Open();

                //xử dụng nonquery khi không có kq return
                cmd.ExecuteNonQuery();

                bool success = Convert.ToBoolean(cmd.Parameters["@KetQua"].Value);

                //đóng connect db
                con.Close();
                return success;
            }
        }
    }
}