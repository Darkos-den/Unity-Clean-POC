using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardRepository {

    public void ResetBord();

    public BoardItem GetActiveTurn();
    public void SetActiveTurn(BoardItem turn);

    public void WriteBoardITem(int x, int y, BoardItem item);
    public BoardItem? GetBoardItem(int x, int y);

    public List<int> GetBoardItemIndexs(BoardItem item);

    public bool IsBoardFull();

}
