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
