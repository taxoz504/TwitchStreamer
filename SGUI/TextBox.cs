using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace SGUI
{
	public class TextBox
	{
		Clock time;
		bool cursorOn = false;
		public string name;
		public string text = "";
		//FIXME: multi character select in textbox
		public int selectedIndex = 0;
		public int StartIndex = 0;
		public int EndIndex = 0;
		string modText = "";
		public RectangleShape rect;
		RectangleShape shadow;
		RectangleShape cursor;
		Text TxtDraw;

		public TextBox (string nameID, FloatRect rectangle)
		{
			name = nameID;
			time = new Clock ();

			RectangleShape tmpRect = new RectangleShape (new Vector2f (rectangle.Width, rectangle.Height));
			tmpRect.Position = new Vector2f (rectangle.Left, rectangle.Top);

			rect = tmpRect;


			shadow = new RectangleShape (rect);
			shadow.Texture = new Texture ("Resources/txtShadow1.png");
			shadow.Texture.Smooth = true;

			cursor = new RectangleShape (new Vector2f (1, 20));
			cursor.FillColor = Color.Black;

		}

		public void MouseDown(Vector2f mousePos)
		{
			float localXpos = mousePos.X - rect.Position.X - 5;

			byte ClosestIndex = 0;

			float ClosestX = 300;

			//Closest char index
			for (byte i = 0; i <= text.Length; i++) {
				if (i == 0) {
					float tmpDist = TxtDraw.FindCharacterPos (i).X - localXpos;
					if (tmpDist < 0) {
						tmpDist = -tmpDist;
					}

					ClosestIndex = 0;
					ClosestX = tmpDist;

				}else{
					float tmpDist = TxtDraw.FindCharacterPos (i).X - localXpos;
					if (tmpDist < 0) {
						tmpDist = -tmpDist;
					}

					if (ClosestX > tmpDist) {
						ClosestX = tmpDist;
						ClosestIndex = i;
					}

				}
			}

			selectedIndex = ClosestIndex;
		}

		public void MouseUp(Vector2f mousePos)
		{



		}

		public void KeyPress(TextEventArgs e)
		{

			if (TxtDraw.FindCharacterPos((uint)text.Length).X <= rect.Size.X - 30) {
				if (e.Unicode != "\b") {
					//text += e.Unicode;
					text = text.Insert (selectedIndex, e.Unicode);
					selectedIndex++;
				}
			}



			/*
			if (text.Length <= 18) {
				
				//try {
				string tmpStr = "";

				//Alphabet keys
				if (e.Shift == true) {
					switch (e.Code) {
					case Keyboard.Key.A: tmpStr = "A";break;
					case Keyboard.Key.B: tmpStr = "B";break;
					case Keyboard.Key.C: tmpStr = "C";break;
					case Keyboard.Key.D: tmpStr = "D";break;
					case Keyboard.Key.E: tmpStr = "E";break;
					case Keyboard.Key.F: tmpStr = "F";break;
					case Keyboard.Key.G: tmpStr = "G";break;
					case Keyboard.Key.H: tmpStr = "H";break;
					case Keyboard.Key.I: tmpStr = "I";break;
					case Keyboard.Key.J: tmpStr = "J";break;
					case Keyboard.Key.K: tmpStr = "K";break;
					case Keyboard.Key.L: tmpStr = "L";break;
					case Keyboard.Key.M: tmpStr = "M";break;
					case Keyboard.Key.N: tmpStr = "N";break;
					case Keyboard.Key.O: tmpStr = "O";break;
					case Keyboard.Key.P: tmpStr = "P";break;
					case Keyboard.Key.Q: tmpStr = "Q";break;
					case Keyboard.Key.R: tmpStr = "R";break;
					case Keyboard.Key.S: tmpStr = "S";break;
					case Keyboard.Key.T: tmpStr = "T";break;
					case Keyboard.Key.U: tmpStr = "U";break;
					case Keyboard.Key.V: tmpStr = "V";break;
					case Keyboard.Key.W: tmpStr = "W";break;
					case Keyboard.Key.X: tmpStr = "X";break;
					case Keyboard.Key.Y: tmpStr = "Y";break;
					case Keyboard.Key.Z: tmpStr = "Z";break;
					}
				}else if(e.Shift == false){
					switch (e.Code) {
					case Keyboard.Key.A: tmpStr = "a";break;
					case Keyboard.Key.B: tmpStr = "b";break;
					case Keyboard.Key.C: tmpStr = "c";break;
					case Keyboard.Key.D: tmpStr = "d";break;
					case Keyboard.Key.E: tmpStr = "e";break;
					case Keyboard.Key.F: tmpStr = "f";break;
					case Keyboard.Key.G: tmpStr = "g";break;
					case Keyboard.Key.H: tmpStr = "h";break;
					case Keyboard.Key.I: tmpStr = "i";break;
					case Keyboard.Key.J: tmpStr = "j";break;
					case Keyboard.Key.K: tmpStr = "k";break;
					case Keyboard.Key.L: tmpStr = "l";break;
					case Keyboard.Key.M: tmpStr = "m";break;
					case Keyboard.Key.N: tmpStr = "n";break;
					case Keyboard.Key.O: tmpStr = "o";break;
					case Keyboard.Key.P: tmpStr = "p";break;
					case Keyboard.Key.Q: tmpStr = "q";break;
					case Keyboard.Key.R: tmpStr = "r";break;
					case Keyboard.Key.S: tmpStr = "s";break;
					case Keyboard.Key.T: tmpStr = "t";break;
					case Keyboard.Key.U: tmpStr = "u";break;
					case Keyboard.Key.V: tmpStr = "v";break;
					case Keyboard.Key.W: tmpStr = "w";break;
					case Keyboard.Key.X: tmpStr = "x";break;
					case Keyboard.Key.Y: tmpStr = "y";break;
					case Keyboard.Key.Z: tmpStr = "z";break;
					}
				}

				//others
				switch (e.Code ) {
				case Keyboard.Key.Space:tmpStr = " ";break;
				case Keyboard.Key.Left:tmpStr = "left";break;
				case Keyboard.Key.Right:tmpStr = "";break;
				case Keyboard.Key.BackSpace:tmpStr = "back";break;
				}



				//Insert operation

				switch (tmpStr) {
				case "left":
					selectedIndex-= 2;
					break;
				case "back":
					selectedIndex-=2;
					text = text.Remove (selectedIndex-2);
					break;
				default:
					try {
						text = text.Insert (selectedIndex, tmpStr);
					} catch (Exception ex) {
						try {
							selectedIndex--;
							text = text.Insert (selectedIndex, tmpStr);
							
						} catch (Exception ex2) {
							
						}
					}
					break;
				}




				//Select index change operation
				try {
					selectedIndex++;
				} catch (Exception ex) {
					
				}
				
			}
			*/

		}

		public void SpecialKey(KeyEventArgs e)
		{
			switch (e.Code) {
			case Keyboard.Key.BackSpace:
				try {
					text = text.Remove (selectedIndex - 1, 1);
					selectedIndex--;
				} catch (Exception ex) {

				}
				break;
			case Keyboard.Key.Delete:
				try {
					text = text.Remove (selectedIndex, 1);
					//selectedIndex++;
				} catch (Exception ex) {

				}
				break;
			case Keyboard.Key.Left:
				if (selectedIndex > 0) {
					selectedIndex--;
				}
				break;
			case Keyboard.Key.Right:
				if (selectedIndex < text.Length) {
					selectedIndex++;
				}
				break;
			}
		}

		public void Draw(RenderWindow window)
		{
			window.Draw (rect);

			TxtDraw = new Text (modText, Globals.mainFont, 20);
			TxtDraw.Position =  new Vector2f(rect.Position.X + 5f, rect.Position.Y);
			TxtDraw.Color = Color.Black;

			window.Draw (TxtDraw);


			if (cursorOn) {
				window.Draw (cursor);
			}


			shadow.Position = rect.Position;
			window.Draw (shadow);




		}

		public void Update()
		{
			rect.Position = Globals.points [name + "Point"] + Globals.points ["mainPage"];

			//If selected
			if (Globals.lockedControl == name) {
				try {
					//modText = text.Insert(selectedIndex, "|");
					//cursor.Position = new Vector2f(cursor.Position.X, cursor.Position.Y + (float)Math.Sin(time.ElapsedTime.AsSeconds()));
					//cursor.Size = new Vector2f(cursor.Size.X, 2f * (float)Math.Sin(time.ElapsedTime.AsSeconds()));
					modText = text;
					cursorOn = true;
					cursor.Position = new Vector2f(
						TxtDraw.Position.X + TxtDraw.FindCharacterPos((uint)selectedIndex).X, 
						rect.Position.Y + TxtDraw.FindCharacterPos((uint)selectedIndex).Y + 3);
					//cursor.Size = new Vector2f(cursor.Size.X, 20f - (((float)Math.Sin(time.ElapsedTime.AsSeconds()*3f))+1)*5*1.5f);

					cursor.FillColor = new Color(0, 0, 0,  (byte)Math.Round((((Math.Sin(time.ElapsedTime.AsSeconds()*5)+1)/2)*255)));

				} catch (Exception ex) {
					
				}
				//modText = text + "-";
			}else{
				modText = text;
				cursorOn = false;
			}


		}



	}
}
