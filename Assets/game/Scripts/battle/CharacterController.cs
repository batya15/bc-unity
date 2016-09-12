using UnityEngine;
using System.Collections;
using bc.battle;

public class CharacterController : MonoBehaviour {

	public enum Direction {
		IDLE = 0,
		UP = 1,
		DOWN = 2,
		LEFT = 3,
		RIGHT = 4
	}

    public CrossPoints.Point point;

	public float speed = 1.0f;
	float delta = 0;
	Direction direction = Direction.IDLE;
	Direction lastDirectionType = Direction.IDLE;

    void Start() {
        transform.position = point.position;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(point.position, 0.2f);
    }

        void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			direction = Direction.UP;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			direction = Direction.DOWN;	
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			direction = Direction.LEFT;	
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			direction = Direction.RIGHT;	
		} else {
			direction = Direction.IDLE;
		}

        if (direction != Direction.IDLE) {
            if (direction != lastDirectionType)
            {
                delta = 0;
            }
            lastDirectionType = direction;
            float d = Time.deltaTime * speed; 
			delta = delta + d;
            Vector2 newPos = point.position;
			switch (direction) {
			case Direction.DOWN:
                    if (point.DownCross != null) {
                        newPos += new Vector2(0, -delta);
                    } else {
                        delta = 0;
                    }
                    break;
			case Direction.UP:
                    if (point.UpCross != null) {
                        newPos += new Vector2(0, delta);
                    } else {
                        delta = 0;
                    }
                    break;
			case Direction.RIGHT:
                    if (point.RightCross != null) {
                        newPos += new Vector2(delta, 0);
                    } else {
                        delta = 0;
                    }
                    break;
			case Direction.LEFT:
                    if (point.LeftCross != null) {
                        newPos += new Vector2(-delta, 0);
                    } else {
                        delta = 0;
                    }			
				break;
			}
			if (delta >= 1.0f) {
                switch (direction)
                {
                    case Direction.DOWN:
                        point = point.DownCross;
                        break;
                    case Direction.UP:
                        point = point.UpCross;
                        break;
                    case Direction.RIGHT:
                        point = point.RightCross;
                        break;
                    case Direction.LEFT:
                        point = point.LeftCross;
                        break;
                }
                delta -= 1.0f;
            }
			transform.position = newPos;
		}
    }
}
