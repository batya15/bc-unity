using UnityEngine;
using System.Linq;
using System.Collections;
using bc.battle; 

public class DrawGismo : MonoBehaviour {

	LevelManager manager;
	[SerializeField]
	int X = 2;
	[SerializeField]
	int Y = 2;

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

		Gizmos.color = Color.white;

		CrossPoints.Point p = manager.CrossPoints._points [X, Y];
        Gizmos.DrawSphere(p.position, 0.1f);

		Gizmos.color = Color.blue;
		Gizmos.DrawLine (p.position, p.UpLeft.transform.position);
		if (p.LeftCross != null) {
            Gizmos.DrawSphere(p.LeftCross.position, 0.1f);
        }

        Gizmos.color = Color.yellow;
		Gizmos.DrawLine (p.position, p.UpRight.transform.position);
        if (p.RightCross != null)
        {
            Gizmos.DrawSphere(p.RightCross.position, 0.1f);
        }

        Gizmos.color = Color.green;
		Gizmos.DrawLine (p.position, p.DownLeft.transform.position);
		if (p.UpCross != null)
        {
            Gizmos.DrawSphere(p.UpCross.position, 0.1f);
        }

        Gizmos.color = Color.cyan;
		Gizmos.DrawLine (p.position, p.DownRight.transform.position);
		if (p.DownCross != null)
        {
            Gizmos.DrawSphere(p.DownCross.position, 0.1f);
        }
        
    }

}