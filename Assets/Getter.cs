using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getter : MonoBehaviour
{

    #region GameObjects
    private static GameObject avatar;
    private static string nameAvatar = "AvatarHead";
    #endregion

    #region Camera GameObjects
    private static GameObject mainCam;
    private static string nameMainCam = "Main Camera";
    private static GameObject mapCam;
    private static string nameMapCam = "MapCamera";
    #endregion

    #region Textures
    private static RenderTexture mapTex;
    #endregion

    // Use this for initialization
    static Getter()
    {
        avatar = GameObject.Find(nameAvatar);
        mainCam = GameObject.Find(nameMainCam);
        mapCam = GameObject.Find(nameMapCam);
        if (mapCam != null)
        {
            mapTex = mapCam.GetComponent<Camera>().targetTexture;
        }
    }

    private void FixedUpdate()
    {
        if (avatar == null)
        {
            avatar = GameObject.Find(nameAvatar);
        }
        if (mainCam == null)
        {
            mainCam = GameObject.Find(nameMainCam);
        }
        if (mapCam == null)
        {
            mapCam = GameObject.Find(nameMapCam);
        }
        if (mapTex == null
            && mapCam != null)
        {
            mapTex = mapCam.GetComponent<Camera>().targetTexture;
        }
    }

    public static Tracker Tracker(GameObject obj)
    {
        if (obj != null)
        {
            if(obj.GetComponent<Tracker>() == null)
            {
                obj.AddComponent<Tracker>();
            }
            return obj.GetComponent<Tracker>();
        }
        else
        {
            return null;
        }
    }

    public static GameObject Avatar
    {
        get
        {
            return avatar;
        }
    }
    public static GameObject MainCam
    {
        get
        {
            return mainCam;
        }
    }
    public static GameObject MapCam
    {
        get
        {
            return mapCam;
        }
    }
    public static Texture MapTexture
    {
        get
        {
            return mapTex;
        }
    }
}
