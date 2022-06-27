using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogcongnghe.Models
{
    public class baiviet
    {
        private int mabaidang;
        private int matl;
        private int matv;
        private string tieude;
        private string noidung;
        private string anh1;
        private string anh2;
        private string anh3;
        private int soluotthich;
        private int soluongbinhluan;
        private DateTime ngaydang;
        private int maduyet;
        public int MABAIDANG
        {
            get { return mabaidang; }
            set { mabaidang = value; }
        }
        public int MATL
        {
            get { return matl; }
            set { matl = value; }
        }
        public int MATV
        {
            get { return matv; }
            set { matv = value; }
        }
        public string TIEUDE
        {
            get { return tieude; }
            set { tieude = value; }
        }
        public string NOIDUNG
        {
            get { return noidung; }
            set { noidung = value; }
        }
        public string ANH1
        {
            get { return anh1; }
            set { anh1 = value; }
        }
        public string ANH2
        {
            get { return anh2; }
            set { anh2 = value; }
        }
        public string ANH3
        {
            get { return anh3; }
            set { anh3 = value; }
        }
        public int SOLUOTTHICH
        {
            get { return soluotthich; }
            set { soluotthich = value; }
        }
        public int SOLUONGBINHLUAN
        {
            get { return soluongbinhluan; }
            set { soluongbinhluan = value; }
        }
        public DateTime NGAYDANG
        {
            get { return ngaydang; }
            set { ngaydang = value; }
        }
        public int MADUYET
        {
            get { return maduyet; }
            set { maduyet = value; }
        }
        public baiviet(int mabaidangnew, int matlnew, int matvnew, string tieudenew, string noidungnew, string anh1new, string anh2new, string anh3new,
            int soluotthichnew, int soluongbinhluannew, DateTime ngaydangnew, int maduyetnew)
        {
            this.mabaidang = mabaidangnew;
            this.matl = matlnew;
            this.matv = matvnew;
            this.tieude = tieudenew;
            this.noidung = noidungnew;
            this.anh1 = anh1new;
            this.anh2 = anh2new;
            this.anh3 = anh3new;
            this.soluotthich = soluotthichnew;
            this.soluongbinhluan = soluongbinhluannew;
            this.ngaydang = ngaydangnew;
            this.maduyet = maduyetnew;
        }
        public baiviet()
        {
        }
    }
}
