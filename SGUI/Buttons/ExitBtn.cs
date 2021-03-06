﻿using System;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public class ExitBtn : Button
	{


		public ExitBtn () : base("Exit", 420, 292,95,41)
		{
			base.xOffset = 61;

			base.shadowRect = new RectangleShape ( new Vector2f(base.rect.Width +15+15,base.rect.Height +15+15));
			base.shadowRect.Texture = new Texture ("Resources/Shadow1.png");

			base.innerShadowRect = new RectangleShape ( new Vector2f(base.rect.Width, base.rect.Height));
			base.innerShadowRect.Texture = new Texture ("Resources/InnerShadow1.png");

			Globals.points.Add ("exitBtn", new Vector2f(base.rect.X, base.rect.Y));
			Form.AnimatePos ("exitBtn", true, new Vector2f (Globals.width + 20f, base.rect.Y), new Vector2f (base.rect.X,base.rect.Y), 2f);

		}

		public override void Pressed()
		{
			//Globals.MainForm.Close ();
			if (Globals.lockedControl == "exitBtn") {
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
			Globals.lockedControl = "exitBtn";
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
			base.rect.X = Globals.points ["exitBtn"].X;
			base.rect.Y = Globals.points ["exitBtn"].Y;
		}

	}
}

