using System;
using System.Collections.Generic;

namespace SimpleState {
public class StateMachine
{
    public List<State> states;
    public State current; 

    public void Update(float dt) {
        current.Update(dt);
    }

    public void changeState(string name) {
        if(validNextState(name)) {
            string previous = current.name;
            current.Exit(name);
            current = this.getState(name);
            current.Enter(previous);
        }
    }

    private State getState(string name) 
    {
        foreach(State state in states) {
            if ( state.name == name ) {
                return state;
            }
        }
        return null;
    }

    private bool validNextState(string next)
    {
        return current.next_states.Contains(next);
    }
}
}