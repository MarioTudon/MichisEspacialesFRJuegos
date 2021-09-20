//Este script se debe colocar en el GameObject que funcionara como selector

using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    //Variable que contiene el GameObject con todos los niveles
    public GameObject levelsList;

    //Primer nivel de la lista
    [HideInInspector] public GameObject firstLevel;
    //Ultimo nivel de la lista
    [HideInInspector] public GameObject lastLevel;
    //Nivel anterior al nivel seleccionado
    [HideInInspector] public GameObject previousLevel;
    //Nivel seleccionado
    [HideInInspector] public GameObject currentlyLevel;
    //Nivel siguiente al nivel seleccionado
    [HideInInspector] public GameObject nextLevel;

    void Start()
    {
        //La variable "firstLevel" se iguala al primer hijo de la lista "levelsList"
        firstLevel = levelsList.transform.GetChild(0).gameObject;
        //La variable "lastLevel" se iguala al ultimo hijo de la lista "levelsList"
        lastLevel = levelsList.transform.GetChild(levelsList.transform.childCount - 1).gameObject;
        //La variable "currentlyLevel" se iguala al hijo donde el selector se encuentra posicionado
        currentlyLevel = levelsList.transform.GetChild(0).gameObject;
        //Se anima el nivel seleccionado aumentando su escala a 1.5 con un loop ping pong
        currentlyLevel.transform.LeanScale(Vector3.one * 1.5f, 0.5f).setLoopPingPong();
        //Funcion que asigna los niveles anterior y siguiente
        SetPreviousAndNextLevels();
    }

    //Funcion que define la variable "previousLevel"
    public void SetPreviousAndNextLevels()
    {
        //Esta linea define el valor del nivel anterior dependiendo de lo que haya en la lista
        previousLevel = currentlyLevel.transform.GetSiblingIndex() - 1 > -1 ?
        levelsList.transform.GetChild(currentlyLevel.transform.GetSiblingIndex() - 1).gameObject : null;

        //Esta linea define el valor del nivel siguiente dependiendo de lo que haya en la lista
        nextLevel = currentlyLevel.transform.GetSiblingIndex() + 1 < levelsList.transform.childCount ?
        levelsList.transform.GetChild(currentlyLevel.transform.GetSiblingIndex() + 1).gameObject : null;
    }
}
