using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MonsterCtrl : MonoBehaviour
{
    //public enum MonsterState { idle, trace, attack, die };
    //public MonsterState monsterState = MonsterState.idle;
    //public NavMeshData data;
    //NavMeshDataInstance[] instances = new NavMeshDataInstance[2];
    private Transform monsterTr;
    private Transform playerTr;
    private Transform towerTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private Animator animator;

    public float traceDist = 7.0f;
    public float attackDist = 2.0f;
    private bool isDie = false;

    private int hp = 100;


    // Start is called before the first frame update
    void Start()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.Find("StopPoint_C").GetComponent<Transform>();
        towerTr = GameObject.Find("StopPoint1_C").GetComponent<Transform>();


        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();

        //StartCoroutine(this.CheckMonsterState());
        //StartCoroutine(this.MonsterAction());

    }

    // Update is called once per frame
    void Update()
    {
        

        //transform.LookAt(towerTr);
        //animator.SetBool("IsTrace", true);

        float dist = Vector3.Distance(towerTr.position, monsterTr.position);
        float dist2 = Vector3.Distance(playerTr.position, monsterTr.position);
        
        if (dist2 <= traceDist)
        {
            nvAgent.destination = playerTr.position;
            transform.LookAt(playerTr);

        }
        else
        {
            nvAgent.destination = towerTr.position;
            transform.LookAt(towerTr);
        }
    }

    //IEnumerator CheckMonsterState()
    //{
    //    while (!isDie)
    //    {
    //        yield return new WaitForSeconds(0.2f);//�������.yield return null.

    //        float dist = Vector3.Distance(playerTr.position, monsterTr.position);
            

    //        if (dist <= attackDist && !FindObjectOfType<GameManager>().isGameOver)
    //        {
    //            monsterState = MonsterState.attack;
    //        }
    //        else if (dist <= traceDist)
    //        {
    //            monsterState = MonsterState.trace;
    //        }
    //        else
    //        {
    //            monsterState = MonsterState.idle;
    //        }

    //    }
    //}

    //IEnumerator MonsterAction()
    //{
    //    while(!isDie)
    //    {
    //        switch (monsterState)
    //        {
    //            case MonsterState.idle:
    //                nvAgent.isStopped = true;
    //                animator.SetBool("IsTrace", false);
    //                break;
    //            case MonsterState.trace:
    //                nvAgent.destination = playerTr.position;
    //                nvAgent.isStopped = false;
                    
    //                animator.SetBool("IsAttack", false);
    //                animator.SetBool("IsTrace", true);
    //                break;
    //            case MonsterState.attack:
    //                nvAgent.isStopped = true;  
    //                animator.SetBool("IsAttack", true);
    //                break;
    //        }
    //        yield return null;
    //    }
    //}

    public void GetDamage(float amount)
    {
        hp -= (int)(amount);
        //animator.SetTrigger("IsHit");

        if (hp <= 0)
        {
            MonsterDie();
        }

    }

    void MonsterDie()
    {
        if (isDie == true) return;//return

        //StopAllCoroutines();
        isDie = true;
        //monsterState = MonsterState.die;
        nvAgent.isStopped = true;
        //animator.SetTrigger("IsDie");

        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false;
        foreach(Collider coll in gameObject.GetComponentsInChildren<SphereCollider>())
        {
            coll.enabled = false;
        }
        Destroy(this.gameObject);
    }
}
