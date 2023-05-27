using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RunShooter.Character
{
    [CustomEditor(typeof(TestGunSelection))]
    public class DebugGunSelectionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button("Select"))
            {
                ((TestGunSelection)target).Select();
            }
        }
    }
}
