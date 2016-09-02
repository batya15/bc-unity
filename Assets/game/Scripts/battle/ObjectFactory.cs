using UnityEngine;
using System.Collections;

namespace bc.battle {
    public class ObjectFactory : MonoBehaviour {

        [SerializeField]
        GameObject[] cells = null;

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

    }
}
