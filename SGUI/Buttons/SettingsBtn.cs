using System;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public class SettingsBtn : Button
	{


		public SettingsBtn () : base("Settings", 12, 292,95,41)
		{
			base.xOffset = 82;

			base.shadowRect = new RectangleShape ( new Vector2f(base.rect.Width +15+15,base.rect.Height +15+15));
			base.shadowRect.Texture = new Texture ("Resources/Shadow1.png");

			base.innerShadowRect = new RectangleShape ( new Vector2f(base.rect.Width, base.rect.Height));
			base.innerShadowRect.Texture = new Texture ("Resources/InnerShadow1.png");

			Globals.points.Add ("settingsBtn", new Vector2f(base.rect.X, base.rect.Y));
			Form.AnimatePos ("settingsBtn", true, new Vector2f (-base.rect.Width - 20f, base.rect.Y), new Vector2f (base.rect.X,base.rect.Y), 2f);

		}

		public override void Pressed()
		{
			//Globals.MainForm.Close ();
			//Globals.shouldClose = true;

			Form.AnimatePos ("mainPage", true, new Vector2f(Globals.points["mainPage"].X,0), new Vector2f(-Globals.width - 1,0), 3f);


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
			base.rect.X = Globals.points ["settingsBtn"].X;
			base.rect.Y = Globals.points ["settingsBtn"].Y;
		}

	}
}

