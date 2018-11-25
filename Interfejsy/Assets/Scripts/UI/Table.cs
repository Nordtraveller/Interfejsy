using UnityEngine;
using System.Collections;

[System.Serializable] public class GameObjectTable : Table<GameObject> { public GameObjectTable(int rowCount, int colCount) : base(rowCount, colCount) { } }
[System.Serializable] public class BoolTable : Table<bool> { public BoolTable(int rowCount, int colCount) : base(rowCount, colCount) { } }
[System.Serializable] public class FloatTable : Table<float> { public FloatTable(int rowCount, int colCount) : base(rowCount, colCount) { } }
[System.Serializable] public class IntTable : Table<int> { public IntTable(int rowCount, int colCount) : base(rowCount, colCount) { } }
[System.Serializable] public class TransformTable : Table<Transform> { public TransformTable(int rowCount, int colCount) : base(rowCount, colCount) { } }
[System.Serializable] public class GridItemTable : Table<GridItem> { public GridItemTable(int rowCount, int colCount) : base(rowCount, colCount) { } }

public class Table<T>
{
    public T[] data;
    public int rowCount;
    public int colCount;

    public Table(int rowCount, int colCount)
    {
        data = new T[rowCount * colCount];
        this.rowCount = rowCount;
        this.colCount = colCount;
    }

    public T this[int row, int col]
    {
        get { return data[row * colCount + col]; }
        set { data[row * colCount + col] = value; }
    }

    public void SetRowCount(int value)
    {
        if (value == rowCount || value < 0)
            return;

        T[] newData = new T[value * colCount];
        for (int i = 0; i < value * colCount; ++i)
            newData[i] = default(T);

        int copyCount = Mathf.Min(value, rowCount) * colCount;
        for (int i = 0; i < copyCount; ++i)
        {
            newData[i] = data[i];
        }

        data = newData;
        rowCount = value;
    }

    public void SetColCount(int value)
    {
        if (value == colCount || value < 0)
            return;

        T[] newData = new T[rowCount * value];
        for (int i = 0; i < rowCount * value; ++i)
            newData[i] = default(T);

        for (int i = 0; i < rowCount; ++i)
        {
            int minCount = Mathf.Min(value, colCount);
            for (int j = 0; j < minCount; ++j)
            {
                newData[i * value + j] = data[i * colCount + j];
            }
        }

        data = newData;
        colCount = value;
    }
}
