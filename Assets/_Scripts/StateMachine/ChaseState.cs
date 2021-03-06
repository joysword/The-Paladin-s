using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyState {

    private readonly StatePatternEnemy enemy;
	public Animator anim = GameObject.Find ("guard4").GetComponent<Animator> ();

    public ChaseState(StatePatternEnemy statePatternEnemy) {
        enemy = statePatternEnemy;
    }

    public void UpdateState() {
        Look();
        Chase();
    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToPatrolState() {
       Debug.Log("Can't transition from Chase state to Patrol state");
    }

    public void ToAlertState() {
        enemy.currentState = enemy.alertState;
        enemy.meshRendererFlag.material.color = Color.yellow;
		//anim.SetBool ("Walk",false);
		//anim.SetBool ("Run",false);
        //anim.SetBool("Alert", true);
    }

    public void ToChaseState() {
        Debug.Log("Can't transition to same state");
    }

    private void Look() {
        RaycastHit hit;
        Vector3 enemyToTarget = enemy.chaseTarget.position + enemy.offset - enemy.eyes.transform.position;
        if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player")) {
            enemy.chaseTarget = hit.transform;
        }
        else {
            enemy.sawPlayer = false;
            ToAlertState();
        }
    }

    private void Chase() {

        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
		//enemy.navMeshAgent.speed = 10f;
        enemy.navMeshAgent.Resume();
    }
}