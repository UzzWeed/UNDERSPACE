using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    //Referencia de textos UI
    public Text frutasTotal;
    public Text frutasRecogidas;
    private int frutasTotalNivel;

    private void Start()
    {
        frutasTotalNivel = 3;
    }

    private void Update()
    {
        frutasTotal.text = frutasTotalNivel.ToString();
        frutasRecogidas.text = transform.childCount.ToString();

    }

}
