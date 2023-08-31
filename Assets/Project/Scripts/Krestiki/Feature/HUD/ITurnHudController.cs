using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ITurnHudController {

    public void ObserveCurrentTurn(UnityAction<BoardItem> observer);
    public void RemoveObserver(UnityAction<BoardItem> observer);

    public void ObserveWinState(UnityAction<BoardItem?> observer);
    public void RemoveWinStateObserver(UnityAction<BoardItem?> observer);

    public void OnResetClicked();
}
