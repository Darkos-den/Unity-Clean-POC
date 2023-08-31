using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardDataSource {

    public void Write(int x, int y, int value);
    public int Read(int x, int y);

    public void WriteTurn(BoardItem turn);

    public BoardItem ReadTurn();

    public List<int> GetBoardItemIndexs(int value);

    public bool IsBoardFull();
}
