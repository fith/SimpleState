using System;
using System.Collections.Generic;

namespace SimpleState {
public class State
{
    public string name;
    public List<string> next_states;
    public Action<string> enter;
    public Action<float> update;
    public Action<string> exit;

    public void Enter(string previous)
    {
        if(enter != null) {
            enter(previous);
        }
    }

    public void Update(float dt)
    {
        if(update != null) {
            update(dt);
        }
    }

    public void Exit(string next)
    {
        if(exit != null) {
            exit(next);
        }
    }
}
}