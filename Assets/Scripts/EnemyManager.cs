using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] float damage = 20f;
    public float health = 100f;
    NavMeshAgent AI;
    [SerializeField] Animator demonAnimator;
    // Start is called before the first frame update
    void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AI = GetComponent<NavMeshAgent>();
        demonAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AI.destination = Player.transform.position;
        if (AI.velocity.magnitude > 1)
        {
            demonAnimator.SetBool("Run", true);
        }
    }
    public void Hit(float damage)
    {
        health -= damage;
        death();
    }
    void death()
    {
        if (health <= 0)
        {
            demonAnimator.SetBool("Die", true);
            demonAnimator.SetBool("Attacking", false);
            demonAnimator.SetBool("Run", false);
            StartCoroutine(CountDown());
            EnemyCounter.Instance.enemisLeft--;
        }
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            demonAnimator.SetBool("Run", false);
            demonAnimator.SetBool("Attacking", true);
            Player.GetComponent<PlayerMovment>().HitPlayer(damage);
        }
    }
}
