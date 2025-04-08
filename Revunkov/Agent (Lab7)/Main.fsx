#load "Agent.fsx"
open MyAgent.Agent
open MyAgent

let agent = startAgent ()

agent.Post (Print "Привет, агент!")
agent.Post (Print "Как дела?")
agent.Post Count
agent.Post Stop

System.Threading.Thread.Sleep(500)
