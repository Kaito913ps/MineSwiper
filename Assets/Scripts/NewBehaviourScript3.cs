using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewBehaviourScript3 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int _rows = 5;

    [SerializeField]
    private int _columns = 5;

    private GameObject[,] _cells; // ������
    private bool[,] _lights; // �����f�[�^

    private void Start()
    {
        // FixedColumnCount �O��
        var layout = GetComponent<GridLayoutGroup>();
        layout.constraintCount = _columns;

        _cells = CreateCells(_rows, _columns);
        _lights = CreateLights(_rows, _columns);
        UpdateCells();
    }

    /// <summary>
    /// 2�����Ɩ��f�[�^�̐����B
    /// </summary>
    /// <param name="rows">�s���B</param>
    /// <param name="columns">�񐔁B</param>
    /// <returns>�Ɩ��f�[�^�B</returns>
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
    /// 2�����Ɩ��r���[�iGameObject�j�̐����B
    /// </summary>
    /// <param name="rows">�s���B</param>
    /// <param name="columns">�񐔁B</param>
    /// <returns>�Ɩ��r���[�B</returns>
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
    /// �w�肵���Ɩ��f�[�^�����ׂē_���܂��͏������Ă��邩�ǂ����B
    /// </summary>
    /// <param name="lights">�Ɩ��f�[�^�B</param>
    /// <param name="isOn">
    /// ���ׂĂ��_�����Ă��邩�ǂ����𒲂ׂ�Ȃ� true�B
    /// ���ׂĂ��������Ă��邩�ǂ����𒲂ׂ�Ȃ� false�B</param>
    /// <returns>�Ɩ��f�[�^�����ׂē�����ԂȂ� true�B�����łȂ���� false�B</returns>
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

        // �N���b�N���ꂽ�Z���̍s�ԍ��Ɨ�ԍ��擾
        if (GetCellPosition(cell) is { } pt)
        {
            Debug.Log($"Selected: {pt.Row}, {pt.Column}");
            ToggleLight(pt.Row, pt.Column);
            UpdateCells();
        }
        if (All(_lights, false))
        {
            Debug.Log("�S������");
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