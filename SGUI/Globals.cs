//using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public static class Globals
	{
		public static Form MainForm;

		public static string title		= "Twitch Streamer";
		public static uint width		= 527;
		public static uint height		= 345;
		public static string version 	= "v1.06";
		public static bool shouldClose 	= false;
		public static bool pageTurning	= false;
		public static string lockedControl = "";

		//Rectangles objects
		public static Dictionary<string, RectangleShape>[] rects = new Dictionary<string, RectangleShape>[byte.MaxValue];
		public static Dictionary<string, Text> texts = new Dictionary<string, Text> ();
		public static Dictionary<string, Vector2f> points = new Dictionary<string, Vector2f> ();
		public static List<TextBox> txtBoxes = new List<TextBox> ();
		public static List<Button> btns = new List<Button>();
		public static List<Label> Lbls = new List<Label> ();
		//public static Button btn = new Button("Test", 20,20,100,50);
		//public static Dictionary<string, TextBox> txtBoxes = new Dictionary<string, TextBox> ();

		//Mouse
		public static bool mouseDown = false;
		public static bool mouseFirst = false;
		public static bool headerLocked = false;
		public static Vector2i mouseOffset = new Vector2i(0,0);
		public static RectangleShape mouseRect;

		//Fonts
		public static Font mainFont = new Font("Resources/Numans-Regular.ttf");

		//Colors
		public static Color TwitchPurple = new Color(100,65,165);
		public static Color TwitchPurplePanel = new Color(100-10, 65-10, 165-10);
		public static Color TwitchLightGrey = new Color(241,241,241);
		public static Color ButtonColor = new Color (100-20, 65-20, 165-20);
		public static Color ButtonDownColor = new Color (100-30, 65-30, 165-30);


		//public static TextBox txtBox = new TextBox ("test", new FloatRect (12, 126,250, 26));



	}
}

