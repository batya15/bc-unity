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
			public Point UpCross = null;
			public Point DownCross = null;
			public Point LeftCross = null;
			public Point RightCross = null;	
			public Cell UpLeft = null;
			public Cell UpRight = null;
			public Cell DownLeft = null;
			public Cell DownRight = null;
		}

		public Point[,] _points;

		public CrossPoints(MapDescriptor map, Cell[,] gridState) {
			_points = new Point[map.rows [0].cells.Length - 1, map.rows.Length - 1];
			for (int i = 0; i < map.rows.Length - 1; i++) {
				for (int e = 0; e < map.rows[i].cells.Length - 1; e++) {
					_points [e, i] = new Point () {
						x = e,
						y = i
					};
				}
			}

            for (int x = 0; x < _points.GetLength(0); x++)
            {
                for (int y = 0; y < _points.GetLength(1); y++)
                {
                    if (y + 1 < _points.GetLength(1)) {
                        _points[x, y].DownCross = _points[x, y + 1];
                    }
                    if (y - 1 >= 0)
                    {
                        _points[x, y].UpCross = _points[x, y - 1];
                    }
                    if (x - 1 >= 0)
                    {
                        _points[x, y].LeftCross = _points[x - 1, y];
                    }
                    if (x + 1 < _points.GetLength(0))
                    {
                        _points[x, y].RightCross = _points[x + 1, y];
                    }

					_points [x, y].UpLeft = gridState [x, y];
					_points [x, y].UpRight = gridState [x + 1, y];
					_points [x, y].DownLeft = gridState [x, y + 1];
					_points [x, y].DownRight = gridState [x + 1, y + 1];
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

