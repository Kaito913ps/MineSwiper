using UnityEngine;
using UnityEngine.UI;

public class Minesweeper : MonoBehaviour
{
    [SerializeField]
    privateÅ@int _rows = 10;

    [SerializeField]
    private int _colums = 10;
    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    private Cell _cellPrefab = null;

    [SerializeField]
    private int _mineCount = 10;

    private Cell[,] _cells;

    private void Start()
    {
        _gridLayoutGroup.constraint
            = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _colums;

        _cells = new Cell[_rows, _colums];

        for (var r = 0; r < 10; r++)
        {
            for (var c = 0; c < 10; c++)
            {
                var cell = Instantiate(_cellPrefab, _gridLayoutGroup.transform);
                _cells[r, c] = cell;
            }
        }

        for(var i = 0; i <  _mineCount; i++)
        {
            var r = Random.Range(0, _rows);
            var c = Random.Range(0, _colums); 
        }
    }
}