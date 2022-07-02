using UnityEngine;
using UnityEngine.UI;

public enum CellState
{
    None = 0, // 空セル

    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,

    Mine = -1, // 地雷
}

public class Cell : MonoBehaviour
{
    
    [SerializeField]
    //text
    private Text _view = null;

   
    [SerializeField]
    //cellの種類
    private CellState _cellState = CellState.None;

    //cellのプロパティ
    public CellState CellState
    {
        get => _cellState;
        set
        {
            _cellState = value;
            OnCellStateChanged(value);
        }
    }

    //地雷あるかどうか
    public bool IsMine => CellState == CellState.Mine;

    
    //拡張子
    private void OnValidate()
    {
        OnCellStateChanged(CellState);
    }

    //cellのチェンジ
    private void OnCellStateChanged(CellState value)
    {
        if (_view == null) { return; }

        if (_cellState == CellState.Mine)
        {
            _view.text = "X";
            _view.color = Color.red;
        }
        else if (_cellState == CellState.None)
        {
            _view.text = "";
        }
        else
        {
            _view.text = ((int)_cellState).ToString();
            _view.color = Color.blue;
        }
    }
}