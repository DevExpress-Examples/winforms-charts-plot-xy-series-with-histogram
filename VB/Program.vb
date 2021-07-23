Imports System
Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Forms

Namespace WindowsFormsApplication1
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)

			' Splash screens and wait forms created with the help of the SplashScreenManager component run in a separate thread.  
			' Information on custom skins registered in the main thread is not available in the splash screen thread  
			' until you call the SplashScreenManager.RegisterUserSkins method.  
			' To provide information on custom skins to the splash screen thread, uncomment the following line. 
			'SplashScreenManager.RegisterUserSkins(asm);  
			Application.Run(New Form1())
		End Sub
	End Module
End Namespace
