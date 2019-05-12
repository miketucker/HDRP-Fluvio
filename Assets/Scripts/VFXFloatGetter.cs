using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class VFXFloatGetter : MonoBehaviour
{

    [SerializeField] VisualEffect vfx;

    public float GetFloat(string param){
        return vfx.GetFloat(param);
    }
}
