using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ICellController {

    public void ApplyPosition(int x, int y);

    public void HandleMouseEnter();
    public void HandleMouseExit();
    public void HandleClick();

    public void ObserveColor(UnityAction<Color> observer);
    public void RemoveObserver(UnityAction<Color> observer);

    public void ObserveBoardItem(UnityAction<BoardItem?> observer);
    public void RemoveObserver(UnityAction<BoardItem?> observer);
}
