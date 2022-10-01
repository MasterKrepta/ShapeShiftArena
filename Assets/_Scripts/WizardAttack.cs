using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    [SerializeField] Transform spell;

    private void OnEnable()
    {
        Debug.Log("cast spell");
    }
}
