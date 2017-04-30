using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Wiring.Patcher;
using Klak.Wiring;

[NodeRendererAttribute(typeof(AxisInput))]
public class AxisInputNodeRenderer : Node {

	public override void OnNodeUI (GraphGUI host)
	{
		base.OnNodeUI (host);
		GUILayout.Box ("Hello!");
	}
}
