using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator anim;
    private PlayerContoller playerController;
    private float attackCooldown;
    public Transform firePoint;
    public GameObject[] fireballs;
    private float cooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerController.canAttack())
            attack();

        cooldownTimer += Time.deltaTime;
        
    }

    void attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[0].transform.position = firePoint.position;
        fireballs[0].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }
}
