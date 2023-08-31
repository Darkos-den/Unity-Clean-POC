using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CellController : ICellController {

    private ISessionUseCase _useCase;

    private int _x;
    private int _y;

    private Turn? _boardItem;
    private Turn _turn;

    private UnityAction<Color> _onColorChanged;
    private UnityAction<Turn?> _onBoardItemChanged;

    private bool _isActive = true;

    [Inject]
    public CellController(ISessionUseCase useCase) {
        _useCase = useCase;

        useCase.ObserveTurnState(OnTurnChanged);
        useCase.ObserveUserWin(OnUserWin);
        useCase.ObserveResetGame(OnResetGame);
    }

    private Color ProcessColor() {
        Color color = Color.black;
        if (_boardItem == null) {
            color.a = 0.5f;
        }
        return color;
    }

    private void OnTurnChanged(Turn turn) {
        _turn = turn;
    }

    private void OnUserWin(Turn? turn) {
        if(turn != null) {
            _isActive = false;
        }
    }

    private void OnResetGame() {
        _isActive = true;
        _boardItem = null;
        _onBoardItemChanged?.Invoke(null);
        _onColorChanged?.Invoke(ProcessColor());
    }

    public void ApplyPosition(int x, int y) {
        _x = x;
        _y = y;
    }

    public void HandleMouseEnter() {
        if(_boardItem == null && _isActive) {
            if(_turn == Turn.Nolik) {
                _onBoardItemChanged?.Invoke(Turn.Nolik);
            } else {
                _onBoardItemChanged?.Invoke(Turn.Krestik);
            }
        }
    }

    public void HandleMouseExit() {
        if (_boardItem == null) {
            _onBoardItemChanged?.Invoke(null);
        }
    }

    public void ObserveColor(UnityAction<Color> observer) {
        _onColorChanged += observer;
        observer.Invoke(ProcessColor());
    }

    public void RemoveObserver(UnityAction<Color> observer) {
        _onColorChanged -= observer;

        _useCase.RemoveObserver(OnTurnChanged);
        _useCase.RemoveResetGameObserver(OnResetGame);
    }

    public void ObserveBoardItem(UnityAction<Turn?> observer) {
        _onBoardItemChanged += observer;
        observer.Invoke(_boardItem);
    }

    public void RemoveObserver(UnityAction<Turn?> observer) {
        _onBoardItemChanged -= observer;
    }

    public void HandleClick() {
        if(_boardItem == null && _isActive) {
            if (_turn == Turn.Nolik) {
                _boardItem = Turn.Nolik;
            } else {
                _boardItem = Turn.Krestik;
            }
            _useCase.AddBoardItem(_x, _y, (Turn)_boardItem);
            _onColorChanged.Invoke(ProcessColor());
            _onBoardItemChanged?.Invoke(_boardItem);
        }
    }
}
