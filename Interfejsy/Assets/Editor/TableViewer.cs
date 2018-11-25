using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Reflection;

[CustomPropertyDrawer(typeof(GameObjectTable))]
[CustomPropertyDrawer(typeof(BoolTable))]
[CustomPropertyDrawer(typeof(FloatTable))]
[CustomPropertyDrawer(typeof(IntTable))]
[CustomPropertyDrawer(typeof(TransformTable))]
[CustomPropertyDrawer(typeof(GridItemTable))]
public class TableDrawer : PropertyDrawer
{
    private bool bHide = true;
    private const float ITEM_HEIGHT = 18.0f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        bHide = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, ITEM_HEIGHT), bHide, label);
        if (bHide)
            return;

        Rect newPosition = position;
        newPosition.y += ITEM_HEIGHT;
        newPosition.height = ITEM_HEIGHT;

        EditorGUI.indentLevel += 1;

        SerializedProperty data = property.FindPropertyRelative("data");
        SerializedProperty rowCount = property.FindPropertyRelative("rowCount");
        SerializedProperty colCount = property.FindPropertyRelative("colCount");
        int oldRowCount = rowCount.intValue;
        int oldColCount = colCount.intValue;
        bool bUpdateRow = false;
        bool bUpdateCol = false;

        // Row/cols label
        newPosition.x = position.x;
        newPosition.width = 0.33f * position.width;
        Rect labelRect = EditorGUI.PrefixLabel(newPosition, new GUIContent("Rows|Cols"));

        // Row control
        newPosition.x += 0.33f * position.width;
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(newPosition, rowCount, GUIContent.none);
        if (EditorGUI.EndChangeCheck())
        {
            bUpdateRow = true;
        }

        // Column control
        newPosition.x += 0.33f * position.width;
        EditorGUI.BeginChangeCheck();
        EditorGUI.PropertyField(newPosition, colCount, GUIContent.none);
        if (EditorGUI.EndChangeCheck())
        {
            bUpdateCol = true;
        }

        // Actual array
        newPosition.x = position.x;
        newPosition.y += ITEM_HEIGHT;
        for (int i = 0; i < oldRowCount; i++)
        {
            newPosition.width = position.width / oldColCount;
            for (int j = 0; j < oldColCount; j++)
            {
                EditorGUI.BeginChangeCheck();
                EditorGUI.PropertyField(newPosition, data.GetArrayElementAtIndex(i * oldColCount + j), GUIContent.none);
                if (EditorGUI.EndChangeCheck())
                {
                    data.serializedObject.ApplyModifiedProperties();
                }

                newPosition.x += newPosition.width;
            }

            newPosition.x = position.x;
            newPosition.y += ITEM_HEIGHT;
        }

        if (bUpdateRow)
            SetNewRowCount(property, rowCount.intValue);

        if (bUpdateCol)
            SetNewColCount(property, colCount.intValue);

        data.serializedObject.Update();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (bHide)
        {
            return ITEM_HEIGHT;
        }

        SerializedProperty rowCount = property.FindPropertyRelative("rowCount");
        SerializedProperty colCount = property.FindPropertyRelative("colCount");
        return colCount.intValue == 0 ? ITEM_HEIGHT * 2 : ITEM_HEIGHT * (rowCount.intValue + 2); // header and row/col line
    }

    public void SetNewRowCount(SerializedProperty property, int rowCount)
    {
        Type type = property.serializedObject.targetObject.GetType();
        if (type == null)
        {
            Debug.LogError("Couldn't find object type");
            return;
        }

        FieldInfo fieldInfo = type.GetField(property.name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        if (fieldInfo == null)
        {
            Debug.LogError("Couldn't find object info");
            return;
        }

        dynamic tableObj = fieldInfo.GetValue(property.serializedObject.targetObject);
        tableObj.SetRowCount(rowCount);
    }

    public void SetNewColCount(SerializedProperty property, int colCount)
    {
        Type type = property.serializedObject.targetObject.GetType();
        if (type == null)
        {
            Debug.LogError("Couldn't find object type");
            return;
        }

        FieldInfo fieldInfo = type.GetField(property.name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        if (fieldInfo == null)
        {
            Debug.LogError("Couldn't find object info");
            return;
        }

        dynamic tableObj = fieldInfo.GetValue(property.serializedObject.targetObject);
        tableObj.SetColCount(colCount);
    }
}
