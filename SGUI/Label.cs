using System;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public class Label
	{
		Text txt;
		string point = "";

		public Label (string text, uint charSize,bool bold, string posPointName)
		{
			txt = new Text (text, Globals.mainFont, charSize*2);

			if (bold) {
				txt.Style = Text.Styles.Bold;
			}

			txt.Scale = new Vector2f (0.5f, 0.5f);

			point = posPointName;
		}

		public void Draw(RenderWindow window)
		{
			txt.Position = Globals.points [point] + Globals.points["mainPage"];


			//txt.Position.Y = Globals.points [point].Y + Globals.points["mainPage"].Y;

			window.Draw (txt);

		}

			
	}
}

