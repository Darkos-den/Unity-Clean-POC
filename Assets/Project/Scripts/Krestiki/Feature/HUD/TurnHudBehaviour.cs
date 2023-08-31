using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TurnHudBehaviour : MonoBehaviour {

    [SerializeField] private Image _turnImage;

    [SerializeField] private Sprite _spriteKrestiki;
    [SerializeField] private Sprite _spriteNoliki;

    [SerializeField] private Canvas _winHud;
    [SerializeField] private TextMeshProUGUI _winText;

    [Inject] private ITurnHudController _controller;

    void Awake() {
        _controller.ObserveCurrentTurn(OnTurnChanged);
        _controller.ObserveWinState(OnWin);
    }

    private void OnDestroy() {
        _controller.RemoveObserver(OnTurnChanged);
        _controller.RemoveWinStateObserver(OnWin);
    }

    private void OnTurnChanged(BoardItem turn) {
        if (turn == BoardItem.Nolik) {
            _turnImage.sprite = _spriteNoliki;
        } else {
            _turnImage.sprite = _spriteKrestiki;
        }
    }

    private void OnWin(BoardItem? turn) {
        if(turn != null) {
            _winText.text = "YOU WIN";
        } else {
            _winText.text = "DRAW";
        }
        _winHud.gameObject.SetActive(true);
    }

    public void OnResetClick() {
        _winHud.gameObject.SetActive(false);
        _controller.OnResetClicked();
    }
}
