using UnityEngine;
using System.Collections;

public class TextureMove : MonoBehaviour {
	public string textureToMove ="_MainTex";
	public float moveSpeed = 0f;
	public float trackOffset = 0;
	// Update is called once per frame
	void Update () {
		trackOffset += moveSpeed *Time.deltaTime;
		renderer.material.SetTextureOffset (textureToMove, new Vector2 (0, trackOffset));
	}

}
