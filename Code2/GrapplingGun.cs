/*****
Braeden Kurfman
Software Engineering
Testing Grounds
*****/

//Credit to DanisTutorial for help with the GrapplingGun and RotateGun code

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GrapplingGun : MonoBehaviour {

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;

    
    void Awake() {
        lr = GetComponent<LineRenderer>();
    }
    // checks if the game is paused so that the grappling hook cannot be used while paused. Also gets the initial input for the grappling hook.
    void Update() {
        if(!PauseMenu.isPaused){
            if (Input.GetMouseButtonDown(0)) {
                StartGrapple();
            }
            else if (Input.GetMouseButtonUp(0)) {
                StopGrapple();
            }
        }
    }

    //Called after Update
    void LateUpdate() {
        DrawRope();
    }

    // starts the grappling hook animation and effects
    void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            Vector3 grapplingHookPointPosition = GetGrapplePoint();

            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.6f;
            joint.minDistance = distanceFromPoint * 0.25f;

            // Joint Values for effecting speed/ weight
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            // Updates the current grapple position
            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }

    // stops grappling hook animation and effects
    void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;
    
    void DrawRope() {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);
        
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }
    // check to see if the grappling hook is active
    public bool IsGrappling() {
        return joint != null;
    }
    // gets the coordinates of the grappling hook attachement
    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}
