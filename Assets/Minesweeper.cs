using UnityEngine;
using UnityEngine.UI;

public class Minesweeper : MonoBehaviour
{
    [SerializeField]
    private int _rows = 1;

    [SerializeField]
    private int _colums = 1;

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    private Cell _cellPrefab = null;

    private void Start()
    {
        var parent = _gridLayoutGroup.gameObject.transform;
        for(var r = 0; r < _rows; r++)
        {
            for(var c = 0; c < _colums; c++)
            {
                var cell = Instantiate(_cellPrefab);
                cell.transform.SetParent(parent);
            }
        }
    }
}
