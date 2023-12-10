using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.Models;
using WebAPI_project_banhang.Modules.M_Sieu_Thi.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace WebAPI_project_banhang.Modules.M_Sieu_Thi.Repositories
{
    public class SieuThiRepositories : ISieuThiRepositories
    {
        private readonly SieuThiContext _context;
        private string _connectionString;

        public SieuThiRepositories(IConfiguration configuration, SieuThiContext context)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<GetSieuThiListViewModel> getSieuThiListRepo(FilterSieuThiViewModel filterSieuThiViewModel)
        {
            string fromDate = filterSieuThiViewModel?.RageDate?.fromDate.ToString() ?? "";
            string toDate = filterSieuThiViewModel?.RageDate?.toDate.ToString() ?? "";

            GetSieuThiListViewModel getSieuThiListViewModel = new GetSieuThiListViewModel();

            var countRecordTask = CountRecordSieuThiAsync(filterSieuThiViewModel, fromDate, toDate);
            var filterSieuThiTask = FilterSieuThiAsync(filterSieuThiViewModel, fromDate, toDate);

            // Sử dụng Task.WhenAll để thực hiện đồng thời cả lệnh gọi ADO.NET và Entity Framework
            await Task.WhenAll(countRecordTask, filterSieuThiTask);

            getSieuThiListViewModel.TotalCount = countRecordTask.Result;
      
            getSieuThiListViewModel.sieuThi = filterSieuThiTask.Result;   

            return getSieuThiListViewModel;
        }

        //xử lí lấy danh sách siêu thị theo bộ lọc
        private async Task<List<SieuThi>> FilterSieuThiAsync(FilterSieuThiViewModel filterSieuThiViewModel, string fromDate, string toDate)
        {

            string sql = "EXECUTE dbo.FilterSieuThi @keyword, @page, @limit, @fromDate, @toDate, @tinhst, @huyenst, @xast ";
            int limit = filterSieuThiViewModel?.pageSize ?? 10;
            int page = filterSieuThiViewModel?.page - 1 ?? 0;
            int index = page * limit;

            return await _context.SieuThi.FromSqlRaw(sql,
                    new SqlParameter("@keyword", filterSieuThiViewModel?.keyword ?? ""),
                    new SqlParameter("@page", index),
                    new SqlParameter("@limit", limit),
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate),
                    new SqlParameter("@tinhst", filterSieuThiViewModel.tinhst ?? ""),
                    new SqlParameter("@huyenst", filterSieuThiViewModel.huyenst ?? ""),
                    new SqlParameter("@xast", filterSieuThiViewModel.xast ?? "")

                ).ToListAsync();
        }

        //xử lí đếm bản ghi của siêu thị theo bộ lọc
        private async Task<int> CountRecordSieuThiAsync(FilterSieuThiViewModel filterSieuThiViewModel, string fromDate, string toDate)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("EXECUTE dbo.CountRecordSieuThi @keyword, @tinhst, @huyenst, @xast, @fromDate, @toDate", con);
                cmd.CommandType = CommandType.Text;

                //truyền params
                cmd.Parameters.AddWithValue("@keyword", filterSieuThiViewModel?.keyword ?? "");
                cmd.Parameters.AddWithValue("@tinhst", filterSieuThiViewModel?.tinhst ?? "");
                cmd.Parameters.AddWithValue("@huyenst", filterSieuThiViewModel?.huyenst ?? "");
                cmd.Parameters.AddWithValue("@xast", filterSieuThiViewModel?.xast ?? "");
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
