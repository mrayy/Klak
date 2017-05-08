using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Klak.Wiring.Patcher;

namespace Klak.Wiring
{
	[CustomEditor(typeof(RobotConnectorNode))]
	public class RobotConnectorNodeEditor : Editor {

		SerializedProperty _camera;

		void OnEnable()
		{
			_camera = serializedObject.FindProperty("_camera");

		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.PropertyField(_camera);

			serializedObject.ApplyModifiedProperties();
		}
	}

	[NodeRendererAttribute(typeof(RobotConnectorNode))]
	public class RobotConnectorNodeNodeRenderer : Node {
		public RobotConnectorNodeNodeRenderer()
		{
			//	this.color = UnityEditor.Graphs.Styles.Color.Red;

		}


		public override void OnNodeDraw(GraphGUI host)
		{
			// Recapture the variable for the delegate.
			var node2 = this;

			// Subwindow style (active/nonactive)
			var isActive = host.selection.Contains(this);

			if (this.nodeStyle == null) {
				nodeStyle = new GUIStyle( UnityEditor.Graphs.Styles.GetNodeStyle (this.style, this.color, true));
				nodeStyle.normal.background = Resources.Load<Texture2D> ("TxKit");
			}


			// Show the subwindow of this node.
			this.position = GUILayout.Window(
				this.GetInstanceID(), this.position,
				delegate { host.NodeGUI(node2); },
				"",nodeStyle, GUILayout.Width(256),GUILayout.Height(256)
			);

		}

		GUIStyle pinStyle;
		public override void OnNodeUI (GraphGUI host)
		{ 
			base.NodeUI (host);

			var e=this.runtimeInstance as RobotConnectorNode;

			GUILayout.BeginHorizontal ();
			GUILayout.EndHorizontal ();

			if (pinStyle == null) {
				pinStyle = new GUIStyle (Styles.pinOut);
				pinStyle.alignment = TextAnchor.MiddleRight;
			}

			int space = 50;
			foreach (var slot in this.outputSlots)
			{
				EditorGUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.BeginArea (new Rect (256-50	, 10+space, 50, 30));
				host.LayoutSlot(slot, slot.title, true, false, true,pinStyle );
				GUILayout.EndArea ();
				EditorGUILayout.EndHorizontal();

				space += 20;
			}

		}
	}
	[CustomEditor(typeof(RobotConnectorNodeNodeRenderer))]
	class RobotConnectorNodeNodeRendererEditor : NodeEditor
	{
	}

}