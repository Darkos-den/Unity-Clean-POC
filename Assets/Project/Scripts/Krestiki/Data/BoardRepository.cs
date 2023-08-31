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

    public Turn GetActiveTurn() {
        return _dataSource.ReadTurn();
    }

    public Turn? GetBoardItem(int x, int y) {
        int data = _dataSource.Read(x, y);

        if(data == 1) {
            return Turn.Krestik;
        } else if(data == 2) {
            return Turn.Nolik;
        } else {
            return null;
        }
    }

    public List<int> GetBoardItemIndexs(Turn item) {
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

    public void SetActiveTurn(Turn turn) {
        _dataSource.WriteTurn(turn);
    }

    public void WriteBoardITem(int x, int y, Turn item) {
        int data = ParseBoardItem(item);

        _dataSource.Write(x, y, data);
    }

    private int ParseBoardItem(Turn item) {
        int data;

        if (item == Turn.Krestik) {
            data = 1;
        } else if (item == Turn.Nolik) {
            data = 2;
        } else {
            data = 0;
        }

        return data;
    }
}
