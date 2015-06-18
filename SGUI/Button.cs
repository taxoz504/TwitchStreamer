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
		public bool mouseDown = false;
		public Color buttonColor = Globals.ButtonColor;
		RectangleShape mainRect;
		public RectangleShape shadowRect;
		public RectangleShape innerShadowRect;
		public int xOffset;

		public Button (string text, int x, int y, int width, int height)
		{
			this.text = text;
			rect = new System.Drawing.RectangleF (x,y,width,height);
			mainRect = new RectangleShape (new Vector2f (rect.Width, rect.Height));
		} 


		public void Draw(RenderWindow window)
		{
			if (mouseDown == false) {
				shadowRect.Size = new Vector2f (shadowRect.Texture.Size.X,shadowRect.Texture.Size.Y);
				shadowRect.Position = new Vector2f (rect.X - 15f, rect.Y - 15f);
				window.Draw (shadowRect);
			}


			mainRect.FillColor = buttonColor;
			mainRect.Position = new Vector2f (rect.X, rect.Y);
			mainRect.Size = new Vector2f (rect.Width, rect.Height);
			window.Draw (mainRect);


			Text txt = new Text (text, Globals.mainFont, 32);
			//byte halfCount = (byte)((byte)text.Length / 2);
			//Vector2f offset = txt.FindCharacterPos ((uint)halfCount);
			txt.Scale = new Vector2f (0.5f,0.5f);
			//txt.Position = new Vector2f (rect.X + rect.Width/3f,rect.Y + rect.Height/4f);
			txt.Position = new Vector2f (rect.X + rect.Width - xOffset,rect.Y + rect.Height/4f);
			window.Draw (txt);


			if (mouseDown == true) {
				innerShadowRect.Size = new Vector2f (innerShadowRect.Texture.Size.X,innerShadowRect.Texture.Size.Y);
				innerShadowRect.Position = new Vector2f (rect.X, rect.Y);
				window.Draw (innerShadowRect);
			}

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

		public virtual void Update()
		{
			
		}


	}
}

