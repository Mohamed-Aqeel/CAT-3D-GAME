using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public float Health = 100;
    public Animator animator;

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;

        if (Health <= 0)
        {
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
            Invoke("CompleteLevel",10);

        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }

    internal void TakeDamage(float damage)
    {
        throw new NotImplementedException();
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

