using System;
using System.Threading;
//using System.Drawing;

using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace SGUI
{
	public class Form : RenderWindow
	{
		#region Variables
			//RectangleShape line;
		//Sprite logo;
		#endregion

		public Form () : base(new VideoMode(Globals.width,Globals.height), Globals.title, Styles.None)
		{
			Init ();

			base.SetActive();

			base.Closed += FormClosed;
			base.KeyPressed += KeyPressed;
			base.KeyReleased += KeyReleased;
			base.MouseMoved += MouseMoved;
			//base.MouseButtonPressed += MouseButtonPressed;
			//base.MouseButtonReleased += MouseButtonReleased;

			base.SetFramerateLimit (60);

			while (base.IsOpen) {
				//Update
				Update ();

				//Draw
				base.Clear (Globals.TwitchPurple);
				base.DispatchEvents ();
				Draw ();
				base.Display ();
			}

			Unload ();
		}

		void MouseButtonReleased ()
		{
			Globals.headerLocked = false;

			System.Drawing.RectangleF mouseRect = new System.Drawing.RectangleF (Globals.mouseRect.Position.X, Globals.mouseRect.Position.Y, Globals.mouseRect.Size.X, Globals.mouseRect.Size.Y);

			Globals.btns.ForEach (delegate(Button btn){
				if (mouseRect.IntersectsWith(btn.rect)) {
					btn.Pressed();
					
				}

			});




		}

		void MouseButtonPressed ()
		{
			System.Drawing.RectangleF mouseRect = new System.Drawing.RectangleF (Globals.mouseRect.Position.X, Globals.mouseRect.Position.Y, Globals.mouseRect.Size.X, Globals.mouseRect.Size.Y);
			System.Drawing.RectangleF headerRect = new System.Drawing.RectangleF (Globals.rects[1]["header"].Position.X, Globals.rects[1]["header"].Position.Y, Globals.rects[1]["header"].Size.X, Globals.rects[1]["header"].Size.Y);


			if (mouseRect.IntersectsWith (headerRect))   
			{
				Globals.mouseOffset = base.InternalGetMousePosition ();
				Globals.headerLocked = true;
			}




		}

		void MouseMoved (object sender, MouseMoveEventArgs e)
		{
			
		}

		void KeyReleased (object sender, KeyEventArgs e)
		{
			if (e.Code == Keyboard.Key.Escape) {
				base.Close ();
			}
		}

		void KeyPressed (object sender, KeyEventArgs e)
		{
			
		}

		void FormClosed (object sender, EventArgs e)
		{
			
		}

		void Init()
		{

			Globals.mouseRect = new RectangleShape (new Vector2f (3f, 3f));
			Globals.mouseRect.FillColor = Color.White;

			#region initDictionarys
			for (int i = 0; i < byte.MaxValue; i++) {
				Globals.rects[i] = new System.Collections.Generic.Dictionary<string, RectangleShape>();
			}
			#endregion

			#region Header

			RectangleShape line = new RectangleShape (new Vector2f (Globals.width, 2));
			line.FillColor = Globals.TwitchLightGrey;
			line.Position = new Vector2f (0, 95);
			//Globals.rects.Add(10, Globals.rects[10].Add ("line", line));
			Globals.rects[10].Add("line", line);
			AnimatePos ("line",10, new Vector2f ((float)Globals.width, 95f), new Vector2f (0f,95f), 2f);

			RectangleShape Header= new RectangleShape(new Vector2f(Globals.width, 95f));
			Header.FillColor = Globals.TwitchPurplePanel;
			Header.Position = new Vector2f (0f, 0f); 
			Globals.rects[1].Add ("header", Header);
			AnimatePos ("header",1, new Vector2f (0f, -95f), new Vector2f (0f,0f), 2f);

			//logo = new Sprite (new Texture ("Resources/Twitch_Logo.png"));
			Texture logoTex = new Texture ("Resources/Twitch_Logo.png");
			RectangleShape logoRect = new RectangleShape(new Vector2f(logoTex.Size.X, logoTex.Size.Y));
			logoRect.Texture = logoTex;
			//logoRect.Texture.Smooth = true;
			logoRect.Position = new Vector2f (0f, 0f);
			Globals.rects[2].Add ("logo", logoRect);
			AnimatePos ("logo",2, new Vector2f (10f, -95f), new Vector2f (10f,10f), 2f);

			Globals.texts.Add("version", new Text("Streamer " + Globals.version, Globals.mainFont, 24));
			Globals.texts["version"].Position = new Vector2f(210f, 60f);
			AnimatePos("version", new Vector2f (Globals.width, 60f), new Vector2f (210f,60f), 2f);


			#endregion

			#region Buttons
			float newpos = Globals.height - 65f;

			RectangleShape line2 = new RectangleShape (new Vector2f (Globals.width, 2));
			line2.FillColor = Globals.TwitchLightGrey;
			line2.Position = new Vector2f (0, 95);
			Globals.rects[10].Add ("line2", line2);
			AnimatePos ("line2",10, new Vector2f (-(float)Globals.width, newpos), new Vector2f (0f,newpos), 2f);

			RectangleShape ButtonBG= new RectangleShape(new Vector2f(Globals.width, 65f));
			ButtonBG.FillColor = Globals.TwitchPurplePanel;
			ButtonBG.Position = new Vector2f (0f, 0f);
			Globals.rects[0].Add ("buttonBG", ButtonBG);
			AnimatePos ("buttonBG",0, new Vector2f (0f, Globals.height), new Vector2f (0f,newpos), 2f);


			Globals.btns.Add(new ExitBtn());
			Globals.btns.Add(new SettingsBtn());
			Globals.btns.Add(new WatchBtn());

			//In pages
			//Back button
			Globals.points.Add("backBtnPoint", new Vector2f(Globals.width*2-115,20));
			Globals.btns.Add(new BackBtn());

			//Add button
			Globals.points.Add("addBtnPoint", new Vector2f(0,0));
			Globals.btns.Add(new AddBtn());

			//Delete button
			Globals.points.Add("deleteBtnPoint", new Vector2f(0,0));
			Globals.btns.Add(new DeleteBtn());


			#endregion

			Globals.points.Add ("mainPage", new Vector2f(0,0));


			#region MainPage

			#region credits
			Texture credTex = new Texture("Resources/credits.png");
			RectangleShape Credits = new RectangleShape(new Vector2f(credTex.Size.X, credTex.Size.Y));
			Credits.Texture = credTex;
			Globals.points.Add("creditsPoint", new Vector2f(0,95));
			Globals.rects[0].Add ("credits", Credits);
			AnimatePos("creditsPoint", true, new Vector2f (Globals.width-Credits.Size.X, 0f), new Vector2f (Globals.width-Credits.Size.X+1,97f), 2f);
			//AnimatePos ("credits",0, new Vector2f (Globals.width-Credits.Size.X, 0f), new Vector2f (Globals.width-Credits.Size.X,97f), 2f);

			//Globals.texts.Add("credits", new Text("Hello!!", new Font("Resources/Numans-Regular.ttf"), 14));
			//Globals.texts["version"].Position = new Vector2f(210f, 60f);
			//AnimatePos("version", new Vector2f (Globals.width, 60f), new Vector2f (210f,60f), 2f);
			
			

			#endregion

			#endregion

		}

		void Update()
		{


			Globals.mouseRect.Position = new Vector2f (base.InternalGetMousePosition().X-1f, base.InternalGetMousePosition().Y - 1f);

			if (Globals.shouldClose) {
				base.Close ();
			}

			System.Drawing.RectangleF mouseRect = new System.Drawing.RectangleF (Globals.mouseRect.Position.X, Globals.mouseRect.Position.Y, Globals.mouseRect.Size.X, Globals.mouseRect.Size.Y);
			System.Drawing.RectangleF headerRect = new System.Drawing.RectangleF (Globals.rects[1]["header"].Position.X, Globals.rects[1]["header"].Position.Y, Globals.rects[1]["header"].Size.X, Globals.rects[1]["header"].Size.Y);


			if (base.HasFocus()) {

				//First call
				if (Mouse.IsButtonPressed (Mouse.Button.Left) == true && Globals.mouseDown == false) {
					MouseButtonPressed ();
					//Globals.mouseOffset = base.InternalGetMousePosition ();
				}

				//released
				if (Mouse.IsButtonPressed (Mouse.Button.Left) == false && Globals.mouseDown == true) {
					MouseButtonReleased ();
				}

				/*
				if (mouseRect.IntersectsWith (headerRect)) {
					if (Mouse.IsButtonPressed (Mouse.Button.Left) == true && Globals.mouseDown == false) {
						//MouseButtonPressed ();
						Globals.mouseOffset = base.InternalGetMousePosition ();
					}
				}
				*/

				Globals.mouseDown = Mouse.IsButtonPressed (Mouse.Button.Left);
			}else{
				Globals.mouseDown = false;
			}

			//Button interactions
			foreach (var btn in Globals.btns) {
				if (mouseRect.IntersectsWith(btn.rect)) {
					if (btn.mouseOver == false) {
						btn.MouseEnter ();
						btn.mouseOver = true;
					}else{
						btn.MouseOver ();
						if (Globals.mouseDown) {
							btn.MouseDown ();
						}
					}


				}else{
					if (btn.mouseOver == true) {
						btn.MouseLeave ();
						btn.mouseOver = false;
					}
				}
			}


			if (Globals.mouseDown) {
				Globals.mouseRect.FillColor = Color.Blue;

				if (Globals.headerLocked) {
					base.Position = new Vector2i(Mouse.GetPosition ().X - Globals.mouseOffset.X, Mouse.GetPosition ().Y - Globals.mouseOffset.Y);
				}

			}else{
				Globals.mouseRect.FillColor = Color.White;
			}

			//
			//logo.Position = Globals.rects [2]["logo"].Position;

			//Globals.texts ["credits"].Position = new Vector2f (Globals.rects[0]["credits"].Position.X+2f,Globals.rects[0]["credits"].Position.Y+2f);
			

			Globals.btns.ForEach (delegate(Button btn){
				btn.Update();
			});


			//LOCKING PAGES
			//Credits
			//Globals.rects [0] ["credits"].Position = new Vector2f(Globals.points ["creditsPoint"].X + Globals.points ["mainPage"].X, Globals.rects [0] ["credits"].Position.Y);
			Globals.rects [0] ["credits"].Position = new Vector2f(Globals.points ["creditsPoint"].X + Globals.points ["mainPage"].X,Globals.points ["creditsPoint"].Y + Globals.points ["mainPage"].Y );
			Globals.points["backBtn"] = Globals.points["backBtnPoint"] + Globals.points ["mainPage"];
			Globals.points ["addBtn"] = Globals.points ["addBtnPoint"] + Globals.points ["mainPage"];
			Globals.points ["deleteBtn"] = Globals.points ["deleteBtnPoint"] + Globals.points ["mainPage"];


		}

		void Draw()
		{
			//base.Draw (Globals.rects ["line"]);
			for (byte i = 0; i < byte.MaxValue; i++) {
				foreach (var rect in Globals.rects[i]) {
					//RectangleShape tmpRect = new RectangleShape (rect.Value);
					base.Draw (rect.Value);
				}
			}

			foreach (var txt in Globals.texts) {
				base.Draw (txt.Value);
			}
				

			Globals.btns.ForEach (delegate(Button btn){
				btn.Draw(this);
			});


			base.Draw (Globals.mouseRect);

		}

		void Unload()
		{
			
		}


		public static void AnimatePos(string shapeKey, byte layer , Vector2f start, Vector2f stop, float time)
		{
			Thread AnimThread = new Thread (() => Animation.animatePosition(shapeKey,layer,start,stop,time));
			AnimThread.Start ();
		}

		public static void AnimatePos(string textKey , Vector2f start, Vector2f stop, float time)
		{
			Thread AnimThread = new Thread (() => Animation.animatePosition(textKey,start,stop,time));
			AnimThread.Start ();
		}

		public static void AnimatePos(string pointKey, bool rnd , Vector2f start, Vector2f stop, float time)
		{
			//if (Globals.pageTurning == false) {
				Thread AnimThread = new Thread (() => Animation.animatePosition(pointKey, rnd ,start,stop,time));
				AnimThread.Start ();
				
			//}
		}



	}
}

