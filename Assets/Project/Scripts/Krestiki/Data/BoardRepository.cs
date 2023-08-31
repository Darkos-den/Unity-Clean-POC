using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEditor.Progress;

public class BoardRepository : IBoardRepository {

    private IBoardDataSource _dataSource;

    [Inject]
    public BoardRepository(IBoardDataSource dataSource) { 
        _dataSource = dataSource;
    }

    public BoardItem GetActiveTurn() {
        return _dataSource.ReadTurn();
    }

    public BoardItem? GetBoardItem(int x, int y) {
        int data = _dataSource.Read(x, y);

        if(data == 1) {
            return BoardItem.Krestik;
        } else if(data == 2) {
            return BoardItem.Nolik;
        } else {
            return null;
        }
    }

    public List<int> GetBoardItemIndexs(BoardItem item) {
        int data = ParseBoardItem(item);

        return _dataSource.GetBoardItemIndexs(data);
    }

    public bool IsBoardFull() {
        return _dataSource.IsBoardFull();
    }

    public void ResetBord() {
        _dataSource.Write(0, 0, 0);
        _dataSource.Write(1, 0, 0);
        _dataSource.Write(2, 0, 0);

        _dataSource.Write(0, 1, 0);
        _dataSource.Write(1, 1, 0);
        _dataSource.Write(2, 1, 0);

        _dataSource.Write(0, 2, 0);
        _dataSource.Write(1, 2, 0);
        _dataSource.Write(2, 2, 0);
    }

    public void SetActiveTurn(BoardItem turn) {
        _dataSource.WriteTurn(turn);
    }

    public void WriteBoardITem(int x, int y, BoardItem item) {
        int data = ParseBoardItem(item);

        _dataSource.Write(x, y, data);
    }

    private int ParseBoardItem(BoardItem item) {
        int data;

        if (item == BoardItem.Krestik) {
            data = 1;
        } else if (item == BoardItem.Nolik) {
            data = 2;
        } else {
            data = 0;
        }

        return data;
    }
}
