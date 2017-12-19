using System;
using System.Collections.Generic;

namespace SimpleState {
public class State
{
    public string name;
    public List<string> next_states;
    Action<string> enter;
    Action<float> update;
    Action<string> exit;

    public void Enter(string previous)
    {
        enter(previous);
    }

    public void Update(float dt)
    {
        update(dt);
    }

    public void Exit(string next)
    {
        exit(next);
    }
}
}