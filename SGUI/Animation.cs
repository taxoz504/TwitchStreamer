using System;
using SFML.Graphics;
using SFML.System;

namespace SGUI
{
	public static class Animation
	{
		public static void animatePosition(string shapeKey, byte layer , Vector2f start, Vector2f stop, float time)
		{
			//Difference
			Vector2f delta = new Vector2f (stop.X - start.X, stop.Y - start.Y);

			Vector2f step = new Vector2f (delta.X/100f, delta.Y/100f);

			Clock clock = new Clock ();
			while (clock.ElapsedTime.AsSeconds() <= time) {

				//Percent of time taken
				float ttp = (clock.ElapsedTime.AsSeconds () * 100f) / time;
				ttp /= 100f;

				float y = 1f + ((ttp - 1) * (ttp - 1) * (ttp - 1));

				float stepsToAdd = y * 100f;

				Globals.rects [layer][shapeKey].Position = new Vector2f (
					start.X + stepsToAdd*step.X,//X
					start.Y + stepsToAdd*step.Y//Y
				);


			}
		}


		public static void animatePosition(string textKey , Vector2f start, Vector2f stop, float time)
		{
			//Difference
			Vector2f delta = new Vector2f (stop.X - start.X, stop.Y - start.Y);

			Vector2f step = new Vector2f (delta.X/100f, delta.Y/100f);

			Clock clock = new Clock ();
			while (clock.ElapsedTime.AsSeconds() <= time) {

				//Percent of time taken
				float ttp = (clock.ElapsedTime.AsSeconds () * 100f) / time;
				ttp /= 100f;

				float y = 1f + ((ttp - 1) * (ttp - 1) * (ttp - 1));

				float stepsToAdd = y * 100f;

				Globals.texts[textKey].Position = new Vector2f (
					start.X + stepsToAdd*step.X,//X
					start.Y + stepsToAdd*step.Y//Y
				);


			}
		}


		public static void animatePosition(string pointKey, bool rnd , Vector2f start, Vector2f stop, float time)
		{
			//Difference
			Vector2f delta = new Vector2f (stop.X - start.X, stop.Y - start.Y);

			Vector2f step = new Vector2f (delta.X/100f, delta.Y/100f);

			/*
			while (Globals.pageTurning == true) {
				
			}

			Globals.pageTurning = true;
*/

			Clock clock = new Clock ();
			while (clock.ElapsedTime.AsSeconds() <= time) {

				//Percent of time taken
				float ttp = (clock.ElapsedTime.AsSeconds () * 100f) / time;
				ttp /= 100f;

				float y = 1f + ((ttp - 1) * (ttp - 1) * (ttp - 1));

				float stepsToAdd = y * 100f;

				Globals.points[pointKey] = new Vector2f (
					start.X + stepsToAdd*step.X,//X
					start.Y + stepsToAdd*step.Y//Y
				);


			}


			//Globals.pageTurning = false;

		}


	}
}

