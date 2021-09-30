using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "QuestSystem", order = 1)]
public class QuestSystem : ScriptableObject
{
    [System.Serializable]
    public struct Mision
    {

        public string nombre;
        public string descripcion;
        public int id;
        public QuestType tipo;

        [System.Serializable]
        public enum QuestType
        {
            Recolectar,
            Derrotar,
            Entregar
        }

        //Tambi�n puede usarse este tipo de misi�n para hacer que el jugador deba de ir hasta cierto lugar o persona a la que le debe de llevar X item
        //(con esto logramos crear una misi�n de "Entrega" + "Recolecci�n de items")
        [Header("Misiones de Recolecci�n")]
        public bool diferentesItems;
        public bool seQuedaConItems;
        public List<ItemsARecoger> Datos;

        [System.Serializable]
        public struct ItemsARecoger
        {
            public string nombre;
            public int cantidad;
            public int itemID;
        }

        [Header("Misiones de Matar")]
        public int cantidad;
        public int enemyID;

        [Header("Recompensas")]
        public int oro;
        public int xp;
        public bool tieneRecompensaEspecial;
        public RecompensasEspeciales[] recompensaEspecial;

        [System.Serializable]
        public struct RecompensasEspeciales
        {
            public string nombre;
            public GameObject recompensa;
        }
    }
    public Mision[] misiones;
}
