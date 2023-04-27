using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformModel 
{ 
    private List<CellView> _cells;
    private List<BlockView> _blocksOnPlatform = new List<BlockView>();

    public event Action<List<BlockView>> IsFull;

    public PlatformModel(List<CellView> cells)
    {
        _cells = cells;       
    }

    public bool GetIsAbleToTake(BlockView block)
    {
        if(block == null)
            return false;
        
        if(UsingCellsCount() == block.CubesCount)
        {   
            return true;        
        }
        else
        {
            return false;
        }
    }

    public void PutBlock(BlockView block)
    {
        _blocksOnPlatform.Add(block);

        foreach (CellView cell in _cells)
            if (cell.CubeAbove != null)
                cell.PutCube();

        CountEmptyCells();
    }

    private int UsingCellsCount()
    {
        int usingCellsCount = 0;

        foreach (CellView cell in _cells)
            if (cell.IsEmpty && cell.CubeAbove != null )
                usingCellsCount++;

        return usingCellsCount;
    }

    private void CountEmptyCells()
    {
        int emptyCells = _cells.Count;

        foreach (var cell in _cells)
            if (!cell.IsEmpty)
                emptyCells--;

        if (emptyCells == 0)
        {
            IsFull?.Invoke(_blocksOnPlatform);

            _blocksOnPlatform.Clear();

            foreach (var cell in _cells)
                cell.Reset();
        }
    }
}
    

