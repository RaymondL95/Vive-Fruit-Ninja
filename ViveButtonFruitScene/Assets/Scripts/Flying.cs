using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour {

    public Transform head;
    public SteamVR_TrackedObject lefthand;
    public SteamVR_TrackedObject righthand;


    private bool isFlying = false;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        var ldevice = SteamVR_Controller.Input((int)lefthand.index);
        var rdevice = SteamVR_Controller.Input((int)righthand.index);

        if ( ldevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) || rdevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            isFlying = !isFlying;
        }


        if(isFlying)
        {

            Vector3 leftDir = lefthand.transform.position - head.position;
            Vector3 rightDir = righthand.transform.position - head.position;

            Vector3 dir = leftDir + rightDir;

            transform.position += (dir *.1f);
        }
    }
}
