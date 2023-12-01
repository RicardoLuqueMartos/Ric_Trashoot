using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TestEnemyMovement : MonoBehaviour
{
    GameObject enemy;
    GameObject player;
    Rigidbody2D rb2d;
    EnemyController enemyController;
    Vector3 initialPosition;
    Quaternion initialRotation;

    //initialize the variables for every test
    [SetUp]
    public void Setup()
    {
        // Arrange
        enemy = new GameObject();
        player = new GameObject();
        rb2d = enemy.AddComponent<Rigidbody2D>();
        enemyController = enemy.AddComponent<EnemyController>();
        enemyController.Initialize(rb2d, player);
        initialPosition = enemy.transform.position;
        initialRotation = enemy.transform.rotation;
    }

    // clean the variables at the end of each test
    [TearDown]
    public void Teardown()
    {
        Destroy(enemy);
        Destroy(player);
    }


    [UnityTest]
    public IEnumerator EnemyRotatesToAimThePlayer()
    {
        //Act
        enemyController.TestAimPlayer();
        yield return new WaitForSeconds(1);

        // Assert
        Assert.IsTrue(enemy.transform.rotation != initialRotation);

        // autre methode assert
        Assert.That(enemy.transform.rotation, Is.Not.EqualTo(initialRotation));
    }
    
    [UnityTest]
    public IEnumerator EnemyMoveForwardToPlayerDirection()
    {
        // get original distance
        float distOriginal = Vector3.Distance(player.transform.position, enemy.transform.position);

        //Act
        enemyController.TestMoveToPlayerPosition();
        yield return new WaitForSeconds(0.1f);

        // get current distance
        float distNow = Vector3.Distance(player.transform.position, enemy.transform.position);

        // Assert
        // compare the distances, if distance now is lower the enemy has moved toward the player
        Assert.IsTrue(enemy.transform.position != initialPosition && distOriginal > distNow);
    }  
}
