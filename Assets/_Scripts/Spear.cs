using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    Transform Player;
    [SerializeField] float moveSpeed = 10;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Vector3 moveDir = (Player.position - transform.position + new Vector3(0, 1, 0)).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
