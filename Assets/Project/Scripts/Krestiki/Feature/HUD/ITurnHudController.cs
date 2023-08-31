using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ITurnHudController {

    public void ObserveCurrentTurn(UnityAction<Turn> observer);
    public void RemoveObserver(UnityAction<Turn> observer);

    public void ObserveWinState(UnityAction<Turn?> observer);
    public void RemoveWinStateObserver(UnityAction<Turn?> observer);

    public void OnResetClicked();
}
