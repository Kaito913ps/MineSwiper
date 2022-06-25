using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewBehaviourScript3 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int _rows = 5;

    [SerializeField]
    private int _columns = 5;

    private GameObject[,] _cells; // 見た目
    private bool[,] _lights; // 内部データ

    private void Start()
    {
        // FixedColumnCount 前提
        var layout = GetComponent<GridLayoutGroup>();
        layout.constraintCount = _columns;

        _cells = CreateCells(_rows, _columns);
        _lights = CreateLights(_rows, _columns);
        UpdateCells();
    }

    /// <summary>
    /// 2次元照明データの生成。
    /// </summary>
    /// <param name="rows">行数。</param>
    /// <param name="columns">列数。</param>
    /// <returns>照明データ。</returns>
    private bool[,] CreateLights(int rows, int columns)
    {
        var lights = new bool[rows, columns];
        for (var r = 0; r < lights.GetLength(0); r++)
        {
            for (var c = 0; c < lights.GetLength(1); c++)
            {
                lights[r, c] = Random.value < 0.5;
            }
        }
        return lights;
    }


    /// <summary>
    /// 2次元照明ビュー（GameObject）の生成。
    /// </summary>
    /// <param name="rows">行数。</param>
    /// <param name="columns">列数。</param>
    /// <returns>照明ビュー。</returns>
    private GameObject[,] CreateCells(int rows, int columns)
    {
        var cells = new GameObject[rows, columns];
        for (var r = 0; r < cells.GetLength(0); r++)
        {
            for (var c = 0; c < cells.GetLength(1); c++)
            {
                var cell = new GameObject($"Cell({r}, {c})");
                cell.transform.parent = transform;
                cell.AddComponent<Image>();
                cells[r, c] = cell;
            }
        }
        return cells;
    }

    /// <summary>
    /// 指定した照明データがすべて点灯または消灯しているかどうか。
    /// </summary>
    /// <param name="lights">照明データ。</param>
    /// <param name="isOn">
    /// すべてが点灯しているかどうかを調べるなら true。
    /// すべてが消灯しているかどうかを調べるなら false。</param>
    /// <returns>照明データがすべて同じ状態なら true。そうでなければ false。</returns>
    private bool All(bool[,] lights, bool isOn)
    {
        for (var r = 0; r < lights.GetLength(0); r++)
        {
            for (var c = 0; c < lights.GetLength(1); c++)
            {
                var light = lights[r, c];
                if (light != isOn) { return false; }
            }
        }

        return true;
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
        if (All(_lights, false))
        {
            Debug.Log("全部消灯");
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