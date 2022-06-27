using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Blogcongnghe.Areas.Admin.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }
        public StoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public thanhvien Layquantrivien()
        {
            thanhvien tv = new thanhvien();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from thanhvien where TINHTRANGDN=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tv.MATV = Convert.ToInt32(reader["MATV"]);
                        tv.TENTHANHVIEN = reader["TENTHANHVIEN"].ToString();
                        tv.EMAIL = reader["EMAIL"].ToString();
                        tv.MATKHAU = reader["MATKHAU"].ToString();
                        tv.ANHDD = reader["ANHDD"].ToString();
                        tv.SDT = reader["SDT"].ToString();
                        tv.BIO = reader["BIO"].ToString();
                        tv.DIACHI = reader["DIACHI"].ToString();
                        tv.TWITTER = reader["TWITTER"].ToString();
                        tv.FACEBOOK = reader["FACEBOOK"].ToString();
                        tv.INSTAGRAM = reader["INSTAGRAM"].ToString();
                        tv.LINKEDIN = reader["LINKEDIN"].ToString();
                        tv.NGAYSINH = (DateTime)reader["NGAYSINH"];
                        tv.TINHTRANGDN = Convert.ToInt32(reader["TINHTRANGDN"]);
                        tv.QUYENDN = Convert.ToInt32(reader["QUYENDN"]);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return tv;
        }
        public int LaysoluongBinhluan()
        {
            int soluong = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select count(*) AS SOLUONG from binhluan";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        soluong = Convert.ToInt32(reader["SOLUONG"]);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return soluong;
        }
        public int LaysoluongThanhvien()
        {
            int soluong = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select count(*) AS SOLUONG from thanhvien";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        soluong = Convert.ToInt32(reader["SOLUONG"]);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return soluong;
        }
        public int LaysoluongBaiviet()
        {
            int soluong = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select count(*) AS SOLUONG from baiviet";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        soluong = Convert.ToInt32(reader["SOLUONG"]);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return soluong;
        }
        public List<object> Lay5ThanhviennhieuBaiviet()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select tv.MATV, tv.ANHDD, tv.TENTHANHVIEN, tv.EMAIL, tv.SDT, COUNT(*) AS SOLUONG from thanhvien tv, baiviet po where tv.MATV=po.MATV GROUP BY tv.ANHDD, tv.TENTHANHVIEN, tv.EMAIL, tv.SDT LIMIT 5";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            MATV = Convert.ToInt32(reader["MATV"]),
                            ANHDD = reader["ANHDD"].ToString(),
                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),
                            EMAIL = reader["EMAIL"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            SOLUONG = Convert.ToInt32(reader["SOLUONG"]),
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<baiviet> Lay5BaivietnhieuLuotthich()
        {
            List<baiviet> list = new List<baiviet>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from baiviet where MADUYET=2 ORDER BY SOLUOTTHICH DESC LIMIT 5";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new baiviet()
                        {
                            MABAIDANG = Convert.ToInt32(reader["MABAIDANG"]),
                            ANH1 = reader["ANH1"].ToString(),
                            TIEUDE = reader["TIEUDE"].ToString(),
                            SOLUONGBINHLUAN = Convert.ToInt32(reader["SOLUONGBINHLUAN"]),
                            SOLUOTTHICH = Convert.ToInt32(reader["SOLUOTTHICH"]),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> Laybaivietdachapnhan()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT tv.MATV, MABAIDANG, TIEUDE, TENTHANHVIEN, NGAYDANG, TENDUYET FROM baiviet bv, duyet, thanhvien tv WHERE bv.MADUYET=duyet.MADUYET AND tv.MATV=bv.MATV AND duyet.MADUYET=2";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            MATV = Convert.ToInt32(reader["MATV"]),
                            MABAIDANG = Convert.ToInt32(reader["MABAIDANG"]),
                            TIEUDE = reader["TIEUDE"].ToString(),
                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),
                            NGAYDANG = (DateTime)reader["NGAYDANG"],
                            TENDUYET = reader["TENDUYET"].ToString(),
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> Laybaivietdangduyet()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT tv.MATV, MABAIDANG, TIEUDE, TENTHANHVIEN, NGAYDANG, TENDUYET FROM baiviet bv, duyet, thanhvien tv WHERE bv.MADUYET=duyet.MADUYET AND tv.MATV=bv.MATV AND duyet.MADUYET=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            MATV = Convert.ToInt32(reader["MATV"]),
                            MABAIDANG = Convert.ToInt32(reader["MABAIDANG"]),
                            TIEUDE = reader["TIEUDE"].ToString(),
                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),
                            NGAYDANG = (DateTime)reader["NGAYDANG"],
                            TENDUYET = reader["TENDUYET"].ToString(),
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> Laybaiviettuchoi()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT tv.MATV, MABAIDANG, TIEUDE, TENTHANHVIEN, NGAYDANG, TENDUYET FROM baiviet bv, duyet, thanhvien tv WHERE bv.MADUYET=duyet.MADUYET AND tv.MATV=bv.MATV AND duyet.MADUYET=3";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            MATV = Convert.ToInt32(reader["MATV"]),
                            MABAIDANG = Convert.ToInt32(reader["MABAIDANG"]),
                            TIEUDE = reader["TIEUDE"].ToString(),
                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),
                            NGAYDANG = (DateTime)reader["NGAYDANG"],
                            TENDUYET = reader["TENDUYET"].ToString(),
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public baiviet Laybaiviet1 { get; set; }
        public baiviet Laybaiviet(int MABAIDANG)
        {
            baiviet bv = new baiviet();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from baiviet where MABAIDANG=@mabaidang";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bv.MABAIDANG = Convert.ToInt32(reader["MABAIDANG"]);
                        bv.MATL = Convert.ToInt32(reader["MATL"]);
                        bv.MATV = Convert.ToInt32(reader["MATV"]);
                        bv.TIEUDE = reader["TIEUDE"].ToString();
                        bv.NOIDUNG = reader["NOIDUNG"].ToString();
                        bv.ANH1 = reader["ANH1"].ToString();
                        bv.ANH2 = reader["ANH2"].ToString();
                        bv.ANH3 = reader["ANH3"].ToString();
                        bv.SOLUOTTHICH = Convert.ToInt32(reader["SOLUOTTHICH"]);
                        bv.SOLUONGBINHLUAN = Convert.ToInt32(reader["SOLUONGBINHLUAN"]);
                        bv.NGAYDANG = (DateTime)reader["NGAYDANG"];
                        bv.MADUYET = Convert.ToInt32(reader["MADUYET"]);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return bv;
        }
        public void Dangxuattaikhoan()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update thanhvien set TINHTRANGDN=0 where TINHTRANGDN=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void XoabaivietMABAIDANG(int MABAIDANG)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from baiviet where MABAIDANG=@mabaidang;";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void Chapnhan(int MABAIDANG)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string TIEUDE = "";
                string TENTHANHVIEN = "";
                string EMAIL = "";

                conn.Open();
                string str = "update baiviet set MADUYET=2 where MABAIDANG=@mabaidang";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                str = "select EMAIL, TENTHANHVIEN, TIEUDE from baiviet bv, thanhvien tv where bv.MATV=tv.MATV AND MABAIDANG=@mabaidang";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TIEUDE = reader["TIEUDE"].ToString();
                        TENTHANHVIEN = reader["TENTHANHVIEN"].ToString();
                        EMAIL = reader["EMAIL"].ToString();
                    }
                    reader.Close();
                }
                conn.Close();

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("lengoctuan2406@gmail.com");
                    mail.To.Add(EMAIL);
                    mail.Subject = "Chấp nhận bài viết";
                    mail.Body = "<h1>Thân chào " + TENTHANHVIEN + "</h1>"
                        + "<h2>Tiêu đề bài viết đã được chấp nhận của bạn: " + TIEUDE + "</h2>"
                        + "<h2>Cảm ơn bạn đã đóng góp kiến cùng phát triển website!</h2>";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("lengoctuan2406@gmail.com", "748159263(Tuan)");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                return;
            }
        }
        public void Xulyguigmail(string TIN, string EMAIL)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("lengoctuan2406@gmail.com");
                    mail.To.Add(EMAIL);
                    mail.Subject = "Phản hồi tin nhắn";
                    mail.Body = "<h2>" + TIN + "</h2>";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("lengoctuan2406@gmail.com", "748159263(Tuan)");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                conn.Open();
                string str = "update thanhvien set TINNHAN=null where EMAIL=@email";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", EMAIL);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void Tuchoi(int MABAIDANG)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string TIEUDE = "";
                string TENTHANHVIEN = "";
                string EMAIL = "";

                conn.Open();
                var str = "update baiviet set MADUYET=3 where MABAIDANG=@mabaidang";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                str = "select EMAIL, TENTHANHVIEN, TIEUDE from baiviet bv, thanhvien tv where bv.MATV=tv.MATV AND MABAIDANG=@mabaidang";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TIEUDE = reader["TIEUDE"].ToString();
                        TENTHANHVIEN = reader["TENTHANHVIEN"].ToString();
                        EMAIL = reader["EMAIL"].ToString();
                    }
                    reader.Close();
                }
                conn.Close();

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("lengoctuan2406@gmail.com");
                    mail.To.Add(EMAIL);
                    mail.Subject = "Chấp nhận bài viết";
                    mail.Body = "<h1>Thân chào " + TENTHANHVIEN + "</h1>"
                        + "<h2>Tiêu đề bài viết đã bị từ chối của bạn: " + TIEUDE + "</h2>"
                        + "<h2>Hãy hoàn thiện nó hơn nhé, cảm ơn bạn!</h2>";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("lengoctuan2406@gmail.com", "748159263(Tuan)");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                return;
            }
        }
        public List<object> Laybinhluandangduyet()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT tv.MATV, bl.MABL, tv.TENTHANHVIEN, bl.NOIDUNG, bl.NGAYBINHLUAN FROM binhluan bl, thanhvien tv WHERE tv.MATV=bl.MATV AND bl.MADUYET=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            MATV = Convert.ToInt32(reader["MATV"]),
                            MABL = Convert.ToInt32(reader["MABL"]),
                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),
                            NOIDUNG = reader["NOIDUNG"].ToString(),
                            NGAYBINHLUAN = (DateTime)reader["NGAYBINHLUAN"],
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> Laybinhluandaduyet()
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT tv.MATV, bl.MABL, tv.TENTHANHVIEN, bl.NOIDUNG, bl.NGAYBINHLUAN FROM binhluan bl, thanhvien tv WHERE tv.MATV=bl.MATV AND bl.MADUYET=2";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            MATV = Convert.ToInt32(reader["MATV"]),
                            MABL = Convert.ToInt32(reader["MABL"]),
                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),
                            NOIDUNG = reader["NOIDUNG"].ToString(),
                            NGAYBINHLUAN = (DateTime)reader["NGAYBINHLUAN"],
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public void XoaBinhluanMABL(int MABL)
        {
            using (MySqlConnection conn = GetConnection())
            {
                int MABAIDANG = -1;
                conn.Open();
                string str = "select MABAIDANG from binhluan where MABL=@mabl";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabl", MABL);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MABAIDANG = Convert.ToInt32(reader["MABAIDANG"]);
                    }
                    reader.Close();
                }
                conn.Close();

                conn.Open();
                str = "update baiviet set SOLUONGBINHLUAN=SOLUONGBINHLUAN-1 where MABAIDANG=@mabaidang";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                str = "delete from binhluan where MABL=@mabl;";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabl", MABL);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void ChapnhanBinhluanMABL(int MABL)
        {
            using (MySqlConnection conn = GetConnection())
            {
                int MABAIDANG = -1;
                conn.Open();
                var str = "update binhluan set MADUYET=2 where MABL=@mabl";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabl", MABL);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                str = "select MABAIDANG from binhluan where MABL=@mabl";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabl", MABL);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MABAIDANG = Convert.ToInt32(reader["MABAIDANG"]);
                    }
                    reader.Close();
                }
                conn.Close();

                conn.Open();
                str = "update baiviet set SOLUONGBINHLUAN=SOLUONGBINHLUAN+1 where MABAIDANG=@mabaidang";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public duyet Layxulybinhluan()
        {
            duyet duyet = new duyet();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from duyet where MADUYET=0";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        duyet.MADUYET = Convert.ToInt32(reader["MADUYET"]);
                        duyet.TENDUYET = reader["TENDUYET"].ToString();
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return duyet;
        }
        public void Duyet(duyet duyet)
        {
            string[] arrListStr = duyet.TENDUYET.Split('-');
            MySqlConnection conn = GetConnection();
            conn.Open();
            string str = "update duyet set TENDUYET=@tenduyet where MADUYET=@maduyet";
            MySqlCommand cmd = new MySqlCommand(str, conn);
            cmd.Parameters.AddWithValue("tenduyet", duyet.TENDUYET);
            cmd.Parameters.AddWithValue("maduyet", duyet.MADUYET);
            cmd.ExecuteNonQuery();
            conn.Close();
            for (int i = 0; i < arrListStr.Length; i++)
            {
                conn.Open();
                str = "delete from binhluan where NOIDUNG LIKE '%" + arrListStr[i] + "%'";
                cmd = new MySqlCommand(str, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return;
        }
        public List<thanhvien> Laytatcathanhvien()
        {
            List<thanhvien> list = new List<thanhvien>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from thanhvien where QUYENDN=0";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new thanhvien()
                        {
                            MATV = Convert.ToInt32(reader["MATV"]),
                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),
                            EMAIL = reader["EMAIL"].ToString(),
                            MATKHAU = reader["MATKHAU"].ToString(),
                            ANHDD = reader["ANHDD"].ToString(),
                            SDT = reader["SDT"].ToString(),
                            BIO = reader["BIO"].ToString(),
                            DIACHI = reader["DIACHI"].ToString(),
                            TWITTER = reader["TWITTER"].ToString(),
                            FACEBOOK = reader["FACEBOOK"].ToString(),
                            INSTAGRAM = reader["INSTAGRAM"].ToString(),
                            LINKEDIN = reader["LINKEDIN"].ToString(),
                            TINNHAN = reader["TINNHAN"].ToString(),
                            NGAYSINH = (DateTime)reader["NGAYSINH"],
                            TINHTRANGDN = Convert.ToInt32(reader["TINHTRANGDN"]),
                            QUYENDN = Convert.ToInt32(reader["QUYENDN"]),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public thanhvien LaythanhvienMATV1 { get; set; }
        public thanhvien LaythanhvienMATV(int MATV)
        {
            thanhvien tv = new thanhvien();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from thanhvien where MATV=@matv";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matv", MATV);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tv.MATV = Convert.ToInt32(reader["MATV"]);
                        tv.TENTHANHVIEN = reader["TENTHANHVIEN"].ToString();
                        tv.EMAIL = reader["EMAIL"].ToString();
                        tv.MATKHAU = reader["MATKHAU"].ToString();
                        tv.ANHDD = reader["ANHDD"].ToString();
                        tv.SDT = reader["SDT"].ToString();
                        tv.BIO = reader["BIO"].ToString();
                        tv.DIACHI = reader["DIACHI"].ToString();
                        tv.TWITTER = reader["TWITTER"].ToString();
                        tv.FACEBOOK = reader["FACEBOOK"].ToString();
                        tv.INSTAGRAM = reader["INSTAGRAM"].ToString();
                        tv.LINKEDIN = reader["LINKEDIN"].ToString();
                        tv.NGAYSINH = (DateTime)reader["NGAYSINH"];
                        tv.TINHTRANGDN = Convert.ToInt32(reader["TINHTRANGDN"]);
                        tv.QUYENDN = Convert.ToInt32(reader["QUYENDN"]);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return tv;
        }
        public List<baiviet> LaybaivietMATV1 { get; set; }
        public List<baiviet> LaybaivietMATV(int MATV)
        {
            List<baiviet> list = new List<baiviet>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from baiviet where MATV=@matv AND MADUYET=2";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matv", MATV);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new baiviet()
                        {
                            MABAIDANG = Convert.ToInt32(reader["MABAIDANG"]),
                            MATL = Convert.ToInt32(reader["MATL"]),
                            MATV = Convert.ToInt32(reader["MATV"]),
                            TIEUDE = reader["TIEUDE"].ToString(),
                            NOIDUNG = reader["NOIDUNG"].ToString(),
                            ANH1 = reader["ANH1"].ToString(),
                            ANH2 = reader["ANH2"].ToString(),
                            ANH3 = reader["ANH3"].ToString(),
                            SOLUOTTHICH = Convert.ToInt32(reader["SOLUOTTHICH"]),
                            SOLUONGBINHLUAN = Convert.ToInt32(reader["SOLUONGBINHLUAN"]),
                            NGAYDANG = (DateTime)reader["NGAYDANG"],
                            MADUYET = Convert.ToInt32(reader["MADUYET"]),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public void XulycapnhapThongtin(thanhvien tv)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update thanhvien set TENTHANHVIEN=@tenthanhvien, SDT=@sdt, BIO=@bio, ANHDD=@anhdd, " +
                    "DIACHI=@diachi, TWITTER=@twitter, FACEBOOK=@facebook, INSTAGRAM=@instagram, LINKEDIN=@linkedin, NGAYSINH=@ngaysinh where TINHTRANGDN=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tenthanhvien", tv.TENTHANHVIEN);
                cmd.Parameters.AddWithValue("sdt", tv.SDT);
                cmd.Parameters.AddWithValue("bio", tv.BIO);
                cmd.Parameters.AddWithValue("diachi", tv.DIACHI);
                cmd.Parameters.AddWithValue("twitter", tv.TWITTER);
                cmd.Parameters.AddWithValue("facebook", tv.FACEBOOK);
                cmd.Parameters.AddWithValue("instagram", tv.INSTAGRAM);
                cmd.Parameters.AddWithValue("linkedin", tv.LINKEDIN);
                cmd.Parameters.AddWithValue("ngaysinh", tv.NGAYSINH);
                cmd.Parameters.AddWithValue("anhdd", tv.ANHDD);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void XulymkThongtin(string mkcu, string mkmoi)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update thanhvien set MATKHAU=@matkhaumoi where MATKHAU=@matkhaucu and TINHTRANGDN=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matkhaumoi", mkmoi);
                cmd.Parameters.AddWithValue("matkhaucu", mkcu);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public List<theloai> Laytheloai()
        {
            List<theloai> list = new List<theloai>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from theloai";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new theloai()
                        {
                            MATL = Convert.ToInt32(reader["MATL"]),
                            TENTL = reader["TENTL"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public void TaoBaiviet(baiviet bv)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into baiviet (MATL, MATV, TIEUDE, NOIDUNG, ANH1, ANH2, ANH3, SOLUOTTHICH, SOLUONGBINHLUAN, NGAYDANG, MADUYET) " +
                    "values(@matl, @matv, @tieude, @noidung, @anh1, @anh2, @anh3, @soluotthich, @soluongbinhluan, @ngaydang, @maduyet)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matl", bv.MATL);
                cmd.Parameters.AddWithValue("matv", bv.MATV);
                cmd.Parameters.AddWithValue("tieude", bv.TIEUDE);
                cmd.Parameters.AddWithValue("noidung", bv.NOIDUNG);
                cmd.Parameters.AddWithValue("anh1", bv.ANH1);
                cmd.Parameters.AddWithValue("anh2", bv.ANH2);
                cmd.Parameters.AddWithValue("anh3", bv.ANH3);
                cmd.Parameters.AddWithValue("soluotthich", 0);
                cmd.Parameters.AddWithValue("soluongbinhluan", 0);
                cmd.Parameters.AddWithValue("ngaydang", DateTime.Now);
                cmd.Parameters.AddWithValue("maduyet", 2);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void Themtheloaibaiviet(theloai tl)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into theloai (TENTL) values(@tentheloai)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tentheloai", tl.TENTL);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
    }
}
