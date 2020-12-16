using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {

	public static Cronometro gm;

    // VARIAVEIS DO CRONOMETRO
    public Text TimerText;
	public float Minutes;
	public float Seconds;
	public bool stopCronometro = false;

    void Start()
    {
        gm = this;
		TimerText = GetComponent<Text> () as Text;

        StartCoroutine(Wait());
	}

	void Update()
    {        
        CronometroLogic();
    }

    #region CRONOMETRO
    public void CronometroLogic()
    {
        if (Seconds < 10)
        {
            TimerText.text = (Minutes + ":0" + Seconds);
        }

        if (Seconds > 9)
        {
            TimerText.text = (Minutes + ":" + Seconds);
        }
    }

	public void CountDown()
    {
		if (!stopCronometro)
        {
			if (Seconds <= 0)
            {
				MinusMinute ();
				Seconds = 60;
			}

			if (Minutes >= 0)
            {
				MinusSeconds ();
			}

			if (Minutes <= 0 && Seconds <= 0)
            {
                MenuInGame.gm.FracassouMissao ();
				StopTimer ();
			}
            else
            {
				Start ();
			}
		}
		if (Mundos.gm.coins == 10) {
			stopCronometro = true;
		}
	}
	public void MinusMinute()
    {
		Minutes -= 1;
	}

	public void MinusSeconds()
    {
		Seconds -= 1;
	}

	public IEnumerator Wait()
    {
		yield return new WaitForSeconds(1);
		CountDown();
	}

    public IEnumerator TimeColor()
    {
        TimerText.color = Color.red;
        yield return new WaitForSeconds(1);
        TimerText.color = Color.white;
        yield return new WaitForSeconds(1);
        TimerText.color = Color.red;
        yield return new WaitForSeconds(1);
        TimerText.color = Color.white;
        yield return new WaitForSeconds(1);
        TimerText.color = Color.red;

    }

    public void StopTimer(){
		Seconds = 0;
		Minutes = 0;
	}
    #endregion

}
