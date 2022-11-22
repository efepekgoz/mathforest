using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolmeButonu : MonoBehaviour
{
    private void OnMouseDown()
    {
        AHesapla VarTEmporal = GameObject.Find("AHesapla").GetComponent<AHesapla>();

        VarTEmporal.BolmeFonksiyonu();

    }

}
