using UnityEngine;
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

			for (int y = 0; y < map.rows.Length; y++) {
                for (int x = 0; x < map.rows[y].cells.Length; x++) {
					GameObject cell = factory.GetCell(map.rows[y].cells[x].type);
                    cell.name = y + " - " + x;
                    cell.transform.SetParent(transform);
                    cell.transform.position = new Vector2(x * 1.0f, y * -1.0f);
				}
            }

			CrossPoints = new CrossPoints (map);

            GameObject tank = factory.GetTank();
            tank.transform.SetParent(transform);
            tank.transform.position = CrossPoints._points[3, 2].position;
        }

	}
}
