//using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public static class Globals
	{
		public static string title		= "Twitch Streamer";
		public static uint width		= 527;
		public static uint height		= 345;
		public static string version 	= "v1.06";

		//Rectangles objects
		public static Dictionary<string, RectangleShape>[] rects = new Dictionary<string, RectangleShape>[byte.MaxValue];
		public static Dictionary<string, Text> texts = new Dictionary<string, Text> ();
		public static List<Button> btns = new List<Button>();
		//public static Button btn = new Button("Test", 20,20,100,50);

		//Mouse
		public static bool mouseDown = false;
		public static bool mouseFirst = false;
		public static bool headerLocked = false;
		public static Vector2i mouseOffset = new Vector2i(0,0);
		public static RectangleShape mouseRect;





	}
}

