using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomPropertyDrawer(typeof(TagSelector))]



public class TagEditorPopup : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType == SerializedPropertyType.String)
        { 
            EditorGUI.BeginProperty(position, label, property);
            var attrib = this.attribute as TagSelector;
            if (attrib.Tag)
            {
                property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
            }
            else
            {
                List<string> tagList = new List<string>();
                string propertyString = property.stringValue;
                int index = -1;
                tagList.Add("<Tag Não Selecionada>");
                tagList.AddRange(UnityEditorInternal.InternalEditorUtility.tags);
                if (propertyString == "")
                {
                    index = 0;
                }
                  else
                {
                    for (int i = 1; i < tagList.Count; i++)
                    {
                        if (tagList[i] == propertyString)
                        {
                            index = i;
                            break;
                        }
                    }
                }
                index = EditorGUI.Popup(position, label.text, index, tagList.ToArray());
                if (index == 0)
                {
                    property.stringValue = "";
                }
                else if (index >= 1)
                {
                    property.stringValue = tagList[index];
                }
                else
                {
                    property.stringValue = "";
                }
            }
        }
    }
}


