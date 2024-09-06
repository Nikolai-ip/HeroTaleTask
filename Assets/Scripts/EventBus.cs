using System;
using System.Collections.Generic;
using Signals;

public class EventBus
{
    private static readonly Dictionary<Type, List<Delegate>> _signalCallbacks = new();

    public static void Subscribe<T>(Action<T> callBack) where T : ISignal
    {
        var key = typeof(T);
        if (_signalCallbacks.ContainsKey(key))
            _signalCallbacks[key].Add(callBack);
        else
            _signalCallbacks.Add(key, new List<Delegate> { callBack });
    }

    public static void UnSubscribe<T>(Action<T> callBack) where T : ISignal
    {
        var key = typeof(T);
        if (_signalCallbacks.ContainsKey(key))
            _signalCallbacks[key].Remove(callBack);
        else
            throw new Exception($"The EventBus has not a value with the key: {key}");
    }

    public static void Invoke<T>(T signal) where T : ISignal
    {
        if (_signalCallbacks.TryGetValue(signal.GetType(), out var actions))
            InvokeActions(actions, signal);
        else
            throw new Exception($"The EventBus has not a value with the key: {signal.ToString()}");
    }

    private static void InvokeActions(List<Delegate> actions, ISignal signal)
    {
        for (var index = 0; index < actions.Count; index++)
        {
            var action = actions[index];
            action.DynamicInvoke(signal);
        }
    }
}