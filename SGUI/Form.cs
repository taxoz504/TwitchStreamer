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
			base.TextEntered += TextEntered;
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

		void TextEntered (object sender, TextEventArgs e)
		{
			//Targetted control
			if (Globals.lockedControl != "") {
				Globals.txtBoxes.ForEach (delegate(TextBox txt){
					if (txt.name == Globals.lockedControl) {
						txt.KeyPress(e);
					}
				});
			}

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

			Globals.txtBoxes.ForEach (delegate(TextBox txt){
				if (mouseRect.IntersectsWith(new System.Drawing.RectangleF(txt.rect.Position.X, txt.rect.Position.Y, txt.rect.Size.X, txt.rect.Size.Y))) {
					Globals.lockedControl = txt.name;
					txt.MouseUp(new Vector2f(mouseRect.Left + 1, mouseRect.Top + 1));
					//this.SetTitle(Globals.lockedControl);
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
				Globals.lockedControl = "";
			}



			Globals.txtBoxes.ForEach (delegate(TextBox txt){
				if (mouseRect.IntersectsWith(new System.Drawing.RectangleF(txt.rect.Position.X, txt.rect.Position.Y, txt.rect.Size.X, txt.rect.Size.Y))) {
					//Globals.lockedControl = txt.name;
					txt.MouseDown(new Vector2f(mouseRect.Left + 1, mouseRect.Top + 1));
					//this.SetTitle(Globals.lockedControl);
				}
			});





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

			//Targetted control
			if (Globals.lockedControl != "") {
				Globals.txtBoxes.ForEach (delegate(TextBox txt){
					if (txt.name == Globals.lockedControl) {
						txt.SpecialKey(e);
					}
				});
			}
			
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

			#region Controls
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

			Globals.points.Add("txtNamePoint", new Vector2f(0,0));
			Globals.txtBoxes.Add(new TextBox ("txtName", new FloatRect (12, 126,250, 26)));
			AnimatePos("txtNamePoint", true, new Vector2f(-260, 126), new Vector2f(12, 126), 2f);

			Globals.points.Add("txtAddPoint", new Vector2f(0,0));
			Globals.txtBoxes.Add(new TextBox ("txtAdd", new FloatRect (425, 152, 101, 26)));
			AnimatePos("txtAddPoint", true, new Vector2f(Globals.width + 105, 145), new Vector2f(422, 147), 2f);


			Globals.Lbls.Add(new Label("Casters name:", 16, true, "lblNamePoint"));
			Globals.points.Add("lblNamePoint", new Vector2f(0,0));
			AnimatePos("lblNamePoint", true, new Vector2f(-300, 104), new Vector2f(12, 104), 2f);

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

			Globals.txtBoxes.ForEach (delegate(TextBox txt){
				txt.Update();
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
				

			Globals.Lbls.ForEach (delegate(Label lbl){
				lbl.Draw(this);
			});

			Globals.txtBoxes.ForEach (delegate(TextBox txt){
				txt.Draw(this);
			});

			Globals.btns.ForEach (delegate(Button btn){
				btn.Draw(this);
			});


			//Globals.txtBox.Draw (this);


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

