using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Block))]
class BlockEditor : Editor {
  public override void OnInspectorGUI() {
    var b = target as Block;
    if(GUILayout.Button("Break"))
     b.Break();
  }
}