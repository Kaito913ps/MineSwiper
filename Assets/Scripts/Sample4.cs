using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sample4 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int _row = 5;

    [SerializeField]
    private int _column = 5;

    private GameObject[,] _cells; // 見た目
    private bool[,] _lights; // 内部データ

    private void Start()
    {
        _cells = new GameObject[_row, _column];
        _lights = new bool[_row, _column];

        // FixedColumnCount 前提
        var layout = GetComponent<GridLayoutGroup>();
        layout.constraintCount = _column;

        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = new GameObject($"Cell({r}, {c})");
                cell.transform.parent = transform;
                cell.AddComponent<Image>();
                _cells[r, c] = cell;
            }
        }

        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                _lights[r, c] = Random.value < 0.5;
            }
        }
        UpdateCells();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var cell = eventData.pointerCurrentRaycast.gameObject;

        // クリックされたセルの行番号と列番号取得
        if (GetCellPosition(cell) is { } pt)
        {
            Debug.Log($"Selected: {pt.Row}, {pt.Column}");
            ToggleLight(pt.Row, pt.Column);
            UpdateCells();
        }
    }

    private void ToggleLight(int row, int column)
    {
        _lights[row, column] = !_lights[row, column];
    }

    private void UpdateCells()
    {
        for (var r = 0; r < _lights.GetLength(0); r++)
        {
            for (var c = 0; c < _lights.GetLength(1); c++)
            {
                var light = _lights[r, c];
                var cell = _cells[r, c];
                var image = cell.GetComponent<Image>();
                image.color = light ? Color.white : Color.black;
            }
        }
    }

    private (int Row, int Column)? GetCellPosition(GameObject cell)
    {
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                if (cell == _cells[r, c])
                {
                    return (r, c);
                }
            }
        }
        return null;
    }
}