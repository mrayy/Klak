using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Klak.Wiring.Patcher;

namespace Klak.Wiring
{
	[CustomEditor(typeof(FloatValueInput))]
	public class FloatValueInputEditor : Editor
	{
		SerializedProperty _value;

		void OnEnable()
		{
			_value = serializedObject.FindProperty("_value");

		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(_value);

			serializedObject.ApplyModifiedProperties();
		}
	}

	[NodeRendererAttribute(typeof(FloatValueInput))]
	public class FloatValueInputNodeRenderer : Node {
		public FloatValueInputNodeRenderer()
		{
			//	this.color = UnityEditor.Graphs.Styles.Color.Red;

		}
		public override void OnNodeUI (GraphGUI host)
		{ 
			base.OnNodeUI (host);
			var e=this.runtimeInstance as FloatValueInput;

			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Value");
			e.Value=UnityEditor.EditorGUILayout.FloatField(e.Value);
			GUILayout.EndHorizontal ();

		}
	}
	[CustomEditor(typeof(FloatValueInputNodeRenderer))]
	class FloatValueInputNodeRendererEditor : NodeEditor
	{
	}

}