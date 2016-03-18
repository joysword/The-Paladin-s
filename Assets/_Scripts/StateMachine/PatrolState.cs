using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState {

    private readonly StatePatternEnemy enemy;
    private int nextWayPoint;

    private void Awake() {
        nextWayPoint = 0;
    }

    public PatrolState(StatePatternEnemy statePatternEnemy) {
        enemy = statePatternEnemy;
    }

    public void UpdateState() {
        Look();
        Patrol();
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("felt player is nearby when patroling");
            ToAlertState();
        }
    }

    public void ToPatrolState() {
        Debug.Log("Can't transition to same state");
    }

    public void ToAlertState() {
        enemy.currentState = enemy.alertState;
        enemy.meshRendererFlag.material.color = Color.yellow;
        Debug.Log("transitioning from Patrol to Alert");
    }

    public void ToChaseState() {
        Debug.Log("Can't transition from Patrol state to Chase state");
    }

    private void Look() {
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player")) {
            // enemy.chaseTarget = hit.transform;
            enemy.sawPlayer = true;
            Debug.Log("saw player when patroling");
            ToAlertState();
        }
    }

    private void Patrol() {
        enemy.navMeshAgent.destination = enemy.wayPoints[nextWayPoint].position;
        enemy.navMeshAgent.Resume();

        if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending) {
            nextWayPoint = (nextWayPoint + 1) % enemy.wayPoints.Length;
        }
    }
}