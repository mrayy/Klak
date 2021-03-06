﻿using UnityEngine;
using System.Collections;

public class OffscreenProcessor  {

	Material _ProcessingMaterial;
	public RenderTexture ResultTexture{
		get{
			return _RenderTexture;
		}
	}
	public Material ProcessingMaterial {
		get{ return _ProcessingMaterial; }
	}
	RenderTexture _RenderTexture;

	public RenderTextureFormat TargetFormat=RenderTextureFormat.ARGB32;

	public string ShaderName
	{
		set{
			ProcessingShader=Shader.Find(value);
		}
	}
	public Shader ProcessingShader
	{
		set{
			_ProcessingMaterial=new Material(value);
		}
		get{
			return _ProcessingMaterial.shader;
		}
	}

	public OffscreenProcessor()
	{
		_ProcessingMaterial = new Material (Shader.Find("Diffuse"));
		TargetFormat = RenderTextureFormat.Default;
	}
	void _Setup(Texture InputTexture,int downSample)
	{
		int width = InputTexture.width/(downSample+1);
		int height = InputTexture.height/(downSample+1);
		if ( (InputTexture as Texture2D !=null) && ((Texture2D)InputTexture).format == TextureFormat.Alpha8)
			height =(int)( height / 1.5f);
		if (_RenderTexture == null) {
			_RenderTexture = new RenderTexture (width, height,16, RenderTextureFormat.ARGB32);
		} else if (	_RenderTexture.width != width || 
		           _RenderTexture.height != height) 
		{
			_RenderTexture = new RenderTexture (width, height,16, RenderTextureFormat.ARGB32);
		}
	}
	public Texture ProcessTexture(Texture InputTexture,int pass=0,int downSample=0)
	{
		if (InputTexture==null || InputTexture.width == 0 || InputTexture.height == 0)
			return InputTexture;
		_Setup (InputTexture,downSample);
		ProcessingMaterial.mainTexture = InputTexture;
		RenderTexture old = RenderTexture.active;
		RenderTexture.active = _RenderTexture;
		GL.Clear (true,true,Color.black);
		Graphics.Blit (InputTexture,_RenderTexture, ProcessingMaterial,pass);
		RenderTexture.active = old;
		return _RenderTexture;

	}

}
