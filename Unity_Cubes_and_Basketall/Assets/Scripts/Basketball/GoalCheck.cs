using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    public ParticleSystem insideHoop;
    public ScoreText scoreText;
    public Target targetScript;
    public Sounds sounds;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BasketBall")
        {
            insideHoop.Play();
            sounds.ScoreSound();
            Destroy(other.gameObject, 5);
            scoreText.IncreaseScore();
        } else if (other.tag == "BasketBallFire")
        {
            insideHoop.Play();
            sounds.ScoreSound();
            Destroy(other.gameObject, 2);
            scoreText.IncreaseScore();
            scoreText.IncreaseScore();
            targetScript.NextLevelButton();
        }
    }
}
