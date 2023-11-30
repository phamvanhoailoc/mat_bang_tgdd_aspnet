using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace WebAPI_project_banhang.Lib.Utils
{
    public class UploadFile
    {
        public static readonly string FileDirectory = "assets/file-upload"; // Thay đổi thành đường dẫn thư mục thực tế của bạn

        public static string GetFilePath(string fileName)
        {
            // Xây dựng đường dẫn đầy đủ đến tệp trong thư mục
            string filePath = Path.Combine(FileDirectory, fileName);

            // Kiểm tra xem tệp có tồn tại không
            if (!File.Exists(filePath))
            {
                // Nếu không tồn tại, ném một ngoại lệ (Exception)
                throw new Exception("File not found");
            }

            // Nếu tệp tồn tại, trả về đường dẫn đầy đủ đến tệp
            return filePath;
        }
        public static string ParseViewType(string mimetype)
        {
            // Not found
            if (string.IsNullOrEmpty(mimetype))
            {
                return null;
            }

            string[] arrViewTypes = { "image", "video", "audio", "pdf" };

            for (int i = 0; i < 4; i++)
            {
                if (mimetype.Contains(arrViewTypes[i]))
                {
                    return arrViewTypes[i];
                }
            }

            // Default
            return "file";
        }

        public static string UploadFileDirect(dynamic file)
        {
           
            //xử lí lưu file
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), UploadFile.FileDirectory);
            // Kiểm tra xem thư mục "assets/file-upload" đã tồn tại chưa
            if (!Directory.Exists(pathToSave))
            {
                // Nếu không tồn tại, tạo thư mục "assets/file-upload"
                Directory.CreateDirectory(pathToSave);
            }
            var date = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var fileName = Regex.Replace(file.FileName, @"\s", "");
            var newFileName = $"FILEUPLOAD_{Guid.NewGuid()}_{date}{fileName}";
            var fullPath = Path.Combine(pathToSave, newFileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // Default
            return newFileName;
        }
        public static Task<bool> DeleteFile(dynamic filePath)
        {
            try
            {
                //xử lí lưu file
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), UploadFile.FileDirectory);
                var fullPath = Path.Combine(pathToSave, filePath);
                // Sử dụng phương thức Delete của lớp File để xóa tệp
                if(!File.Exists(fullPath)) return Task.FromResult(false);

                File.Delete(fullPath);
   
                return Task.FromResult(true);
            }
            catch (IOException e)
            {
                return Task.FromResult(false);
            }
            catch (UnauthorizedAccessException e)
            {
                return Task.FromResult(false);
            }
        }


    }
}
