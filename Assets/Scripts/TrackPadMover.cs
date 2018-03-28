using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPadMover : MonoBehaviour {

    public float speed;
    private Rigidbody ballRigidBody;
    SteamVR_TrackedObject controller;

    private void Awake()
    {
        this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballRigidBody = GameObject.Find("Ball").GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)controller.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad) )
        {
            var model = this.transform.FindChild("Model");
            Transform trackpad = model.FindChild("trackpad").FindChild("attach");
            Transform touch = model.FindChild("trackpad_touch").FindChild("attach");

            Vector3 movement = (touch.position) - (trackpad.position);
            movement = new Vector3(movement.x, 0, movement.z);
            movement.Normalize();

            this.ballRigidBody.AddForce(movement * speed);
        }
    }
}
