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
        private static readonly Dictionary<string, List<byte[]>> _fileSignature = new Dictionary<string, List<byte[]>>
        {
            { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
            { ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            { ".jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                }
            },

        };

        //xử lí check xem file hop le hay khong
        public static Task<bool> CheckHexImage(dynamic file)
        {
            // Đọc byte từ file
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                var fileSignature = stream.ToArray();

                // Check if the file signature matches any known signature
                var fileExtension = Path.GetExtension(file.FileName);
                _fileSignature.TryGetValue(fileExtension, out List<byte[]> validSignatures);
                if (validSignatures != null)
                {

                    return Task.FromResult(true); // File extension not supported.

                }

                return Task.FromResult(false); // File extension not supported.
            }

        }


    }
}
