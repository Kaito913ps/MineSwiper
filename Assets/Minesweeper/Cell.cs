using UnityEngine;
using UnityEngine.UI;

public enum CellState
{
    None = 0, // ��Z��

    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,

    Mine = -1, // �n��
}

public class Cell : MonoBehaviour
{
    
    [SerializeField]
    //text
    private Text _view = null;

   
    [SerializeField]
    //cell�̎��
    private CellState _cellState = CellState.None;

    //cell�̃v���p�e�B
    public CellState CellState
    {
        get => _cellState;
        set
        {
            _cellState = value;
            OnCellStateChanged(value);
        }
    }

    //�n�����邩�ǂ���
    public bool IsMine => CellState == CellState.Mine;

    
    //�g���q
    private void OnValidate()
    {
        OnCellStateChanged(CellState);
    }

    //cell�̃`�F���W
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