using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ISessionUseCase {

    public void InitSession();

    public void ObserveTurnState(UnityAction<BoardItem> observer);
    public void RemoveObserver(UnityAction<BoardItem> observer);

    public void AddBoardItem(int x, int y, BoardItem item);

    public void ObserveUserWin(UnityAction<BoardItem?> observer);
    public void RemoveUserWinObserver(UnityAction<BoardItem?> observer);

    public void ObserveResetGame(UnityAction observer);
    public void RemoveResetGameObserver(UnityAction observer);

    public void ResetGame();
}
