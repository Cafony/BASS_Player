using System;
using System.Windows.Forms;

namespace player
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        /// <summary>
        /// REGISTRY
        /// </summary>

        public static AppKey appKey = new AppKey("Software\\rionix\\nls15\\BassPlayer\\");
        public static void WriteKey(string key, object value) { appKey.Write(key, value); }
        public static object ReadKey(string key, object value) { return appKey.Read(key, value); }
        public static bool ExistKey(string key) { return appKey.Exist(key); }
    }
}