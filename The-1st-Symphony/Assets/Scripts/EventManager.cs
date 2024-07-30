using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;


public static class EventManager
{
//invoke calls event
public static event UnityAction<string, BouncePad> OnBouncePadHit;
public static void HitBouncePad(string s, BouncePad bp) => OnBouncePadHit?.Invoke(s, bp);
public static event UnityAction<string, bool> OnSignaled;
public static void SendSignal(string id, bool active) => OnSignaled?.Invoke(id, active);
}
