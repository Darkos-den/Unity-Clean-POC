using UnityEngine;
using Zenject;

public class CellBehaviour : MonoBehaviour {

    [SerializeField] private SpriteRenderer _image;
    [SerializeField] private Sprite _spriteKrestiki;
    [SerializeField] private Sprite _spriteNoliki;

    [SerializeField] private int _x;
    [SerializeField] private int _y;

    [Inject] private ICellController _controller;

    void Awake()
    {
        _controller.ApplyPosition(_x, _y);
        _controller.ObserveColor(OnColorchanged);
        _controller.ObserveBoardItem(OnBoardItemChanged);
    }

    private void OnDestroy() {
        _controller.RemoveObserver(OnColorchanged);
        _controller.RemoveObserver(OnBoardItemChanged);
    }


    private void OnMouseEnter() {
        _controller.HandleMouseEnter();
    }

    private void OnMouseExit() {
        _controller.HandleMouseExit();
    }

    private void OnMouseUpAsButton() {
        _controller.HandleClick();
    }

    private void OnColorchanged(Color color) {
        _image.color = color;
    }

    private void OnBoardItemChanged(BoardItem? item) {
        if(item == BoardItem.Krestik) {
            _image.sprite = _spriteKrestiki;
        } else if(item == BoardItem.Nolik) {
            _image.sprite = _spriteNoliki;
        } else {
            _image.sprite = null;
        }
    }
}
