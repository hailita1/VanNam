using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Model_Class
{
    public class Class_Que
    {
        private string MaQue;
        private string TenQue;
        public Class_Que()
        {
        }
        public Class_Que(string MaQue, string TenQue)
        {
            this.MaQue = MaQue;
            this.TenQue = TenQue;
        }

        public string MaQue1 { get => MaQue; set => MaQue = value; }
        public string TenQue1 { get => TenQue; set => TenQue = value; }
    }
}
