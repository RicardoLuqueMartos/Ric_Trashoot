using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb2d;
    PlayerMovement playerMovement;
    float initialPosition;
    float initialRotation;

    //initialize the variables for every test
    [SetUp]
    public void Setup()
    {
        // Arrange
        player = new GameObject();
        rb2d = player.AddComponent<Rigidbody2D>();
        playerMovement = player.AddComponent<PlayerMovement>();
        playerMovement.Initialize(rb2d);
        initialPosition = player.transform.position.y;
        initialRotation = player.transform.rotation.z;
    }

    // clean the variables at the end of each test
    [TearDown]
    public void Teardown()
    {
        Destroy(player);
    }


    [UnityTest]
    public IEnumerator PlayerRotateToTheLeftWithPositiveRotation()
    {
        //Act
        playerMovement.DoMove(1, 0);
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.IsTrue(player.transform.rotation.z < initialRotation);

        // autre methode assert
        Assert.That(player.transform.rotation.z, Is.LessThan(initialRotation));
    }

    [UnityTest]
    public IEnumerator PlayerDoesntRotateWithZeroRotation()
    {
        //Act
        playerMovement.DoMove(0, 0);
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.AreEqual(player.transform.rotation.z, initialRotation);

        // autre methode assert
        Assert.That(player.transform.rotation.z, Is.EqualTo(initialRotation));
    }

    [UnityTest]
    public IEnumerator PlayerRotateToTheRightWithNegativeRotation()
    {
        //Act
        playerMovement.DoMove(-1, 0);
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.IsTrue(player.transform.rotation.z > initialRotation);

        // autre methode assert
        Assert.That(player.transform.rotation.z, Is.GreaterThan(initialRotation));
    }

    [UnityTest]
    public IEnumerator PlayerMoveForwardWithPositiveDirection()
    {
        //Act
        playerMovement.DoMove(0, 1);
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.IsTrue(player.transform.position.y > initialPosition);

        // autre methode assert
        Assert.That(player.transform.position.y, Is.GreaterThan(initialPosition));
    }

    [UnityTest]
    public IEnumerator PlayerMoveBackwardWithNegativeDirection()
    {
        //Act
        playerMovement.DoMove(0, -1);
        yield return new WaitForSeconds(0.1f);

        // Assert
        Assert.IsTrue(player.transform.position.y < initialPosition);

        // autre methode assert
        Assert.That(player.transform.position.y, Is.LessThan(initialPosition));
    }
}
