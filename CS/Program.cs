using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Splash screens and wait forms created with the help of the SplashScreenManager component run in a separate thread.  
            // Information on custom skins registered in the main thread is not available in the splash screen thread  
            // until you call the SplashScreenManager.RegisterUserSkins method.  
            // To provide information on custom skins to the splash screen thread, uncomment the following line. 
            //SplashScreenManager.RegisterUserSkins(asm);  
            Application.Run(new Form1());
        }
    }
}
