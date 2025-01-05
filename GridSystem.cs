using UnityEngine;

public class GridSystem<TGrid> {

    private int width = 10;
    private int height = 10;
    private float cellSize = 1;
    private Vector3 originPosition;
    private TGrid[,] gridArray;



    public GridSystem(int width, int height, float cellSize, Vector3 originPostion) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPostion;
        gridArray = new TGrid[width, height];

        for (int x = 0; x < width; x++) {
            for (int z = 0; z < height; z++) {
                // Debug for grid
                Debug.DrawLine(GridToWorldPosition(x, z), GridToWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GridToWorldPosition(x, z), GridToWorldPosition(x + 1, z), Color.white, 100f);
            }
        }
        Debug.DrawLine(GridToWorldPosition(0, height), GridToWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GridToWorldPosition(width, 0), GridToWorldPosition(width, height), Color.white, 100f);
    }

    public Vector3 GridToWorldPosition(int x, int z) {
        // returning World Position of the grid
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }

    public Vector2Int WorldToGridPosition(Vector3 worldPosition) {
        // returning Grid Position of the world
        int x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        int z = Mathf.FloorToInt((worldPosition.z - originPosition.z) / cellSize);
        return new Vector2Int(x, z);
    }

    public void SetValue(int x, int z, TGrid value) {
        // Set Value of the grid
        if (x >= 0 && z >= 0 && x < width && z < height) {
            gridArray[x, z] = value;
        }
    }

    public void SetValue(Vector3 worldPosition, TGrid value) {
        Vector2Int gridPosition = WorldToGridPosition(worldPosition);
        SetValue(gridPosition.x, gridPosition.y, value);
    }

    public TGrid GetValue(int x, int z) {
        if (x >= 0 && z >= 0 && x < width && z < height) {
            return gridArray[x, z];
        } else {
            return default;
        }
    }

    public TGrid GetValue(Vector3 worldPosition) {
        Vector2Int gridPosition = WorldToGridPosition(worldPosition);
        return GetValue(gridPosition.x, gridPosition.y);
    }

}
