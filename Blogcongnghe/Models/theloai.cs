using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogcongnghe.Models
{
    public class theloai
    {
        private int matl;
        private string tentl;
        public int MATL
        {
            get { return matl; }
            set { matl = value; }
        }
        public string TENTL
        {
            get { return tentl; }
            set { tentl = value; }
        }
        public theloai(int matlnew, string tentlnew)
        {
            this.matl = matlnew;
            this.tentl = tentlnew;
        }
        public theloai()
        {
        }
    }
}
