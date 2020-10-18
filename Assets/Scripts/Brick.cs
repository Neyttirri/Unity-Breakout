using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int points = 100; 
    public Vector3 rotator;
    public Material hitMaterial;
    
    private Material _origMaterial;
    private Renderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y) * 0.1f);
        _renderer = GetComponent<Renderer>();
        _origMaterial = _renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
    	hits--;
    	// score points
    	if (hits <= 0)
    	{
    		GameManager.Instance.Score += points; 
    		Destroy(gameObject);	// gameObject is a predefined variable that access the object this script is added to 
    	}
    	_renderer.sharedMaterial = hitMaterial;
    	Invoke("RestoreMaterial", 0.05f);	// invoke the method after that many sec 
    }
    
    void RestoreMaterial()
    {
    	_renderer.sharedMaterial = _origMaterial;
    }
}
