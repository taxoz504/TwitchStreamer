using System;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public class QualityBtn : Button
	{


		public QualityBtn () : base("Quality", 12, 183,250,41)
		{
			base.xOffset = 152;


			base.shadowRect = new RectangleShape ( new Vector2f(base.rect.Width +15+15,base.rect.Height +15+15));
			base.shadowRect.Texture = new Texture ("Resources/Shadow2.png");

			base.innerShadowRect = new RectangleShape ( new Vector2f(base.rect.Width, base.rect.Height));
			base.innerShadowRect.Texture = new Texture ("Resources/InnerShadow2.png");

			Globals.points.Add ("qualityBtn", new Vector2f(base.rect.X, base.rect.Y));
			Form.AnimatePos ("qualityBtnPoint", true, new Vector2f (-base.rect.Width - 50f, base.rect.Y), new Vector2f (base.rect.X,base.rect.Y), 3f);

		}

		public override void Pressed()
		{
			//Globals.MainForm.Close ();
			//Globals.shouldClose = true;

			if (Globals.points["mainPage"].X == 0) {
				
				//Form.AnimatePos ("mainPage", true, new Vector2f(Globals.points["mainPage"].X,0), new Vector2f(-Globals.width - 1,0), 1.5f);
				Form.AnimatePos ("mainPage", true, new Vector2f(Globals.points["mainPage"].X,0), new Vector2f(Globals.width + 1,0), 1.5f);
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
			Globals.lockedControl = "";
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
			base.rect.X = Globals.points ["qualityBtn"].X;
			base.rect.Y = Globals.points ["qualityBtn"].Y;
		}

	}
}

