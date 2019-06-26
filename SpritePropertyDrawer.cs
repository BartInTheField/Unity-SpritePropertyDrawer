using UnityEngine;
using UnityEditor;
 
[CustomPropertyDrawer(typeof(Sprite))]
public class SpritePropertyDrawer : PropertyDrawer
{
    private const float textSize = 70;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent labelN)
    {
        if (property.objectReferenceValue != null)
        {
            return textSize;
        }
        else
        {
            return base.GetPropertyHeight(property, labelN);
        }
    }
 
    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, prop);
 
        if (prop.objectReferenceValue != null)
        {
            position.width = EditorGUIUtility.labelWidth;
            GUI.Label(position, prop.displayName);
 
            position.x += position.width;
            position.width = textSize;
            position.height = textSize;
 
            prop.objectReferenceValue = EditorGUI.ObjectField(position, prop.objectReferenceValue, typeof(Sprite), false);
        }
        else
        {
            EditorGUI.PropertyField(position, prop, true);
        }
 
        EditorGUI.EndProperty();
    }
}