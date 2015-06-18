using System;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public class WatchBtn : Button
	{


		public WatchBtn () : base("Watch", 218, 292,95,41)
		{
			base.xOffset = 75;

			base.shadowRect = new RectangleShape ( new Vector2f(base.rect.Width +15+15,base.rect.Height +15+15));
			base.shadowRect.Texture = new Texture ("Resources/Shadow1.png");

			base.innerShadowRect = new RectangleShape ( new Vector2f(base.rect.Width, base.rect.Height));
			base.innerShadowRect.Texture = new Texture ("Resources/InnerShadow1.png");

			Globals.points.Add ("watchBtn", new Vector2f(base.rect.X, base.rect.Y));
			Form.AnimatePos ("watchBtn", true, new Vector2f (base.rect.X, Globals.height + base.rect.Height), new Vector2f (base.rect.X,base.rect.Y), 2f);

		}

		public override void Pressed()
		{
			//Globals.MainForm.Close ();
			if (Globals.lockedControl == "watchBtn") {
				Globals.shouldClose = true;
				
			}


			mouseDown = false;

		}

		public override void MouseOver()
		{
			base.buttonColor = Globals.TwitchPurple;
		}

		public override void MouseDown()
		{
			base.mouseDown = true;
			base.buttonColor = Globals.ButtonDownColor;
			Globals.lockedControl = "watchBtn";
		}

		public override void MouseEnter()
		{

		}

		public override void MouseLeave()
		{
			base.buttonColor = Globals.ButtonColor;
			base.mouseDown = false;
		}

		public override void Update()
		{
			base.rect.X = Globals.points ["watchBtn"].X;
			base.rect.Y = Globals.points ["watchBtn"].Y;
		}

	}
}

