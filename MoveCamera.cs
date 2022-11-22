using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
 public void MovingCamera() {
        AHesapla Gecici = GameObject.Find("AHesapla").GetComponent<AHesapla>();
        Gecici.AmoveCamera();
    }
}
