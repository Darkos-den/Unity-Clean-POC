using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDataSource: IBoardDataSource {

    private readonly int[] _board;
    private BoardItem _turn;

    public BoardDataSource() {
        _board = new int[9];
    }

    public List<int> GetBoardItemIndexs(int value) {
        List<int> result = new();

        for(int i = 0; i < 9; i++) {
            if (_board[i] == value) {
                result.Add(i);
            }
        }

        return result;  
    }

    public bool IsBoardFull() {
        int temp = 0;
        for(int i = 0;i < 9;i++) {
            if (_board[i] == 0) {
                temp++;
            }
        }

        return temp == 0;
    }

    public int Read(int x, int y) {
        return _board[x * 3 + y];
    }

    public BoardItem ReadTurn() {
        return _turn;
    }

    public void Write(int x, int y, int value) {
        _board[x * 3 + y] = value;
    }

    public void WriteTurn(BoardItem turn) {
        _turn = turn;
    }
}
