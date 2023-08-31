using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ISessionUseCase {

    public void InitSession();

    public void ObserveTurnState(UnityAction<Turn> observer);
    public void RemoveObserver(UnityAction<Turn> observer);

    public void AddBoardItem(int x, int y, Turn item);

    public void ObserveUserWin(UnityAction<Turn?> observer);
    public void RemoveUserWinObserver(UnityAction<Turn?> observer);

    public void ObserveResetGame(UnityAction observer);
    public void RemoveResetGameObserver(UnityAction observer);

    public void ResetGame();
}
