using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
using System;

namespace CodeSampleOne
{

    /*
        Helpful resources:
        Unity3D: Using reorderable List in Custom Editor: https://xinyustudio.wordpress.com/2015/07/21/unity3d-using-reorderablelist-in-custom-editor/
    */
    [CustomEditor(typeof(AnimalDataHandler))]
    public class AnimalDataEditor : Editor
    {
        private SerializedProperty animalListProperty = default;
        private static GUIStyle titleStyle = default;
        private const string kFilePath = "Assets/Resources/AnimalData.json";
        private const string infoString = "This tool is used to help update AnimalData.json in the Resources folder.";
        private GUILayoutOption[] buttonOptions = new GUILayoutOption[] {
            GUILayout.Height(24)
        };

        void OnEnable()
        {
            titleStyle = new GUIStyle();
            titleStyle.fontSize = 24;
            titleStyle.richText = true;

            SetupAnimalList();
        }

        private void SetupAnimalList()
        {
            animalListProperty = serializedObject.FindProperty("data");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("<color=white>Animal Data</color>", titleStyle);
            EditorGUILayout.Space();
            GUILayout.Space(20);

            if (GUILayout.Button("Update Animal Data File", buttonOptions))
            {
                OnUpdateData();
            }

            GUILayout.Space(20);
            serializedObject.Update();
            base.OnInspectorGUI();
            serializedObject.ApplyModifiedProperties();
            GUILayout.Space(20);
            EditorGUILayout.HelpBox(infoString, MessageType.Info);
        }

        private void OnUpdateData()
        {
            var animalListData = (AnimalDataHandler)animalListProperty.serializedObject.targetObject;
            var jsonData = animalListData.CreateJsonStringFromData();

            StreamWriter sw = new StreamWriter(kFilePath);
            sw.Write(jsonData);
            sw.Close();

            Debug.Log($"Animal Data has been updated in Assets/Resources/AnimalData.json!");
            //TODO: Add option to see JSON printed in the console.
            //TODO: Update field for sprite to be a sprite window.
            Debug.Log($"{jsonData}");

            EditorUtility.DisplayDialog(
                "Done!",
                "Data has been updated in AnimalData.json file",
                "OK"
            );
            AssetDatabase.Refresh();
        }
    }
}