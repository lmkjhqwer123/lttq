using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace qlythuvien
{
    internal class Chuoiketnoi
    {
        private static string connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                try
                {
                    // Đọc kết nối từ file connect.json
                    var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"C:\Users\Lenovo\source\repos\qlythuvien\qlythuvien\connect.json"));

                    if (config != null && config.ContainsKey("ConnectionString"))
                    {
                        connectionString = config["ConnectionString"];
                    }
                    else
                    {
                        throw new InvalidOperationException("Không tìm thấy key 'ConnectionString' trong tệp connect.json");
                    }
                }
                catch (FileNotFoundException ex)
                {
                    
                    Console.WriteLine("Lỗi: Không tìm thấy tệp connect.json");
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (JsonException ex)
                {
                   
                    Console.WriteLine("Lỗi đọc tệp JSON: " + ex.Message);
                    throw;
                }
                catch (InvalidOperationException ex)
                {
               
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Chuỗi kết nối chưa được khởi tạo.");
            }

            return connectionString;
        }
    }
}
