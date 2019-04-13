using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public delegate void Event();
    private Dictionary<string, Event> dict;
    private static EventManager _instance = null;

    private EventManager() { dict = new Dictionary<string, Event>(); }

    private static EventManager Instance //Singleton
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventManager();
            }
            return _instance;
        }
    }

    public static void AddEvent(string name, Event action)
    {
        if (Instance.dict.ContainsKey(name))
        {
            Instance.dict[name] += action;
        }

        else
        {
            Instance.dict.Add(name, null);
            Instance.dict[name] += action;
        }
    }

    public static void RemoveEvent(string name, Event action)
    {
        if (Instance.dict.ContainsKey(name))
        {
            Instance.dict[name] -= action;
        }

        if (Instance.dict[name] == null)
            Instance.dict.Remove(name);
    }

    public static void TriggerEvent(string name)
    {
        Event eventHandler = null;
        if (Instance.dict.TryGetValue(name, out eventHandler))
            eventHandler();
    }
}