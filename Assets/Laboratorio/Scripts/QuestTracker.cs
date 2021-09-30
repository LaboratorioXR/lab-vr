using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    public QuestSystem db;

    //Quests iniciadas (aún incompletas/en progreso)
    public List<Quest> questsActivos = new List<Quest>();

    //Quests terminadas (se completaron los requisitos)
    public List<Quest> questsCompletados = new List<Quest>();

    //Lista que almacenan los NPCs que nos dieron las quests
    [HideInInspector] public List<QuestGiver> rewarders = new List<QuestGiver>();


    public void MuerteEnemiga(int idEnemiga)
    {
        if (questsActivos.Count > 0)
        {
            for (int i = 0; i < questsActivos.Count; i++)
            {
                if(questsActivos[i].idEnemigo == idEnemiga)
                {
                    questsActivos[i].cantidadActual++;
                    if (questsActivos[i].cantidadActual < questsActivos[i].cantidadTotal)
                    {
                        print("Cantidad restante de enemigos: " + (questsActivos[i].cantidadTotal - questsActivos[i].cantidadActual));
                    }
                    ActualizarQuest(questsActivos[i].id, questsActivos[i].tipo);
                    break;
                }
            }
        }
    }

    public void ActualizarQuest(int quest_ID, Quest.QuestTipo tipo, int? cantItems = null)
    {
        var val = questsActivos.Find(x => x.id == quest_ID);

        if (tipo == Quest.QuestTipo.Derrotar)
        {
            if(val.cantidadActual >= val.cantidadTotal)
            {
                Debug.LogWarning("¡Quest: " + db.misiones[val.id].nombre + "completada!");
                val.completada = true;
            }
            else
            {
                print("Aún no cumples el objetivo.");
            }
        }

        if (tipo == Quest.QuestTipo.Entregar)
        {
            if (val.destino.GetComponent<Destino_Script>().alcanzado)
            {
                Debug.LogWarning("¡Quest: " + db.misiones[val.id].nombre + "completada!");
                val.completada = true;
            }
            else
            {
                print("Aún no cumples el objetivo.");
            }
        }

        if(tipo == Quest.QuestTipo.Recolectar)
        {
            foreach (var item in val.itemsARecoger)
            {
                if (cantItems != null)
                {
                    if (cantItems == item.cantidad)
                    {
                        Debug.LogWarning("¡Quest: " + db.misiones[val.id].nombre + "completada!");
                        val.completada = true;
                    }
                    else
                    {
                        print("Aún no cumples el objetivo, te faltan: " + (item.cantidad - cantItems));
                    }
                }
            }
        }
    }

    public void VerificarItem(int item_ID)
    {
        Quest q = null;
        if (questsActivos.Count > 0)
        {
            if (questsActivos.Exists(x => x.itemsARecoger.Exists(a => a.itemID == item_ID)))
            {
                q = questsActivos.Find(x => x.itemsARecoger.Exists(a => a.itemID == item_ID));
            }
            else
            {
                q = null;
                return;
            }

            /*for (int i = 0; i < questsActivos.Count; i++)
            {
                if (q.itemsARecoger[0].itemID == item_ID && questsActivos[i].id == q.id)
                {
                    //ESTO SOLO FUNCIONA SI LAS QUESTS VAN EN ORDEN Y DE FORMA ASCENDENTE DESDE EL 0
                    int cantidad = DiscriminacionDeItems(db.misiones[questsActivos[i].id].Datos[0].itemID);
                    ActualizarQuest(questsActivos[i].id, questsActivos[i].tipo, cantidad);
                    q = null;
                    break;
                }*/
            //}
        }
    }

    /*public int DiscriminacionDeItems(int id)
    {
        int itemsMatched = 0;

        foreach(var item in GetComponent<Player>().InvLocal)
        {
            if(item.GetComponent<ItemSuelto>().ID == id)
            {
                itemsMatched++;
            }
        }

        return itemsMatched;
    }*/

}
