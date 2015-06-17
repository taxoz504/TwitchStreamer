using System;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public class ExitBtn : Button
	{
		public ExitBtn () : base("Exit", 420, 292,95,41)
		{
			base.shadowRect = new RectangleShape ( new Vector2f(95+15+15, 41+15+15));
			base.shadowRect.Texture = new Texture ("Resources/Shadow1.png");
		}

		public override void Pressed()
		{

		}

		public override void MouseOver()
		{

		}

		public override void MouseDown()
		{

		}

		public override void MouseEnter()
		{

		}

		public override void MouseLeave()
		{

		}

	}
}

