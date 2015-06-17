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
		public Color buttonColor = new Color (185, 163, 227);
		RectangleShape mainRect;

		public Button (string text, int x, int y, int width, int height)
		{
			this.text = text;
			rect = new System.Drawing.RectangleF (x,y,width,height);
			mainRect = new RectangleShape (new Vector2f (rect.Width, rect.Height));
		} 


		public void Draw(RenderWindow window)
		{
			mainRect.FillColor = buttonColor;
			mainRect.Position = new Vector2f (rect.X, rect.Y);
			mainRect.Size = new Vector2f (rect.Width, rect.Height);
			window.Draw (mainRect);
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

