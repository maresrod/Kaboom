using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private float speed = 2;
    private Renderer enemyRenderer;
    private float enemyHalfWidth;
    private int stepsCount = 0;

    /*
     * Se llama antes de que se actualize el primer frame
     */
    void Start() {
        //Debug.Log("Screen width: " + Screen.width + "Screen height: " + Screen.height);
        enemyRenderer = GetComponent<Renderer>();
        enemyHalfWidth = enemyRenderer.bounds.center.magnitude;
    }

    /*
    * Se llama cada vez por cada frame
    */
    void Update() {
        MoveEnemy();
    }

    ///////////////////////////////////////////////////////// METHODS ////////////////////////////////////////////////////////////////////////
    /*
     * Movimiento horizontal del enemigo
     */
    private void MoveEnemy() {
        // Si el enemigo entra en el límite horizontal de la pantalla
        if (IsOnScreenLimit()) {
            speed = -speed; // Invertimos la dirección
            stepsCount = 0; // Reiniciamos el contador de pasos
        } else if (IsReadyToChangeDirection()) {
            System.Random rand = new System.Random();
            int direction = rand.Next(0, 100); // Generamos un número random entre 0 y 2
            //Debug.Log("Result range--> " + direction);
            if (direction == 99) {
                speed = -speed; // Invertimos la dirección
                stepsCount = 0; // Reiniciamos el contador de pasos
            }
        }
        // Aplicamos el movimiento del enemigo
        transform.Translate(speed * Time.deltaTime, 0, 0);
        stepsCount++;
    }

    /*
     * Comprueba si el enemigo ha salido de los límites de la pantalla
     *    
     * Return boolean
     */
    private bool IsOnScreenLimit() {
        Vector3 tmpPos = Camera.main.WorldToScreenPoint(transform.position);
        if (tmpPos.x - enemyHalfWidth < Screen.width * 0.01 || tmpPos.x + enemyHalfWidth > Screen.width * 0.99) {
            Debug.Log("He salido de la pantalla! " + tmpPos.x.ToString());
            return true;
        }
        return false;
    }

    private bool IsReadyToChangeDirection() {
        if (stepsCount > 100) {
            return true;
        }
        return false;
    }
}