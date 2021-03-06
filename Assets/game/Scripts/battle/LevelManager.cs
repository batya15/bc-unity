﻿using UnityEngine;
using System.Collections;

namespace bc.battle {
	public class LevelManager : MonoBehaviour {
		
		public CrossPoints CrossPoints;

		ObjectFactory factory;

        void Awake()
        {
            factory = GetComponent<ObjectFactory>();
        }

        void Start() {
            MapDescriptor map = new MapDescriptor("1");
			Cell[,] gridState = new Cell[map.rows[0].cells.Length, map.rows.Length];

			for (int y = 0; y < map.rows.Length; y++) {
                for (int x = 0; x < map.rows[y].cells.Length; x++) {
					GameObject cell = factory.GetCell(map.rows[y].cells[x].type);
                    cell.name = y + " - " + x;
                    cell.transform.SetParent(transform);
                    cell.transform.position = new Vector2(x * 1.0f, y * -1.0f);
					gridState [x, y] = cell.GetComponent<Cell> ();
				}
            }

			CrossPoints = new CrossPoints (map, gridState);

            GameObject tank = factory.GetTank();
            tank.transform.SetParent(transform);
            tank.GetComponent<CharacterController>().point = CrossPoints._points[3, 2];
        }

	}
}
