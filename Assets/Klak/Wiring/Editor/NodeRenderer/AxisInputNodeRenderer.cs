using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Wiring.Patcher;
using Klak.Wiring;
using UnityEditor;

[NodeRendererAttribute(typeof(AxisInput))]
public class AxisInputNodeRenderer : Node {

	public override void OnNodeUI (GraphGUI host)
	{
		base.OnNodeUI (host);
		var e=this.runtimeInstance as AxisInput;
		GUILayout.Box (e.Value.ToString());
	}
}

[CustomEditor(typeof(AxisInputNodeRenderer))]
class AxisInputNodeRendererEditor : NodeEditor
{
}

