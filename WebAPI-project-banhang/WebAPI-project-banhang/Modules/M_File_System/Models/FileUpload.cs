using System;

namespace WebAPI_project_banhang.Modules.M_File_System.Models
{
    public class FileUpload
    {
        public string user_create {  get; set; }
        public string file_group {  get; set; }
        public string file_type {  get; set; }
        public float file_size {  get; set; }
        public string server_filename {  get; set; }
        public string client_filename {  get; set; }
        public string filepath {  get; set; }
        public string file_ext {  get; set; }
        public string view_type {  get; set; }
        public DateTime time_create {  get; set; }
        public DateTime? time_update {  get; set; }
    }
}
