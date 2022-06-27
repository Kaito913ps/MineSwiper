using UnityEngine;
using UnityEngine.UI;


public class Minesweeper : MonoBehaviour
{
    [SerializeField]
    private int _rows = 1;

    [SerializeField]
    private int _colums = 1;

    [SerializeField]
    private int _mineCount = 1;

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    private Cell _cellPrefab = null;

    private void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _colums;

        var _cells = new Cell[_rows, _colums];
        var parent = _gridLayoutGroup.gameObject.transform;
        for(var r = 0; r < _rows; r++)
        {
            for(var c = 0; c < _colums; c++)
            {
                var cell = Instantiate(_cellPrefab);
                cell.transform.SetParent(parent);
                _cells[r, c] = cell;
            }
        }

        for(var i = 0; i < _mineCount; i++)
        {
            var r = Random.Range(0, _rows);
            var c = Random.Range(0, _colums);
            var cell = _cells[r, c];
            cell.CellState = CellState.Mine;
        }
    }
}
