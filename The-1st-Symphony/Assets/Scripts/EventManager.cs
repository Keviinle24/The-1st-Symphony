using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public static class EventManager
{
//invoke calls event
public static event UnityAction<string, BouncePad> OnBouncePadHit;
public static void HitBouncePad(string s, BouncePad bp) => OnBouncePadHit?.Invoke(s, bp);
public static event UnityAction<string, bool> OnSignaled;
public static void SendSignal(string id, bool active) => OnSignaled?.Invoke(id, active);
public static event UnityAction<PlatformController> OnEnteredPlatform;
public static void EnteredPlatform(PlatformController pc) => OnEnteredPlatform?.Invoke(pc);
public static event UnityAction<PlatformController> OnExitedPlatform;
public static void ExitedPlatform(PlatformController pc) => OnExitedPlatform?.Invoke(pc);

public static event UnityAction<Vector2> OnTickVelocity;
public static void TickVelocity(Vector2 velocity) => OnTickVelocity?.Invoke(velocity);
}
