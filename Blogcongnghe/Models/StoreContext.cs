using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace Blogcongnghe.Models
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
        public int XulyDangnhapTK(string EMAIL, string MATKHAU)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update thanhvien set TINHTRANGDN = 1 where EMAIL=@email AND MATKHAU=@matkhau";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", EMAIL);
                cmd.Parameters.AddWithValue("matkhau", MATKHAU);
                return (cmd.ExecuteNonQuery());
            }
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
        public List<baiviet> LaydulieuBaiviet1 { get; set; }
        public List<baiviet> LaydulieuBaiviet(string CHUOI)
        {
            List<baiviet> list = new List<baiviet>();
            List<theloai> listtheloai = new List<theloai>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from theloai";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listtheloai.Add(new theloai()
                        {
                            MATL = Convert.ToInt32(reader["MATL"]),
                            TENTL = reader["TENTL"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
                if (CHUOI == "")
                {
                    for (int i = 0; i < listtheloai.Count; i++)
                    {
                        conn.Open();
                        str = "select * from baiviet where MADUYET=2 AND MATL="+ listtheloai[i].MATL + " LIMIT 6";
                        cmd = new MySqlCommand(str, conn);
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
                } else
                {
                    conn.Open();
                    str = "select * from baiviet where TIEUDE LIKE '%" + CHUOI + "%' and MADUYET=2";
                    cmd = new MySqlCommand(str, conn);
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
            }
            return list;
        }
        public List<baiviet> LaybaivietThanhvien()
        {
            int MATV = -1;
            List<baiviet> list = new List<baiviet>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select MATV from thanhvien where TINHTRANGDN=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MATV = Convert.ToInt32(reader["MATV"]);
                    }
                    reader.Close();
                }
                conn.Close();
                conn.Open();
                str = "select * from baiviet where MATV=@matv";
                cmd = new MySqlCommand(str, conn);
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
        public List<baiviet> LaydulieuBaivietTheloai1 { get; set; }
        public List<baiviet> LaydulieuBaivietTheloai(int MATL)
        {
            List<baiviet> list = new List<baiviet>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from baiviet where MATL=@matl AND MADUYET=2";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matl", MATL);
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
        public List<thanhvien> LaytatcaQuantrivien()
        {
            List<thanhvien> list = new List<thanhvien>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from thanhvien where QUYENDN=1";
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
                            NGAYSINH = (DateTime)reader["NGAYSINH"],
                            MAUNEN = reader["MAUNEN"].ToString(),
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
        public void CapnhatBaivietThanhvien(baiviet po)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update baiviet set TIEUDE=@tieude, NOIDUNG=@noidung, ANH1=@anh1, ANH2=@anh2, ANH3=@anh3, MADUYET=1 where MABAIDANG=@mabaidang";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tieude", po.TIEUDE);
                cmd.Parameters.AddWithValue("noidung", po.NOIDUNG);
                cmd.Parameters.AddWithValue("anh1", po.ANH1);
                cmd.Parameters.AddWithValue("anh2", po.ANH2);
                cmd.Parameters.AddWithValue("anh3", po.ANH3);
                cmd.Parameters.AddWithValue("mabaidang", po.MABAIDANG);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void XoaBaiviet(int MABAIDANG)
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
        public thanhvien Laythanhvien()
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
                        tv.MAUNEN = reader["MAUNEN"].ToString();
                        tv.TINHTRANGDN = Convert.ToInt32(reader["TINHTRANGDN"]);
                        tv.QUYENDN = Convert.ToInt32(reader["QUYENDN"]);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return tv;
        }
        public void XulyDangkiTK(string TENTHANHVIEN, string EMAIL, string MATKHAU)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "insert into thanhvien (TENTHANHVIEN, EMAIL, MATKHAU, ANHDD, TWITTER, FACEBOOK, INSTAGRAM, LINKEDIN, NGAYSINH, MAUNEN, TINHTRANGDN, QUYENDN) " +
                    "values(@tenthanhvien, @email, @matkhau, @anhdd, @twitter, @facebook, @instagram, @linkedin, @ngaysinh, @maunen, @tinhtrangdn, @quyendn)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tenthanhvien", TENTHANHVIEN);
                cmd.Parameters.AddWithValue("email", EMAIL);
                cmd.Parameters.AddWithValue("matkhau", MATKHAU);
                cmd.Parameters.AddWithValue("anhdd", "Anh_Trong.png");
                cmd.Parameters.AddWithValue("twitter", "https://twitter.com/#");
                cmd.Parameters.AddWithValue("facebook", "https://www.facebook.com/#");
                cmd.Parameters.AddWithValue("instagram", "https://www.instagram.com/#");
                cmd.Parameters.AddWithValue("linkedin", "https://www.linkedin.com/#");
                cmd.Parameters.AddWithValue("ngaysinh", DateTime.Now);
                cmd.Parameters.AddWithValue("maunen", "trang");
                cmd.Parameters.AddWithValue("tinhtrangdn", 0);
                cmd.Parameters.AddWithValue("quyendn", 0);
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
        public void GuitinDoanhnghiep(thanhvien tv)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "update thanhvien set TINNHAN=@tinnhan where TINHTRANGDN=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tinnhan", tv.TINNHAN);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void Doinen(string MAUNEN)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "update thanhvien set MAUNEN=@maunen where TINHTRANGDN=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("maunen", MAUNEN);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }

        public void GuitinDoanhnghiepKhac(thanhvien tv)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Close();
                Random TenBienRanDom = new Random();
                int MATKHAU = TenBienRanDom.Next(10000000, 99999999);
                conn.Open();
                string str = "insert into thanhvien (TENTHANHVIEN, EMAIL, MATKHAU, ANHDD, TWITTER, FACEBOOK, INSTAGRAM, LINKEDIN, TINNHAN, NGAYSINH, MAUNEN, TINHTRANGDN, QUYENDN) " +
                    "values(@tenthanhvien, @email, @matkhau, @anhdd, @twitter, @facebook, @instagram, @linkedin, @tinnhan, @ngaysinh, @maunen, @tinhtrangdn, @quyendn)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tenthanhvien", tv.TENTHANHVIEN);
                cmd.Parameters.AddWithValue("email", tv.EMAIL);
                cmd.Parameters.AddWithValue("matkhau", MATKHAU);
                cmd.Parameters.AddWithValue("anhdd", "Anh_Trong.png");
                cmd.Parameters.AddWithValue("twitter", "https://twitter.com/#");
                cmd.Parameters.AddWithValue("facebook", "https://www.facebook.com/#");
                cmd.Parameters.AddWithValue("instagram", "https://www.instagram.com/#");
                cmd.Parameters.AddWithValue("linkedin", "https://www.linkedin.com/#");
                cmd.Parameters.AddWithValue("tinnhan", tv.TINNHAN);
                cmd.Parameters.AddWithValue("ngaysinh", DateTime.Now);
                cmd.Parameters.AddWithValue("maunen", "trang");
                cmd.Parameters.AddWithValue("tinhtrangdn", 0);
                cmd.Parameters.AddWithValue("quyendn", 0);
                cmd.ExecuteNonQuery();
                conn.Close();
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("lengoctuan2406@gmail.com");
                    mail.To.Add(tv.EMAIL);
                    mail.Subject = "Thông tin đăng kí tài khoản";
                    mail.Body = "<h1>Thân chào " + tv.TENTHANHVIEN + "</h1>"
                        + "<h2>Bạn đã đăng kí tài khoản với Email là: " + tv.EMAIL + "</h2>"
                        + "<h2>Và mật khẩu là: " + MATKHAU + "</h2>";
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
        public object LaydulieuBaivietchitiet1 { get; set; }
        public object LaydulieuBaivietchitiet(int MABAIDANG)
        {
            object list = new object();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT * FROM baiviet, thanhvien tv, theloai tl WHERE baiviet.MATV=tv.MATV AND baiviet.MATL=tl.MATL AND MABAIDANG=@mabaidang";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
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

                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),

                            TENTL = reader["TENTL"].ToString(),
                        };
                        list = ob;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public List<object> Laybinhluanchitiet1 { get; set; }
        public List<object> Laybinhluanchitiet(int MAPOST)
        {
            List<object> list = new List<object>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT tv.ANHDD, tv.TENTHANHVIEN, bl.NGAYBINHLUAN, bl.NOIDUNG FROM binhluan bl, thanhvien tv WHERE bl.MATV=tv.MATV AND MABAIDANG=@mabinhluan AND MADUYET=2";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabinhluan", MAPOST);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            ANHDD = reader["ANHDD"].ToString(),
                            TENTHANHVIEN = reader["TENTHANHVIEN"].ToString(),
                            NGAYBINHLUAN = (DateTime)reader["NGAYBINHLUAN"],
                            NOIDUNG = reader["NOIDUNG"].ToString(),
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public void XulyBinhluanchitietBaiviet(binhluan cm)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into binhluan (MATV, MABAIDANG, NOIDUNG, NGAYBINHLUAN, MADUYET) values(@matv, @mabaidang, @noidung, @ngaybinhluan, @maduyet)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matv", cm.MATV);
                cmd.Parameters.AddWithValue("mabaidang", cm.MABAIDANG);
                cmd.Parameters.AddWithValue("noidung", cm.NOIDUNG);
                cmd.Parameters.AddWithValue("ngaybinhluan", DateTime.Now);
                cmd.Parameters.AddWithValue("maduyet", 1);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void XulyBinhluanchitietBaivietkhac(int MABAIDANG, string NOIDUNG, string EMAIL, string TENTHANHVIEN)
        {
            using (MySqlConnection conn = GetConnection())
            {
                Random TenBienRanDom = new Random();
                int MATKHAU = TenBienRanDom.Next(10000000, 99999999);
                int MATV = -1;
                conn.Open();
                string str = "insert into thanhvien (TENTHANHVIEN, EMAIL, MATKHAU, ANHDD, TWITTER, FACEBOOK, INSTAGRAM, LINKEDIN, NGAYSINH, MAUNEN, TINHTRANGDN, QUYENDN) " +
                    "values(@tenthanhvien, @email, @matkhau, @anhdd, @twitter, @facebook, @instagram, @linkedin, @ngaysinh, @maunen, @tinhtrangdn, @quyendn)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("tenthanhvien", TENTHANHVIEN);
                cmd.Parameters.AddWithValue("email", EMAIL);
                cmd.Parameters.AddWithValue("matkhau", MATKHAU);
                cmd.Parameters.AddWithValue("anhdd", "Anh_Trong.png");
                cmd.Parameters.AddWithValue("twitter", "https://twitter.com/#");
                cmd.Parameters.AddWithValue("facebook", "https://www.facebook.com/#");
                cmd.Parameters.AddWithValue("instagram", "https://www.instagram.com/#");
                cmd.Parameters.AddWithValue("linkedin", "https://www.linkedin.com/#");
                cmd.Parameters.AddWithValue("ngaysinh", DateTime.Now);
                cmd.Parameters.AddWithValue("maunen", "trang");
                cmd.Parameters.AddWithValue("tinhtrangdn", 0);
                cmd.Parameters.AddWithValue("quyendn", 0);
                cmd.ExecuteNonQuery();
                conn.Close();
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("lengoctuan2406@gmail.com");
                    mail.To.Add(EMAIL);
                    mail.Subject = "Thông tin đăng kí tài khoản";
                    mail.Body = "<h1>Thân chào " + TENTHANHVIEN + "</h1>"
                        + "<h2>Bạn đã đăng kí tài khoản với Email là: " + EMAIL + "</h2>"
                        + "<h2>Và mật khẩu là: " + MATKHAU + "</h2>";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("lengoctuan2406@gmail.com", "748159263(Tuan)");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                conn.Open();
                str = "SELECT MATV FROM thanhvien WHERE EMAIL=@email";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", EMAIL);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MATV = Convert.ToInt32(reader["MATV"]);
                    }
                    reader.Close();
                }
                conn.Close();
                conn.Open();
                str = "insert into binhluan (MATV, MABAIDANG, NOIDUNG, NGAYBINHLUAN, MADUYET) values(@matv, @mabaidang, @noidung, @ngaybinhluan, @maduyet)";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matv", MATV);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.Parameters.AddWithValue("noidung", NOIDUNG);
                cmd.Parameters.AddWithValue("ngaybinhluan", DateTime.Now);
                cmd.Parameters.AddWithValue("maduyet", 1);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }

        public void TaoBaivietThanhvien(baiviet bv)
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
                cmd.Parameters.AddWithValue("maduyet", 1);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public thanhvien LaythongtinTacgia1 { get; set; }
        public thanhvien LaythongtinTacgia(int MATV)
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
                        tv.MAUNEN = reader["MAUNEN"].ToString();
                        tv.TINHTRANGDN = Convert.ToInt32(reader["TINHTRANGDN"]);
                        tv.QUYENDN = Convert.ToInt32(reader["QUYENDN"]);
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return tv;
        }
        public List<baiviet> LaybaivietTacgia1 { get; set; }
        public List<baiviet> LaybaivietTacgia(int MATV)
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
        public string Layluotthich1 { get; set; }
        public string Layluotthich(int MABAIDANG)
        {
            int MATV = -1;
            string EMAIL="";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select MATV from thanhvien where TINHTRANGDN=1";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MATV = Convert.ToInt32(reader["MATV"]);
                    }
                    reader.Close();
                }
                conn.Close();
                conn.Open();
                str = "select tv.EMAIL from thanhvien tv, thichbaiviet tbv, baiviet bv " +
                    "where tv.MATV=tbv.MATV AND bv.MABAIDANG=tbv.MABAIDANG AND bv.MABAIDANG=@mabaidang AND tv.MATV=@matv";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG); 
                cmd.Parameters.AddWithValue("matv", MATV);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EMAIL = reader["EMAIL"].ToString();
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return EMAIL;
        }
        public void Congluotthich(int MABAIDANG)
        {
            int MATV = -1;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update baiviet set SOLUOTTHICH=SOLUOTTHICH+1 where MABAIDANG=@mabaidang";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                str = "select MATV from thanhvien where TINHTRANGDN=1";
                cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MATV = Convert.ToInt32(reader["MATV"]);
                    }
                    reader.Close();
                }
                conn.Close();
                conn.Open();
                str = "insert into thichbaiviet (MABAIDANG, MATV) values(@mabaidang, @matv)";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.Parameters.AddWithValue("matv", MATV);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void Truluotthich(int MABAIDANG)
        {
            int MATV = -1;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update baiviet set SOLUOTTHICH=SOLUOTTHICH-1 where MABAIDANG=@mabaidang";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                str = "select MATV from thanhvien where TINHTRANGDN=1";
                cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MATV = Convert.ToInt32(reader["MATV"]);
                    }
                    reader.Close();
                }
                conn.Close();
                conn.Open();
                str = "delete from thichbaiviet where MABAIDANG=@mabaidang and MATV=@matv;";
                cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("mabaidang", MABAIDANG);
                cmd.Parameters.AddWithValue("matv", MATV);
                cmd.ExecuteNonQuery();
                conn.Close();
                return;
            }
        }
        public void XulyQuentaikhoan(string EMAIL)
        {
            using (MySqlConnection conn = GetConnection())
            {
                Random TenBienRanDom = new Random();
                int MATKHAU = TenBienRanDom.Next(10000000, 99999999);
                conn.Open();
                var str = "update thanhvien set MATKHAU=@matkhaumoi where EMAIL=@email";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("email", EMAIL);
                cmd.Parameters.AddWithValue("matkhaumoi", MATKHAU);
                cmd.ExecuteNonQuery();
                conn.Close();
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("lengoctuan2406@gmail.com");
                    mail.To.Add(EMAIL);
                    mail.Subject = "Thông tin cập nhập mật khẩu";
                    mail.Body = "<h2>Mật khẩu mới của bạn là: " + MATKHAU + "</h2>";
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
    }
}
