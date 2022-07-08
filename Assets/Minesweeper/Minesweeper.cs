using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Minesweeper : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int _rows = 1;

    [SerializeField]
    private int _columns = 1;

    [SerializeField]
    private int _mineCount = 1;

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    private Cell _cellPrefab = null;

    Cell[,] _cells;

    private void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;

        var cells = new Cell[_rows, _columns];
        var parent = _gridLayoutGroup.transform;
        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                var cell = Instantiate(_cellPrefab);
                cell.transform.SetParent(parent);
                cells[r, c] = cell;
            }
        }

        // 地雷数がセル数より大きければ、セル数にキャップする
        //if (_mineCount > cells.Length)
        //{
        //    _mineCount = cells.Length;
        //}

        //var mc = _mineCount > cells.Length ? cells.Length : _mineCount;

        // 地雷数とセル数、より小さい値をループ条件に使う
        var mc = System.Math.Min(_mineCount, cells.Length);


        for (var i = 0; i < mc;)
        {
            var r = Random.Range(0, _rows);
            var c = Random.Range(0, _columns);
            var cell = cells[r, c];

            if (cell.CellState != CellState.Mine)
            {
                i++;
                cell.CellState = CellState.Mine;
            }


        }

        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                var cell = cells[r, c];
                cell.CellState = GetMineCount(r, c);
            }
        }
    }

    private CellState GetMineCount(int r, int c)
    {
        var cell = _cells[r, c];
        if (cell.IsMine)
        {
            // セル自身が地雷なので、数える必要がない
            return CellState.Mine;
        }

        var count = 0;

        if (r - 1 >= 0)
        {
            if (c - 1 >= 0 && _cells[r - 1, c - 1].IsMine) { count++; }
            if (_cells[r - 1, c].IsMine) { count++; }
            if (c + 1 < _columns && _cells[r - 1, c + 1].IsMine) { count++; }
        }
        if (c - 1 >= 0 && _cells[r, c - 1].IsMine) { count++; }
        if (c + 1 < _columns && _cells[r, c + 1].IsMine) { count++; }
        if (r + 1 < _rows)
        {
            if (c - 1 >= 0 && _cells[r + 1, c - 1].IsMine) { count++; }
            if (_cells[r + 1, c].IsMine) { count++; }
            if (c + 1 < _columns && _cells[r + 1, c + 1].IsMine) { count++; }
        }

        return (CellState)count;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var go = eventData.pointerCurrentRaycast.gameObject;

        var cell = go.GetComponent<Cell>();

        if (cell != null)
        {
            cell.Open();

            if (cell.IsMine)
            {
                // TO DO : ゲームオーバー
            }
        }
    }
}