
# Zaba+
A new programming language!

Hello, you using **zaba+**, you need to know command meaning.(THIS IS ALL COMANDS!)

- `pring "Hello frog!"` OR `2*56` — text or number that is output to the console  
- `local Name = "Zabka"` — declared only in this function  
- `let Name = "Frog"` — declared throughout the code  
- `if Name == "Zabka"[pring Name]` — the usual if  
- `else [pring "Frog"]` — the usual else  

### Imports
  ### window import
  - `import` — importing something like window, zabgame
  - `:CreateNewForm("My game")` — creating new form (you can set it)  
  - `:CreateButton("Click!")` — creating new button  
  - `:OnClick [pring "Clicked!"]` — click event  
  - `:CreateLabel("Score: 0")` — creating new label
  ### zabgame import
  - `:CreatePlayer("Zaba")` — creating player
  - `:CreateEnemy("250","250")` — creating enemy
  - `:CreatePart("Part")` — creating part
  - `ArrowLeft:OnKey [pring "Zaba " + "Good!"]` — Key function
  - `move name left "10"` — move something
  - `bullet.Color = fromRGB(250,250,100)` — color change

### Loops & Waiting
- `while score [pring "Hi"]` — the usual while  
- `waiting(10)` — wait command  

### Other commands
- `stop:Program` — stopping program  
- `clear:Console` — clears console  
- `func Zaba() [pring "Hello"]` — make a function  
- `return` — the usual return  
