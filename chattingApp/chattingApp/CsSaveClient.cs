using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chattingApp
{
    public class CsSaveClient
    {
        //    public CsSaveClient(CsClientHandler CsClientHandler1)
        //    {
        //        _CsClientHandler = CsClientHandler1;
        //}
        //    public CsClientHandler _CsClientHandler { get; }
        private static CsSaveClient instance;
        public CsClientHandler _CsClientHandler { get; set; }

        private CsSaveClient() { }

        public static CsSaveClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CsSaveClient();
                }
                return instance;
            }
        }
    }
}
