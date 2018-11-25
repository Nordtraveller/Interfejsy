using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Grid : MonoBehaviour {

    [SerializeField] private GridItemTable itemsView;

    [SerializeField] private UnityEvent onMenuClick;
    [SerializeField] private Vector2Int defaultGridPosition;

    private Vector2Int currentItemPosition;
    private GridItem currentItem;

    private void Awake() {
        if (defaultGridPosition == null) {
            for (int i = 0; i < itemsView.rowCount; i++) {
                for (int j = 0; j < itemsView.colCount; j++) {
                    if (itemsView[i, j] != null) {
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
        currentItem.Select();
    }

    private void Update() {
        PlayerInput input = Player.Instance.input;

        if (input.menu) {
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

        GridItem chosenItem = null;
        for (int j = 1; j <= itemsView.colCount; j++) {
            int colDifference = j * verticalInput;
            for (int i = currentItemPosition.x; i < itemsView.rowCount; i++) {
                GridItem item = itemsView[i, NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount)];
                if (item != null) {
                    if (item != currentItem) {
                        currentItem.Disselect();
                        item.Select();
                    }
                    currentItem = item;
                    currentItemPosition.x = i;
                    currentItemPosition.y = NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount);
                    return;
                }
            }
            for (int i = currentItemPosition.x - 1; i >= 0 ; i--) {
                GridItem item = itemsView[i, NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount)];
                if (item != null) {
                    if (item != currentItem) {
                        currentItem.Disselect();
                        item.Select();
                    }
                    currentItem = item;
                    currentItemPosition.x = i;
                    currentItemPosition.y = NegativeMod(currentItemPosition.y + colDifference, itemsView.colCount);
                    return;
                }
            }
        }
    }

    virtual protected void HorizontalUpdate(int horizontalInput) {
        if (horizontalInput == 0) { return; }

        for (int i = 1; i <= itemsView.rowCount; i++) {
            int rowDifference = i * horizontalInput;

            for (int j = currentItemPosition.y; j < itemsView.colCount; j++) {
                GridItem item = itemsView[NegativeMod(currentItemPosition.x + rowDifference, itemsView.rowCount), currentItemPosition.y];
                if (item != null) {
                    if (item != currentItem) {
                        currentItem.Disselect();
                        item.Select();
                    }
                    currentItem = item;
                    currentItemPosition.x = NegativeMod(currentItemPosition.x + rowDifference, itemsView.rowCount);
                    currentItemPosition.y = j;
                    return;
                }
            }
            for (int j = currentItemPosition.y - 1; j >= 0; j--) {
                GridItem item = itemsView[NegativeMod(currentItemPosition.x + rowDifference, itemsView.rowCount), currentItemPosition.y];
                if (item != null) {
                    if (item != currentItem) {
                        currentItem.Disselect();
                        item.Select();
                    }
                    currentItem = item;
                    currentItemPosition.x = NegativeMod(currentItemPosition.x + rowDifference, itemsView.rowCount);
                    currentItemPosition.y = j;
                    break;
                }
            }
        }
    }

    private int NegativeMod(int x, int m) {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
}
