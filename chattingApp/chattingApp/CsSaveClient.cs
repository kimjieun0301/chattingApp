namespace chattingApp
{
    public class CsSaveClient
    {
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
