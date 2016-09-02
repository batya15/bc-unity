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
       /* CrossPoints.Point p = manager.CrossPoints._points[6 , 4];
        Gizmos.DrawSphere(p.position, 0.1f);


        Gizmos.color = Color.blue;
        if (p.LeftCross != null) {
            Gizmos.DrawSphere(p.LeftCross.position, 0.1f);
        }

        Gizmos.color = Color.yellow;

        if (p.RightCross != null)
        {
            Gizmos.DrawSphere(p.RightCross.position, 0.1f);
        }
        Gizmos.color = Color.green;
        if (p.UpCross != null)
        {
            Gizmos.DrawSphere(p.UpCross.position, 0.1f);
        }
        Gizmos.color = Color.cyan;
        if (p.DownCross != null)
        {
            Gizmos.DrawSphere(p.DownCross.position, 0.1f);
        }
        */
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