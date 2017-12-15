using UnityEngine;

public class Slowdown : MonoBehaviour {

    //slowdown factor
    public float slowdownmultiplier = 0.05f;

    //total slowdown
    public float slowdownLength = 2f;

   public void SlowMotion()
    {   
        Time.timeScale = slowdownmultiplier;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    private void Update()
    {
        Time.timeScale += 1f / slowdownLength * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
}
