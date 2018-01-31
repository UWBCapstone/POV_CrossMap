using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_WSA_10_0
using HoloToolkit.Unity;
#endif

public class Tracker : MonoBehaviour {
    private Vector3 pos;
    private Vector3 origPos;
    private Quaternion rot;
    private Quaternion origRot;
    private GameObject mainCam;

    void Awake()
    {
        //#if UNITY_WSA_10_0
        //        mainCam = HoloToolkit.Unity.CameraCache.Main.gameObject;
        //#else
        //        mainCam = Getter.MainCam;
        //#endif
        //        if(mainCam != null)
        //        {
        //            pos = mainCam.transform.position;
        //            rot = mainCam.transform.rotation;
        //        }
        //        else
        //        {
        //            pos = Vector3.zero;
        //            rot = Quaternion.identity;
        //        }

        origPos = gameObject.transform.position;
        pos = Vector3.zero;
        origRot = gameObject.transform.rotation;
        rot = Quaternion.identity;
    }

    // Use this for initialization
    void Update () {
        //#if UNITY_WSA_10_0
        //        if(mainCam == null)
        //        {
        //            mainCam = HoloToolkit.Unity.CameraCache.Main.gameObject;
        //        }
        //#endif
        //        if (mainCam != null)
        //        {
        //            pos = mainCam.transform.position;
        //            rot = mainCam.transform.rotation;
        //        }

        pos = gameObject.transform.position - origPos;
        //rot = gameObject.transform.rotation - origRot;
        rot = Quaternion.Euler(gameObject.transform.rotation.eulerAngles - origRot.eulerAngles);
	}

    public Vector3 Position
    {
        get
        {
            return pos;
        }
    }

    public Quaternion Rotation
    {
        get
        {
            return rot;
        }
    }
}
