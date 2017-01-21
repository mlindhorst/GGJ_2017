using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileImage : MonoBehaviour {
    public float scrollSpeed;
    public float tileSizeY;

    private Vector2 savedOffset;
    private Vector3 startPosition;
    private Material oceanMaterial;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        oceanMaterial = GetComponent<SpriteRenderer>().material;
        savedOffset = oceanMaterial.GetTextureOffset("_MainTex");
    }
	
	// Update is called once per frame
	void Update () {
        float x = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY * 4);
        x = x / tileSizeY;
        x = Mathf.Floor(x);
        x = x / 4;
        Vector2 offset = new Vector2(x, savedOffset.y);
        oceanMaterial.SetTextureOffset("_MainTex", offset);
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
