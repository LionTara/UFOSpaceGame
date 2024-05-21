using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    public TMP_Text uiHPText;
    public Slider uiHPSlider;

    public int HP = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage) 
    {
        HP -= damage;

        if (HP < 0)
        {
            HP = 0;
        }

        UpdateUI();

        if (HP == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void UpdateUI()
    {
        uiHPText.text = "" + HP;
        uiHPSlider.value = (float)HP / 100;  
    }
}
