using System;
using System.Runtime.InteropServices;

namespace SGUI
{
	class MainClass
	{
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		public static void Main (string[] args)
		{
			// Hide Console
			ShowWindow(GetConsoleWindow(), 0);


			//open form
			Form MainForm = new Form ();

			/*
			sw = new Stopwatch ();
			sw.Start ();

			Clock cl = new Clock ();
			cl.ElapsedTime.

			Console.WriteLine ("Hello World!");

			window = new RenderWindow(new VideoMode(55,345), "test", Styles.None);
			CircleShape cs = new CircleShape(100.0f);
			cs.FillColor = Color.Green;
			Text text = new Text ("Hello!", new Font ("Numans-Regular.ttf"), 72);
			Text text;
			text.Color = Color.Blue;
			text.Position = new Vector2f (10f, 10f);

			RectangleShape line = new RectangleShape (new Vector2f (600, 2));

			window.SetActive();

			window.KeyPressed += KeyPressed;
			window.Closed+= WindowClosed;

			//Loop

			while (window.IsOpen)
			{
				window.Clear(new Color(100,65,165));
				window.DispatchEvents();
				//window.Draw(cs);

				//text.Position = new Vector2f (10f + (float)Math.Sin((double)cl.ElapsedTime.AsSeconds())*10,10f);

				//window.Draw (text);
				window.Display();


				//Clock clwait = new Clock ();
				//do {} while (clwait.ElapsedTime.AsMilliseconds() <= 16); //fps limit


			}
			*/
		}
		/*
		static void WindowClosed (object sender, EventArgs e)
		{
			window.Close ();
		}

		static void KeyPressed (object sender, KeyEventArgs e)
		{
			if (e.Code == Keyboard.Key.Escape) {
				window.Close ();
				
			}
		}
		*/

	}
}
