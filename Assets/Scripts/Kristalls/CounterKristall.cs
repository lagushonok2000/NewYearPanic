using TMPro;
using UnityEngine;

public class CounterKristall : MonoBehaviour
{
    [SerializeField] private TMP_Text _redText;
    [SerializeField] private TMP_Text _blueText;
    [SerializeField] private TMP_Text _greenText;
    public int CounterGreen;
    public int CounterRed;
    public int CounterBlue;

    public void AddKristall(int ID)
    {
        if (ID==0)
        {
            CounterBlue++;
            Debug.Log("синий");
        }
        else if (ID==1)
        {
            CounterGreen++;
            Debug.Log("зеленый");
        }
        else if (ID==2)
        {
            CounterRed++;
            Debug.Log("красный");
        }
        UpdateText();
    }
    private void UpdateText()
    {
        _redText.text = ": " + CounterRed;
        _blueText.text = ": " + CounterBlue;
        _greenText.text = ": " + CounterGreen;
    }
}