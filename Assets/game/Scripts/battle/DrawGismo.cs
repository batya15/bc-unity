using UnityEngine;
using System.Linq;
using System.Collections;
using bc.battle; 

public class DrawGismo : MonoBehaviour {

	public LevelManager manager;

	void Awake() {
		manager = GetComponent<LevelManager> ();
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		for (int x = 0; x < manager.CrossPoints._points.GetLength(0); x++) {
			for (int y = 0; y < manager.CrossPoints._points.GetLength (1); y++) {
				if (manager.CrossPoints._points [x, y] != null) {
					Gizmos.DrawSphere (manager.CrossPoints._points [x, y].position, 0.1f);
				} else {
					Debug.Log (x + "-" + y);
				}

			
			}
		}
	}

}