using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLockWalk : MonoBehaviour {
    public Transform vrCamera;
    public float toggleAngle = 30f;
    public float speed = 5f;
    public float gravity = 9.8f;
    private bool moveForward;
    private float vSpeed = 0;

    private CharacterController character;

	void Start () {
        character = GetComponent<CharacterController>();
	}
	
	void Update () {
        if (character.isGrounded)
            tryMoveForward();
        else
            applyGravity();
    }

    private void tryMoveForward() {
        moveForward = vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x <= 90f;

        if (moveForward){
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            character.SimpleMove(forward * speed);
        }

    }

    private void applyGravity() {
        vSpeed -= gravity * Time.deltaTime;
        Vector3 currentVelocity = character.velocity;
        currentVelocity.y = vSpeed;
        character.Move(currentVelocity * Time.deltaTime);
    }

}
