using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Klak.Wiring
{
	[AddComponentMenu("Klak/Wiring/TxKit/Robot Connector")]
	[NodeAttribute("TxKit/Robot Connector")]
	public class RobotConnectorNode : NodeBase {

		[SerializeField]
		Camera _camera;

		[SerializeField, Outlet]
		FloatEvent _eyes = new FloatEvent();

		[SerializeField, Outlet]
		FloatEvent _ears = new FloatEvent();

		void Update()
		{
			if (_camera!=null)
				_eyes.Invoke (_camera.fieldOfView);
		}
	}
}