using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] Transform spear;


    private void OnEnable()
    {
        Instantiate(spear, transform.position, transform.rotation);
    }


}
