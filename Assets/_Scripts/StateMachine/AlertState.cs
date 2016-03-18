using UnityEngine;
using System.Collections;

public class AlertState : IEnemyState {

    private readonly StatePatternEnemy enemy;
    private float chaseTimer;
    private float patrolTimer;

    public AlertState(StatePatternEnemy statePatternEnemy) {
        enemy = statePatternEnemy;
    }

    public void UpdateState() {
        if (!enemy.sawPlayer) {
            chaseTimer = 0f;
            Look();
            if (!enemy.sawPlayer) {
                Search();
            }
        }
        else {
            patrolTimer = 0f;
            enemy.transform.LookAt(enemy.target.transform);
            Look();
            if (enemy.sawPlayer) {
                chaseTimer += Time.deltaTime;
                //Debug.Log("chaseTimer:"+chaseTimer);
            }
            if (chaseTimer >= enemy.maxAlertBeforeChase) {
                ToChaseState();
            }
        }
        
    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToPatrolState() {
        enemy.currentState = enemy.patrolState;
        enemy.meshRendererFlag.material.color = Color.green;
        chaseTimer = 0f;
        patrolTimer = 0f;
    }

    public void ToAlertState() {
        Debug.Log("Can't transition to same state");
    }

    public void ToChaseState() {
        enemy.currentState = enemy.chaseState;
        enemy.meshRendererFlag.material.color = Color.red;
        chaseTimer = 0f;
        patrolTimer = 0f;
    }

    private void Look() {
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player")) {
            enemy.chaseTarget = hit.transform;
            enemy.sawPlayer = true;
            Debug.Log("saw player when alerting");
        }
        else {
            enemy.sawPlayer = false;
			Debug.Log("lost player when alerting");
        }
    }

    private void Search() {

        enemy.navMeshAgent.Stop();
        
        enemy.transform.Rotate(0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
        patrolTimer += Time.deltaTime;

        if (patrolTimer >= enemy.maxAlertBeforePatrol) {
            ToPatrolState();
        }
    }
}