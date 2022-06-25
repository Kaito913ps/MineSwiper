using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private int _count = 5;

    private GameObject[] _cells;
    private int _selectedIndex;
    private void Start()
    {
        _cells = new GameObject[_count];
        for (var i = 0; i < _cells.Length; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;

            obj.AddComponent<Image>();
            _cells[i] = obj;
        }
        OnselectedChanged();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {
            _selectedIndex--;
            OnselectedChanged();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            _selectedIndex++;
            OnselectedChanged();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var cell = _cells[_selectedIndex];
            Destroy(cell);
            OnselectedChanged();
        }
    }
    private void OnselectedChanged() 
    { 
        for(var i = 0; i < _cells.Length; i++)
        {
            var cell = _cells[i];
            if (!cell) { continue; } //Destory済なら無視

            var image = cell.GetComponent<Image>();

            if(i == _selectedIndex)
            {
                image.color = Color.red;
            }
            else { image.color = Color.white; }
        }
    }
}