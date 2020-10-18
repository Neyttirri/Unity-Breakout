using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	float _speed = 20f;
	Rigidbody _rigidbody;
	Vector3 _velocity;	// the actual movement speed of the ball + directions
	Renderer _renderer;
	
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f); 	// delay half a second before moving the new ball (instantiate it and waits before moving)  
    }

	void Launch()
	{
		_rigidbody.velocity = Vector3.up * _speed;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // runs by def 100 times a sec
    void FixedUpdate()
    {
    	_rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
    	_velocity = _rigidbody.velocity;
    	
    	if (!_renderer.isVisible)
    	{
    		GameManager.Instance.Balls--;
    		Destroy(gameObject);
    	}
    }
    
    void OnCollisionEnter(Collision collision)
    {
    	_rigidbody.velocity =  Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }
}
