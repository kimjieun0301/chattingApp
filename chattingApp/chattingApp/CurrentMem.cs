using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chattingApp
{
    public class CurrentMem
    {
        private static CurrentMem instance;
        public CsMemList User { get; set; }

        private CurrentMem() { }

        public static CurrentMem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentMem();
                }
                return instance;
            }
        }
    }

}
