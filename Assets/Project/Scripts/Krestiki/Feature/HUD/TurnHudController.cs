using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class TurnHudController : ITurnHudController {

    private readonly ISessionUseCase _useCase;

    [Inject]
    public TurnHudController(ISessionUseCase useCase) {
        _useCase = useCase;
    }

    public void ObserveCurrentTurn(UnityAction<BoardItem> observer) {
        _useCase.ObserveTurnState(observer);
    }

    public void ObserveWinState(UnityAction<BoardItem?> observer) {
        _useCase.ObserveUserWin(observer);
    }

    public void OnResetClicked() {
        _useCase.ResetGame();
    }

    public void RemoveObserver(UnityAction<BoardItem> observer) {
        _useCase.RemoveObserver(observer);
    }

    public void RemoveWinStateObserver(UnityAction<BoardItem?> observer) {
        _useCase.RemoveUserWinObserver(observer);
    }
}
