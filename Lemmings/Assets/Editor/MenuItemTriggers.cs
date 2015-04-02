using UnityEngine;
using UnityEditor;
using System.Collections;

public class MenuItemTriggers : MonoBehaviour
{

    // LEMMINGS
    [MenuItem("Custom Objects/Lemmings/LemmingsBounce")]
    private static void CreateBounceLemmings()
    {
        Object o = Resources.Load("Prefabs/Lemmings/LemmingsBounce");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/Lemmings/LemmingsGravity")]
    private static void CreateGravityLemmings()
    {
        Object o = Resources.Load("Prefabs/Lemmings/LemmingsGravity");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/Lemmings/LemmingsLove")]
    private static void CreateLoveLemmings()
    {
        Object o = Resources.Load("Prefabs/Lemmings/LemmingsLove");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/Lemmings/LemmingsNeutral")]
    private static void CreateNeutralLemmings()
    {
        Object o = Resources.Load("Prefabs/Lemmings/LemmingsNeutral");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/Lemmings/LemmingsPlatform")]
    private static void CreatePlatformLemmings()
    {
        Object o = Resources.Load("Prefabs/Lemmings/LemmingsPlatform");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Lemmings/LemmingsPoison")]
    private static void CreatePoisonLemmings()
    {
        Object o = Resources.Load("Prefabs/Lemmings/LemmingsPoison");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Lemmings/LemmingsStone")]
    private static void CreateStoneLemmings()
    {
        Object o = Resources.Load("Prefabs/Triggers/LemmingsStone");
        InstantiateObject(o);
    }

    // Triggers lemmings
    [MenuItem("Custom Objects/Lemmings trigger/OnLemmings/LemmingsBounceTrigger")]
    private static void CreateBounceLemmingsTrigger()
    {
        Object o = Resources.Load("Prefabs/Triggers/OnLemmings/LemmingsTriggerBouncer");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Lemmings trigger/OnLemmings/LemmingsLoveTrigger")]
    private static void CreateLoveLemmingsTrigger()
    {
        Object o = Resources.Load("Prefabs/Triggers/OnLemmings/LemmingsTriggerLove");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Lemmings trigger/OnLemmings/LemmingsStone")]
    private static void CreateStoneLemmingsTrigger()
    {
        Object o = Resources.Load("Prefabs/Triggers/OnLemmings/LemmingsTriggerStone");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/Lemmings trigger/OnMaps/LemmingsPlatform")]
    private static void CreatePlatformLemmingsTrigger()
    {
        Object o = Resources.Load("Prefabs/Triggers/OnMaps/LemmingsCreatePlatform");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/Lemmings trigger/OnMaps/LemmingsGravity")]
    private static void CreateGravityLemmingsTrigger()
    {
        Object o = Resources.Load("Prefabs/Triggers/OnMaps/LemmingsTriggerGravity");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/Lemmings trigger/OnMaps/LemmingsPoison")]
    private static void CreatePoisonLemmingsTrigger()
    {
        Object o = Resources.Load("Prefabs/Triggers/OnMaps/LemmingsTriggerPoisoned");
        InstantiateObject(o);
    }
   
    // CREATE TRIGGER
    [MenuItem("Custom Objects/TRIGGERS/Interuptor/InteruptorCreatePlatform")]
    private static void CreatePlatform()
    {
        Object o = Resources.Load("Prefabs/Interuptor/InteruptorCreatePlatform");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/TRIGGERS/Interuptor/InteruptorGravity")]
    private static void CreateGravity()
    {
        Object o = Resources.Load("Prefabs/Interuptor/InteruptorGravity");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/TRIGGERS/Interuptor/InteruptorStone")]
    private static void CreateInteruptorStone()
    {
        Object o = Resources.Load("Prefabs/Interuptor/InteruptorStone");
        InstantiateObject(o);
    }
     // PALTFORM
    [MenuItem("Custom Objects/TRIGGERS/Platforms/PlatformAppear")]
    private static void CreatePlatformAppear()
    {
        Object o = Resources.Load("Prefabs/Interuptor/PlatformAppear");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/TRIGGERS/Interuptor/PlatformMoving")]
    private static void CreatePlatformMoving()
    {
        Object o = Resources.Load("Prefabs/Interuptor/InteruptorGravity");
        InstantiateObject(o);
    }
    
    [MenuItem("Custom Objects/TRIGGERS/Interuptor/PointToReach")]
    private static void CreatePointToReach()
    {
        Object o = Resources.Load("Prefabs/Interuptor/PointToReach");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/TRIGGERS/Areas/WaterArea")]
    private static void CreateWaterTrigger()
    {
        Object o = Resources.Load("Prefabs/Triggers/WaterArea/WaterCollision");
        InstantiateObject(o);
    }
  
    private static void InstantiateObject(Object o)
    {
        GameObject g = Instantiate(o, Vector3.zero, Quaternion.identity) as GameObject;

        if (SelectParentObject() != null)
            g.transform.parent = SelectParentObject().transform;

        FocusObject(g);
    }

    private static void FocusObject(GameObject g)
    {
        GameObject[] gArray = new GameObject[1];
        gArray[0] = g;
        Selection.objects = gArray;
    }

    private static GameObject SelectParentObject()
    {
        return Selection.activeObject as GameObject;
    }
}