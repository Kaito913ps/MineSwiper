using UnityEngine;
using UnityEngine.UI;


public enum CellState
{
    None = 0, // ‹óƒZƒ‹

    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,

    Mine = -1, // ’n—‹
}
public class cell : MonoBehaviour
{
    [SerializeField]
    private Text _view = null;

    [SerializeField]
    private CellState _cellState = CellState.None;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
