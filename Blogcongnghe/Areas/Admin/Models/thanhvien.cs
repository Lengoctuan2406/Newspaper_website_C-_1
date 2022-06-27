using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogcongnghe.Areas.Admin.Models
{
    public class thanhvien
    {
        private int matv;
        private string tenthanhvien;
        private string email;
        private string matkhau;
        private string anhdd;
        private string sdt;
        private string bio;
        private string diachi;
        private string twitter;
        private string facebook;
        private string instagram;
        private string linkedin;
        private string tinnhan;
        private DateTime ngaysinh;
        private string maunen;
        private int tinhtrangdn;
        private int quyendn;
        public int MATV
        {
            get { return matv; }
            set { matv = value; }
        }
        public string TENTHANHVIEN
        {
            get { return tenthanhvien; }
            set { tenthanhvien = value; }
        }
        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }
        public string MATKHAU
        {
            get { return matkhau; }
            set { matkhau = value; }
        }
        public string ANHDD
        {
            get { return anhdd; }
            set { anhdd = value; }
        }
        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
        public string BIO
        {
            get { return bio; }
            set { bio = value; }
        }
        public string DIACHI
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public string TWITTER
        {
            get { return twitter; }
            set { twitter = value; }
        }
        public string FACEBOOK
        {
            get { return facebook; }
            set { facebook = value; }
        }
        public string INSTAGRAM
        {
            get { return instagram; }
            set { instagram = value; }
        }
        public string LINKEDIN
        {
            get { return linkedin; }
            set { linkedin = value; }
        }
        public string TINNHAN
        {
            get { return tinnhan; }
            set { tinnhan = value; }
        }
        public DateTime NGAYSINH
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }
        public string MAUNEN
        {
            get { return maunen; }
            set { maunen = value; }
        }
        public int TINHTRANGDN
        {
            get { return tinhtrangdn; }
            set { tinhtrangdn = value; }
        }
        public int QUYENDN
        {
            get { return quyendn; }
            set { quyendn = value; }
        }
        public thanhvien(int matvnew, string tenthanhviennew, string emailnew, string matkhaunew,
            string anhddnew, string sdtnew, string bionew, string diachinew, string twitternew,
            string facebooknew, string instagramnew, string linkedinnew, string tinnhannew,
            DateTime ngaysinhnew, string maunennew, int tinhtrangdnnew, int quyendnnew)
        {
            this.matv = matvnew;
            this.tenthanhvien = tenthanhviennew;
            this.email = emailnew;
            this.matkhau = matkhaunew;
            this.anhdd = anhddnew;
            this.sdt = sdtnew;
            this.bio = bionew;
            this.diachi = diachinew;
            this.twitter = twitternew;
            this.facebook = facebooknew;
            this.instagram = instagramnew;
            this.linkedin = linkedinnew;
            this.tinnhan = tinnhannew;
            this.ngaysinh = ngaysinhnew;
            this.maunen = maunennew;
            this.tinhtrangdn = tinhtrangdnnew;
            this.quyendn = quyendnnew;
        }
        public thanhvien()
        {
        }
    }
}
