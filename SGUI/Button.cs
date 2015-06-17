using System;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public class Button
	{
		public string text;
		public System.Drawing.RectangleF rect;
		public bool mouseOver = false;
		public Color buttonColor = Globals.ButtonColor;
		RectangleShape mainRect;
		public RectangleShape shadowRect;


		public Button (string text, int x, int y, int width, int height)
		{
			this.text = text;
			rect = new System.Drawing.RectangleF (x,y,width,height);
			mainRect = new RectangleShape (new Vector2f (rect.Width, rect.Height));
		} 


		public void Draw(RenderWindow window)
		{
			shadowRect.Size = new Vector2f (shadowRect.Texture.Size.X,shadowRect.Texture.Size.Y);
			shadowRect.Position = new Vector2f (rect.X - 15f, rect.Y - 15f);
			window.Draw (shadowRect);

			mainRect.FillColor = buttonColor;
			mainRect.Position = new Vector2f (rect.X, rect.Y);
			mainRect.Size = new Vector2f (rect.Width, rect.Height);
			window.Draw (mainRect);


			Text txt = new Text (text, Globals.mainFont, 32);
			//byte halfCount = (byte)((byte)text.Length / 2);
			//Vector2f offset = txt.FindCharacterPos ((uint)halfCount);
			txt.Scale = new Vector2f (0.5f,0.5f);
			txt.Position = new Vector2f (rect.X + rect.Width/3f,rect.Y + rect.Height/4f);
			window.Draw (txt);

		}


		public virtual void Pressed()
		{

		}

		public virtual void MouseOver()
		{

		}

		public virtual void MouseDown()
		{

		}

		public virtual void MouseEnter()
		{

		}

		public virtual void MouseLeave()
		{

		}


	}
}

