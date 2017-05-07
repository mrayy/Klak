using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Klak.Wiring;

[AddComponentMenu("TxKit/Image/Offscreen Processor")]
[NodeAttribute("Image/Offscreen Processor")]
public class OffscreenNode : NodeBase {

	Texture _srcTexture;
	OffscreenProcessor _processor;
	public Shader Shader;


	[SerializeField, Inlet]
	public Texture Input
	{
		set {
			_srcTexture = value;
		}
	}
	[SerializeField, Outlet]
	TextureEvent _result;
	// Use this for initialization
	void Start () {
		_processor = new OffscreenProcessor ();
		_processor.ShaderName = Shader.name;

	}
	
	// Update is called once per frame
	void Update () {
		_result.Invoke(_processor.ProcessTexture (_srcTexture,0,1));
	}
}
