using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    private void OnCollisionEnter3D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hit"))
        {
            FailedLevel();
        }
    }

    private void FailedLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
