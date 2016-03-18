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
            enemy.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
            Look();
            if (enemy.sawPlayer) {
                chaseTimer += Time.deltaTime;
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
        chaseTimer = 0f;
        patrolTimer = 0f;
    }

    public void ToAlertState() {
        Debug.Log("Can't transition to same state");
    }

    public void ToChaseState() {
        enemy.currentState = enemy.chaseState;
        chaseTimer = 0f;
        patrolTimer = 0f;
    }

    private void Look() {
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player")) {
            enemy.chaseTarget = hit.transform;
            enemy.sawPlayer = true;
			Debug.Log ("DETECTED");
        }
        else {
            enemy.sawPlayer = false;
			Debug.Log ("NOT DETECTED");
        }
    }

    private void Search() {

        enemy.meshRendererFlag.material.color = Color.yellow;
        enemy.navMeshAgent.Stop();
        
        enemy.transform.Rotate(0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
        patrolTimer += Time.deltaTime;

        if (patrolTimer >= enemy.maxAlertBeforePatrol) {
            ToPatrolState();
        }
    }
}