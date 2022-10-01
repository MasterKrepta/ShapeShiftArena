using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnims : MonoBehaviour
{
    [SerializeField] GameObject werewolfAttack, VampireAttack, WizardAttack;
    public void EnableWereWolfAttack()
    {
        werewolfAttack.SetActive(true);
    }

    public void DisableWerewolfAttack()
    {
        werewolfAttack.SetActive(false);
    }

    public void EnableVampireAttack()
    {
        VampireAttack.SetActive(true);
    }

    public void DisableVampireAttack()
    {
        VampireAttack.SetActive(false);
    }

    public void EnableWizardAttack()
    {
        WizardAttack.SetActive(true);
    }

    public void DisableWizardAttack()
    {
        WizardAttack.SetActive(false);
    }
}