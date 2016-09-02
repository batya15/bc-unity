using UnityEngine;

namespace bc.battle
{
	public class CrossPoints
	{
		public class Point {
			Cell[] links;
			public int x;
			public int y;
			public Vector2 position {
				get { 
					return new Vector2 (x + 0.5f, -y - 0.5f);
				}
			}
			public Point UpCross;
			public Point DownCross;
			public Point LeftCross;
			public Point RightCross;	
		}

		public Point[,] _points;

		public CrossPoints(MapDescriptor map) {
			_points = new Point[map.rows [0].cells.Length - 1, map.rows.Length - 1];
			for (int i = 0; i < map.rows.Length - 1; i++) {
				for (int e = 0; e < map.rows[i].cells.Length - 1; e++) {
					_points [e, i] = new Point () {
						x = e,
						y = i
					};
				}
			}	
		}

		public Point this[int x, int y]
		{
			get {
				return _points[x, y];
			}
		}



	}
}

