using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogcongnghe.Areas.Admin.Models
{
    public class thichbaiviet
    {
        private int mathich;
        private int mabaidang;
        private int matv;
        public int MATHICH
        {
            get { return mathich; }
            set { mathich = value; }
        }
        public int MABAIDANG
        {
            get { return mabaidang; }
            set { mabaidang = value; }
        }
        public int MATV
        {
            get { return matv; }
            set { matv = value; }
        }
        public thichbaiviet(int mathichnew, int mabaidangnew, int matvnew)
        {
            this.mathich = mathichnew;
            this.mabaidang = mabaidangnew;
            this.matv = matvnew;
        }
        public thichbaiviet()
        {
        }
    }
}
