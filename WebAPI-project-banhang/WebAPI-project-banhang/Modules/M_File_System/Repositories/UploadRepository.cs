using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_File_System.Models;

namespace WebAPI_project_banhang.Modules.M_File_System.Repositories
{
    public class UploadRepository : IUploadRepository
    {
        private string _connectionString;
        public UploadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Create(List<FileUpload> fileUpload)
        {
            //Sử dụng ADO gọi procedure 
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                //mở connect db
                con.Open();

                foreach (var file in fileUpload)
                {
                    SqlCommand cmd = new SqlCommand("EXECUTE dbo.InsertFileUpload  " +
                        "@file_type," +
                        "@client_filename, " +
                        "@server_filename, " +
                        "@file_group, " +
                        "@file_path, " +
                        "@file_ext, " +
                        "@view_type, " +
                        "@file_size, " +
                        "@user_create, " +
                        "@time_create", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@file_type", file?.file_type ?? "");
                    cmd.Parameters.AddWithValue("@client_filename", file?.client_filename ?? "");
                    cmd.Parameters.AddWithValue("@server_filename", file?.server_filename ?? "");
                    cmd.Parameters.AddWithValue("@file_group", file?.file_group ?? "");
                    cmd.Parameters.AddWithValue("@file_path", file?.filepath ?? "");
                    cmd.Parameters.AddWithValue("@file_ext", file?.file_ext ?? "");
                    cmd.Parameters.AddWithValue("@view_type", file?.view_type ?? "");
                    cmd.Parameters.AddWithValue("@file_size", file?.file_size ?? 0);
                    cmd.Parameters.AddWithValue("@user_create", file?.user_create ?? "");
                    cmd.Parameters.AddWithValue("@time_create", file?.time_create);

                    //xử dụng nonquery khi không có kq return
                    cmd.ExecuteNonQuery();
                }
                //đóng connect db
                con.Close();
            }

        }

        public async Task<bool> Delete(string idFile)
        {
            await using (SqlConnection con = new SqlConnection(_connectionString))
            {
                //mở connect db

                SqlCommand cmd = new SqlCommand("dbo.DeleteFile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@server_filename", idFile ?? "");
                // Thêm tham số output
                SqlParameter successParam = new SqlParameter("@success", SqlDbType.Bit);
                successParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(successParam);
                con.Open();

                //xử dụng nonquery khi không có kq return
                cmd.ExecuteNonQuery();

                bool success = Convert.ToBoolean(cmd.Parameters["@success"].Value);

                //đóng connect db
                con.Close();
                return success;
            }
        }
    }
}
