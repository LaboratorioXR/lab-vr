using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string nombre;
    public bool completada = false;
    public int id;
    public QuestTipo tipo;

    [Header("Para Destino")]
    public GameObject destino;

    [Header("Para Enemigos")]
    public int idEnemigo;
    public int cantidadTotal;
    public int cantidadActual;

    [Header("Para Items")]
    public bool retieneItems;
    public List<QuestSystem.Mision.ItemsARecoger> itemsARecoger = new List<QuestSystem.Mision.ItemsARecoger>();

    public enum QuestTipo
    {
        Recolectar,
        Derrotar,
        Entregar
    }
}
