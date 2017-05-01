using UnityEngine;
using System.Collections;

public abstract class IImageProcessor : MonoBehaviour {
	
	public abstract Texture ProcessTexture (Texture InputTexture,  int downSample = 0);
}
