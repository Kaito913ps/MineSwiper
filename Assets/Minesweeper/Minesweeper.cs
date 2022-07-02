using UnityEngine;
using UnityEngine.UI;
public class Minesweeper : MonoBehaviour
{
    [SerializeField]
    //縦列
    private int _rows = 1;
    public int Rows => _rows;

    [SerializeField]
    //横列
    private int _columns = 1;
    public int Columns => _columns;


    [SerializeField]
    //地雷
    private int MineCount = 1;

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    //cellのPrefab
    private Cell _cellPreafab = null;
    //cellの2重配列
    private Cell[,] _cells;

    private void Start()
    {
        InitializeCells();
        InitializeMine(MineCount);
        CalculateMine();
    }

    private void InitializeCells()
    {
        //クリア
        Clear();

        var parent = _gridLayoutGroup.gameObject.transform;

        _cells = new Cell[Rows, Columns];
        for (var r = 0; r < Rows; r++)
        {
            for(var c = 0; c < Columns; c++)
            {
                var cell = Instantiate(_cellPreafab);
                cell.transform.parent = parent;
                _cells[r, c] = cell;
            }
        }
    }

    private void InitializeMine(int count)
    {
        if(_cells.Length < count) { throw new System.InvalidOperationException(); }

        for(var i = 0; i < count; )
        {
            var r = Random.Range(0, Rows);
            var c = Random.Range(0, Columns);
            var cell =_cells[r, c];
            if(cell.CellState != CellState.Mine)
            {
                cell.CellState = CellState.Mine;
                i++;
            }
        }    
    }

    private void CalculateMine()
    {
        for(var r = 0; r < Rows; r++)
        {
            for(var c = 0; c < Columns; c++)
            {
                var cell = _cells[r, c];
                if (cell.IsMine) { continue; }

                var count = GetMineCount(r, c);
                cell.CellState = (CellState)count;
            }
        }
    }

    private int GetMineCount(int r, int c)
    {
        var count = 0;
        var top = r - 1;
        var bottom = r + 1;
        var left = c - 1;
        var right = c + 1;

        if(top >= 0)
        {
            if(left >= 0 && _cells[top, left].IsMine) { count++; }
            if (_cells[top,c].IsMine) { count++; }
            if(right < Columns && _cells[top,right].IsMine) { count++; }
        }
        if(left >= 0 && _cells[r, left].IsMine) { count++; }
        if(right < Columns && _cells[r, right].IsMine) { count++; }
        if(bottom < Rows)
        {
            if(left >= 0 && _cells[bottom, left].IsMine) { count++; }
            if (_cells[bottom, c].IsMine) { count++; }
            if(right < Columns && _cells[bottom, right].IsMine) { count++; }
        }
        return count;
    }

    private void Clear()
    {
        var parent = _gridLayoutGroup.gameObject.transform;
        foreach(Transform t in parent)
        {
            Destroy(t.gameObject);
        }
    }

    private void OnValidate()
    {
        if(_gridLayoutGroup != null)
        {
            _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _gridLayoutGroup.constraintCount = Columns;
        }
    }
}