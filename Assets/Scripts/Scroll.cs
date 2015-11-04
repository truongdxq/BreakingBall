using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float offsetX = Time.time * speed % transform.localScale.x;
        Vector2 offset = new Vector2(offsetX, 0.0f);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }

}
