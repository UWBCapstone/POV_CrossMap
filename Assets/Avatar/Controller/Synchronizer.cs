using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synchronizer : MonoBehaviour {
    public GameObject TrackedObject;
    
    private Vector3 origTrackedPos;
    private Quaternion origTrackedRot;
    private Vector3 origPos;
    private Quaternion origRot;

    public bool SynchronizePosition = true;
    public bool SynchronizeRotation = true;
    public bool IsMiniMap = false;

    void Awake()
    {
        origTrackedPos = TrackedObject.transform.position;
        origTrackedRot = TrackedObject.transform.rotation;
        origPos = gameObject.transform.position;
        origRot = gameObject.transform.rotation;
    }

    void Update()
    {
        if (SynchronizePosition)
        {
            SyncPos();
        }
        if (SynchronizeRotation)
        {
            SyncRot();
        }
    }

    public void Sync()
    {
        SyncPos();
        SyncRot();
    }

    public void SyncPos()
    {
        if (TrackedObject != null)
        {
            gameObject.transform.position = origPos + deltaPos();
        }
    }

    public void SyncRot()
    {
        if (TrackedObject != null)
        {
            gameObject.transform.rotation = Quaternion.Euler(deltaRot().eulerAngles + origRot.eulerAngles);
        }
    }

    private Vector3 deltaPos()
    {
        if(TrackedObject != null)
        {
            Vector3 dPos = TrackedObject.transform.position - origTrackedPos;
            return dPos;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private Quaternion deltaRot()
    {
        if (TrackedObject != null)
        {
            Vector3 dEuler = TrackedObject.transform.rotation.eulerAngles - origTrackedRot.eulerAngles;

            if (IsMiniMap)
            {
                Vector3 modDEuler = new Vector3(0, dEuler.y, 0); // Ignore rotation along the x & z axis to keep the mini-map locked and intuitively aligned with rotation
                Quaternion dRot = Quaternion.Euler(modDEuler);
                return dRot;
            }
            else
            {

                Quaternion dRot = Quaternion.Euler(dEuler);
                return dRot;
            }
        }
        else
        {
            return Quaternion.identity;
        }
    }

    //public GameObject TrackedObject
    //{
    //    get
    //    {
    //        return trackedObject;
    //    }
    //    set
    //    {
    //        trackedObject = value;
    //    }
    //}

    //public GameObject TrackedObject
    //{
    //    get
    //    {
    //        if(tracker != null)
    //        {
    //            return tracker.gameObject;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            if (value.GetComponent<Tracker>() == null)
    //            {
    //                value.AddComponent<Tracker>();
    //                Debug.Log("Adding Tracker component to " + value.name);
    //            }
    //            tracker = Getter.Tracker(value);
    //        }
    //    }
    //}
}
