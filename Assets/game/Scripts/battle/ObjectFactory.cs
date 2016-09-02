using UnityEngine;
using System.Collections;

namespace bc.battle {
    public class ObjectFactory : MonoBehaviour {

        [SerializeField]
        GameObject[] cells = null;

        [SerializeField]
        GameObject[] tanks = null;

        public GameObject GetCell(CellType type) {
            GameObject result = null;
            foreach (GameObject cell in cells) {
                if (cell.GetComponent<Cell>().type == type) {
                    result = cell;
                    break;
                }
            }
            return Instantiate(result);
        }

         public GameObject GetTank() {
            return Instantiate(tanks[0]);
        }

    }
}
