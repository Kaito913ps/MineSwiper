using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class sample3 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Range(0, 10)]
    private int _row = 5;

    [SerializeField, Range(0, 10)]
    private int _column = 5;
    private GameObject[,] _cells;
    
    void Start()
    {
        _cells = new GameObject[5, 5];
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for(var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = new GameObject($"Cell({r}, {c})");
                cell.transform.parent = transform;
                cell.AddComponent<Image>();
                _cells[r,c] = cell;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var cell = eventData.pointerCurrentRaycast.gameObject;
        var selectedRow = 0;
        var selectedColumn = 0;

        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                if (cell == _cells[r, c])
                {
                    selectedRow = r;
                    selectedColumn = c;
                    break;
                }
            }
        }
        Debug.Log($"Selected ({selectedRow},{selectedColumn}");


        


        // クリックされたセルとその周囲の色を反転する
        // インデックスの境界チェックしていない（例外発生する）
        SwaapCell(cell);
        SwaapCell(_cells[selectedRow - 1, selectedColumn]);
        SwaapCell(_cells[selectedRow + 1, selectedColumn]);
        SwaapCell(_cells[selectedRow , selectedColumn-1]);
        SwaapCell(_cells[selectedRow, selectedColumn +1]);

        //PointerEventData hitUp = cell.eventData.pointerCurrentRaycast.gameObject(gameObject.transform.position + Vector3.up, Vector2.up, 0.1f);
    }

    /// <summary>
    /// 指定したセルの色を反転する。
    /// <see cref=""/>
    /// </summary>
    /// <param name="cell">色を反転させる対象のセル</param>
    private static void SwaapCell(GameObject cell)
    {
        var image = cell.GetComponent<Image>();
        if (image.color == Color.white)
        {
            image.color = Color.black;
        }
        else if (image.color == Color.black)
        {
            image.color = Color.white;
        }
    }


}
