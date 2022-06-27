using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogcongnghe.Areas.Admin.Models
{
    public class binhluan
    {
        private int mabl;
        private int matv;
        private int mabaidang;
        private string noidung;
        private DateTime ngaybinhluan;
        private int maduyet;
        public int MABL
        {
            get { return mabl; }
            set { mabl = value; }
        }
        public int MATV
        {
            get { return matv; }
            set { matv = value; }
        }
        public int MABAIDANG
        {
            get { return mabaidang; }
            set { mabaidang = value; }
        }
        public string NOIDUNG
        {
            get { return noidung; }
            set { noidung = value; }
        }
        public DateTime NGAYBINHLUAN
        {
            get { return ngaybinhluan; }
            set { ngaybinhluan = value; }
        }
        public int MADUYET
        {
            get { return maduyet; }
            set { maduyet = value; }
        }
        public binhluan(int mablnew, int matvnew, int mabaidangnew, string noidungnew, DateTime ngaybinhluannew, int maduyetnew)
        {
            this.mabl = mablnew;
            this.matv = matvnew;
            this.mabaidang = mabaidangnew;
            this.noidung = noidungnew;
            this.ngaybinhluan = ngaybinhluannew;
            this.maduyet = maduyetnew;
        }
        public binhluan()
        {
        }
    }
}
