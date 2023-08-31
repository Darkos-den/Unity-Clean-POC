using System;
using UnityEngine.Events;
using Zenject;

public class SessionUseCase: ISessionUseCase {

    private IBoardRepository _boardRepository;

    private UnityAction<Turn> _onTurnChanged;
    private UnityAction<Turn?> _onUserWin;
    private UnityAction _onResetGame;

    [Inject]
    public SessionUseCase(IBoardRepository boardRepository) {
        _boardRepository = boardRepository;
    }

    private bool CheckWinState(Turn item) {
        var indexs = _boardRepository.GetBoardItemIndexs(item);

        if(indexs.Contains(0) && indexs.Contains(1) && indexs.Contains(2)) {
            return true;
        }
        if (indexs.Contains(3) && indexs.Contains(4) && indexs.Contains(5)) {
            return true;
        }
        if (indexs.Contains(6) && indexs.Contains(7) && indexs.Contains(8)) {
            return true;
        }

        if (indexs.Contains(0) && indexs.Contains(3) && indexs.Contains(6)) {
            return true;
        }
        if (indexs.Contains(1) && indexs.Contains(4) && indexs.Contains(7)) {
            return true;
        }
        if (indexs.Contains(2) && indexs.Contains(5) && indexs.Contains(8)) {
            return true;
        }

        if (indexs.Contains(0) && indexs.Contains(4) && indexs.Contains(8)) {
            return true;
        }
        if (indexs.Contains(2) && indexs.Contains(4) && indexs.Contains(6)) {
            return true;
        }

        return false;
    }

    public void AddBoardItem(int x, int y, Turn item) {
        if(_boardRepository.GetBoardItem(x, y) == null) {
            _boardRepository.WriteBoardITem(x, y, item);

            Turn turn = _boardRepository.GetActiveTurn();
            if (CheckWinState(item)) {
                _onUserWin?.Invoke(turn);
            } else if (_boardRepository.IsBoardFull()) {
                _onUserWin?.Invoke(null);
            } else {
                if (turn == Turn.Krestik) {
                    _boardRepository.SetActiveTurn(Turn.Nolik);
                } else {
                    _boardRepository.SetActiveTurn(Turn.Krestik);
                }

                _onTurnChanged?.Invoke(_boardRepository.GetActiveTurn());
            }      
        } else {
            throw new Exception("record already exist!");
        }
    }

    public void InitSession() {
        _boardRepository.ResetBord();
    }

    public void ObserveTurnState(UnityAction<Turn> observer) {
        _onTurnChanged += observer;
        observer.Invoke(_boardRepository.GetActiveTurn());
    }

    public void RemoveObserver(UnityAction<Turn> observer) {
        _onTurnChanged -= observer;
    }

    public void ObserveUserWin(UnityAction<Turn?> observer) {
        _onUserWin += observer;
    }

    public void RemoveUserWinObserver(UnityAction<Turn?> observer) {
        _onUserWin -= observer;
    }

    public void ObserveResetGame(UnityAction observer) {
        _onResetGame += observer;
    }

    public void RemoveResetGameObserver(UnityAction observer) {
        _onResetGame -= observer;
    }

    public void ResetGame() {
        _boardRepository.ResetBord();
        _onResetGame?.Invoke();
    }
}
