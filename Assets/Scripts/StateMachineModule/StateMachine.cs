using System;
using System.Collections.Generic;
using EntryPoint;
using Signals;
using UnityEngine;

public abstract class StateMachine : InitializeableMono
{
    private IState _currentState;
    protected List<IState> States = new();

    public IState CurrentState
    {
        get => _currentState;
        protected set
        {
            _currentState = value;
            EventBus.Invoke(new StateChangedSignal(_currentState.GetType()));
        }
    }

    protected void Update()
    {
        if (CurrentState !=null)
            CurrentState.Update();
    }

    public void ChangeState<T>() where T : IState
    {
        var newState = GetState<T>();
        if (newState != null)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
        else
        {
            throw new Exception($"State is not exist {typeof(T)}");
        }
    }

    protected IState GetState<T>() where T : IState
    {
        return States.Find(state => state.GetType() == typeof(T));
    }
}