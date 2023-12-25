using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ParrotSpriteChanger))]
public class SpriteSetsEditor : Editor
{
    SerializedProperty spriteSets;

    private void OnEnable()
    {
        spriteSets = serializedObject.FindProperty("spriteSetsArray");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(spriteSets, new GUIContent("Sprite Sets"), true);

        if (spriteSets.isExpanded)
        {
            EditorGUI.indentLevel++;

            for (int i = 0; i < spriteSets.arraySize; i++)
            {
                SerializedProperty spriteSet = spriteSets.GetArrayElementAtIndex(i);

                SerializedProperty name = spriteSet.FindPropertyRelative("type");
                SerializedProperty normalSprite = spriteSet.FindPropertyRelative("normalSprite");
                SerializedProperty changedSprite = spriteSet.FindPropertyRelative("changedSprite");
            }

            EditorGUI.indentLevel--;
        }

        serializedObject.ApplyModifiedProperties();
    }
}