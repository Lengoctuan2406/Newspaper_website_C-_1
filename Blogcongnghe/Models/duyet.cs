using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogcongnghe.Models
{
    public class duyet
    {
        private int maduyet;
        private string tenduyet;
        public int MADUYET
        {
            get { return maduyet; }
            set { maduyet = value; }
        }
        public string TENDUYET
        {
            get { return tenduyet; }
            set { tenduyet = value; }
        }
        public duyet(int maduyetnew, string tenduyetnew)
        {
            this.maduyet = maduyetnew;
            this.tenduyet = tenduyetnew;
        }
        public duyet()
        {
        }
    }
}
