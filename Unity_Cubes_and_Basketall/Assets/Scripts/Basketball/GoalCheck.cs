using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    public ParticleSystem insideHoop;
    public ScoreText scoreText;
    public Target targetScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BasketBall")
        {
            insideHoop.Play();
            Destroy(other.gameObject, 5);
            scoreText.IncreaseScore();
        } else if (other.tag == "BasketBallFire")
        {
            insideHoop.Play();
            Destroy(other.gameObject, 2);
            scoreText.IncreaseScore();
            scoreText.IncreaseScore();
            targetScript.NextLevelButton();
        }
    }
}
