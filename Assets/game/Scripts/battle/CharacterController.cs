using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public enum Direction {
		IDLE = 0,
		UP = 1,
		DOWN = 2,
		LEFT = 3,
		RIGHT = 4
	}

	public float speed = 1.0f;
	float delta = 0;
	Direction direction = Direction.IDLE;
	Direction lastDirectionType = Direction.IDLE;

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


		if (direction != lastDirectionType) {
			delta = 0;
		}
		if (direction != Direction.IDLE) {
			float d = Time.deltaTime * speed; 
			delta += d;
			Vector2 newPos = transform.position;
			switch (direction) {
			case Direction.DOWN:
				newPos.Set (newPos.x, newPos.y - d);
				break;
			case Direction.UP:
				newPos.Set (newPos.x, newPos.y + d);
				break;
			case Direction.RIGHT:
				newPos.Set (newPos.x + d, newPos.y);
				break;
			case Direction.LEFT:
				newPos.Set (newPos.x - d, newPos.y);
				break;
			}

			if (delta >= 1.0f) {
				Debug.Log ("GO TO");
			}
			transform.position = newPos;
		}
    }
}
