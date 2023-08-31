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

    public void ObserveCurrentTurn(UnityAction<Turn> observer) {
        _useCase.ObserveTurnState(observer);
    }

    public void ObserveWinState(UnityAction<Turn?> observer) {
        _useCase.ObserveUserWin(observer);
    }

    public void OnResetClicked() {
        _useCase.ResetGame();
    }

    public void RemoveObserver(UnityAction<Turn> observer) {
        _useCase.RemoveObserver(observer);
    }

    public void RemoveWinStateObserver(UnityAction<Turn?> observer) {
        _useCase.RemoveUserWinObserver(observer);
    }
}
