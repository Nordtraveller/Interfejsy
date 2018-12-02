using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Grid : MonoBehaviour {

    [SerializeField] public GridItemTable itemsView;

    [SerializeField] private UnityEvent onMenuClick;
    [SerializeField] private Vector2Int defaultGridPosition;
    [SerializeField] private bool diamondGrid = true;

    public GridItem currentItem;

    private Vector2Int currentItemPosition;
    private Vector2Int previousCellDelta = new Vector2Int(0, 0);
    private bool bInitialized = false;

    public struct CellPosition
    {
        public CellPosition(GridItem item, int x, int y)
        {
            this.item = item;
            this.position = new Vector2Int();
            this.position.x = x;
            this.position.y = y;
        }

        public CellPosition(GridItem item, Vector2Int position)
        {
            this.item = item;
            this.position = position;
        }

        public GridItem item;
        public Vector2Int position;
    }

    private void OnEnable() {
        if (bInitialized) { return; }

        if (defaultGridPosition == null) {
            for (int i = 0; i < itemsView.rowCount; i++) {
                for (int j = 0; j < itemsView.colCount; j++) {
                    if (IsCellActive(itemsView[i, j])) {
                        defaultGridPosition = new Vector2Int(i, j);
                        break;
                    }
                }
            }
        }

        if (defaultGridPosition == null) {
            Debug.LogError("No cell in grid is correctly set");
            return;
        }

        currentItem = itemsView[defaultGridPosition.x, defaultGridPosition.y];
        currentItemPosition = new Vector2Int(defaultGridPosition.x, defaultGridPosition.y);
        currentItem.Select();
        bInitialized = true;
    }

    private void Update() {
        PlayerInput input = Player.Instance.input;

        if (input.menu) {
            onMenuClick?.Invoke();
        }
        if (input.B && !GameObject.Find("GameManagers").GetComponent<MenusManager>().areDisabled())
        {
            onMenuClick?.Invoke();
        }

        HorizontalUpdate(input.horizontal);
        VerticalUpdate(input.vertical);
        if (input.A) {
            currentItem.Click();
        }
        if (input.X) {
            currentItem.DetailClick();
        }

    }

    virtual protected void VerticalUpdate(int verticalInput) {
        if (verticalInput == 0) { return; }

        for (int j = 1; j <= itemsView.colCount; j++) {
            int colDifference = j * verticalInput;
            CellPosition nearestCell = new CellPosition(itemsView[currentItemPosition.x, NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount)], currentItemPosition.x, NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount));
            CellPosition leftMostCell = new CellPosition(null, Vector2Int.zero);
            CellPosition rightMostCell = new CellPosition(null, Vector2Int.zero);

            for (int i = currentItemPosition.x + 1; i < itemsView.rowCount; i++) {
                rightMostCell.item = itemsView[i, NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount)];
                rightMostCell.position = new Vector2Int(i, NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount));
                if (IsCellActive(rightMostCell.item)) { break; }
            }
            for (int i = currentItemPosition.x - 1; i >= 0; i--) {
                leftMostCell.item = itemsView[i, NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount)];
                leftMostCell.position = new Vector2Int(i, NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount));
                if (IsCellActive(leftMostCell.item)) { break; }
            }

            if (IsCellActive(nearestCell.item)) {
                SelectItem(nearestCell);
                return;
            }
            else if (!diamondGrid) {
                continue;
            }
            else if (IsCellActive(leftMostCell.item) && IsCellActive(rightMostCell.item))
            {
                float leftDistance = Mathf.Abs(leftMostCell.position.x - currentItemPosition.x);
                float rightDistance = Mathf.Abs(rightMostCell.position.x - currentItemPosition.x);

                if (leftDistance > 1.1f && rightDistance > 1.1f) {
                    continue;
                }

                if (leftDistance == rightDistance) {
                    if (previousCellDelta.y < 0) {
                        SelectItem(leftMostCell);
                        return;
                    }
                    else if (previousCellDelta.y > 0) {
                        SelectItem(rightMostCell);
                        return;
                    }
                }
                if (leftDistance < rightDistance) {
                    SelectItem(leftMostCell);
                    previousCellDelta.y = 1;
                    return;
                }
                else {
                    SelectItem(rightMostCell);
                    previousCellDelta.y = -1;
                    return;
                }
            }
            else if (IsCellActive(leftMostCell.item)) {
                SelectItem(leftMostCell);
                previousCellDelta.y = 1;
                return;
            }
            else if (IsCellActive(rightMostCell.item)) {
                SelectItem(rightMostCell);
                previousCellDelta.y = -1;
                return;
            }
            else {
                continue;
            }
        }
    }

    virtual protected void HorizontalUpdate(int horizontalInput) {
        if (horizontalInput == 0) { return; }


        if (horizontalInput == 0) { return; }

        for (int i = 1; i <= itemsView.rowCount; i++) {
            int rowDifference = i * horizontalInput;

            for (int j = currentItemPosition.y; j < itemsView.colCount; j++) {
                GridItem item = itemsView[NegativeMod(currentItemPosition.x + rowDifference, itemsView.rowCount), currentItemPosition.y];
                if (IsCellActive(item)) {
                    SelectItem(new CellPosition(item, new Vector2Int(NegativeMod(currentItemPosition.x + rowDifference, itemsView.rowCount), currentItemPosition.y)));
                    return;
                }
            }
            for (int j = currentItemPosition.y - 1; j >= 0; j--) {
                GridItem item = itemsView[NegativeMod(currentItemPosition.x + rowDifference, itemsView.rowCount), currentItemPosition.y];
                if (IsCellActive(item)) {
                    SelectItem(new CellPosition(item, NegativeMod(currentItemPosition.x + rowDifference, itemsView.rowCount), currentItemPosition.y));
                    return;
                }
            }
        }
    }

    private int NegativeMod(int x, int m) {
        int r = x % m;
        return r < 0 ? r + m : r;
    }

    private bool IsCellActive(GridItem item) {
        return item != null && item.active;
    }

    private void SelectItem(CellPosition cellPosition) {
        if (cellPosition.item != currentItem) {
            currentItem.Disselect();
            cellPosition.item.Select();
            currentItem = cellPosition.item;
            currentItemPosition = cellPosition.position;
        }
    }
}
