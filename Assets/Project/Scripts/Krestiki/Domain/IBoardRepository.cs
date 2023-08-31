using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardRepository {

    public void ResetBord();

    public Turn GetActiveTurn();
    public void SetActiveTurn(Turn turn);

    public void WriteBoardITem(int x, int y, Turn item);
    public Turn? GetBoardItem(int x, int y);

    public List<int> GetBoardItemIndexs(Turn item);

    public bool IsBoardFull();

}
