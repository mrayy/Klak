﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Klak.Wiring.Patcher;

namespace Klak.Wiring
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(TextureOutput))]
	public class TextureOutEditor : Editor
	{
		SerializedProperty _texture;

		void OnEnable()
		{
			_texture = serializedObject.FindProperty("tex");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(_texture);

			serializedObject.ApplyModifiedProperties();
		}
	}
}

[NodeRendererAttribute(typeof(TextureOutput))]
public class TextureOutputNodeRenderer : Node {
	public TextureOutputNodeRenderer()
	{
		this.color = UnityEditor.Graphs.Styles.Color.Red;
	}
	public override void OnNodeUI (GraphGUI host)
	{ 
		base.OnNodeUI (host);
		var e=this.runtimeInstance as TextureOutput;
		var tex = e.tex;

		// TODO: Check if texture is readable

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Texture");
		GUILayout.Box (tex, new GUILayoutOption[] { GUILayout.Width (64), GUILayout.Height (64) });
		GUILayout.EndHorizontal ();

	}
}

[CustomEditor(typeof(TextureOutputNodeRenderer))]
class TextureOutputNodeRendererEditor : NodeEditor
{
}

/*
*/