# 🐸 Zaba+ Programming Language

A beginner-friendly interpreted language for building games, GUI apps, and interactive programs — with minimal syntax and a built-in IDE.

> For full feature details and what's new in each version, see the **Release Notes**.

---

## 🚀 Quick Start

1. Download and extract `Zaba+.zip`
2. Run `Zaba+.exe`
3. Create or open a project
4. Write code, hit ▶️, see results

---

## 📝 Core Syntax

```zaba
// Comments
let score = 0          // global variable
local name = "Player"  // scoped variable

pring "Hello, " + name // print output

// If / else
if score > 10 [
    pring "Nice!"
] elseif score > 0 [
    pring "OK"
] else [
    pring "Zero"
]

// Loops
while score < 100 [
    score++
]

for i = 0 to 10 [
    pring i
]

foreach item in myArray [
    pring item
]

// Functions
function greet(name) [
    pring "Hello, " + name
]
greet("Alice")

// Error handling
try [
    let x = 10 / 0
] catch [
    pring "Error caught"
]
```

---

## 📦 Built-in Modules

| Module | What it does |
|---|---|
| `window` | GUI — forms, buttons, labels, textboxes, canvas |
| `zabgame` | 2D/3D game engine — sprites, physics, collisions |
| `texturemodule` | Textures and shapes |
| `soundservice` | Audio playback |
| `os` | File system — read, write, delete |

Import at the top of your file:
```zaba
import window
import zabgame
```

---

## 🎛️ Language Features at a Glance

**Variables & Types:** `let` (global), `local` (scoped), `true`/`false`, `null`

**Operators:** `+ - * /`, `== != > < >= <=`, `and`, `or`, `not`, `++`, `--`, `+=`, `-=`, `*=`, `/=`, `??`

**Arrays:** `let a = [1, 2, 3]` · `a[0]` · `a.add(x)` · `a.remove(x)` · `a.clear()`

**Math:** `sin` `cos` `tan` `sqrt` `abs` `floor` `pi` `random(1-6)`

**Control flow:** `if` `elseif` `else` `while` `for` `foreach` `switch/case/default` `break` `continue` `return`

**Events:** `onkey("Space") [...]` · `onmouse(leftclick) [...]` · `tick(ms) [...]` · `waiting(sec)`

**Other:** `typeof` · `stop:Program` · `//` comments · escape sequences `\n \t \"`

---

## 🎮 Game Engine (`zabgame`)

```zaba
zabgame:CreatePlayer("hero", "player.png", 64, 64)
zabgame:CreateEnemy("enemy", "enemy.png", 40, 40)
zabgame:CreatePlatform("ground", 0, 550, 800, 30)
zabgame:EnableGravity("hero")
zabgame:EnableMovement("hero", "arrows")

zabgame:OnCollision("hero", "enemy") [
    pring "Hit!"
]

// 3D voxel world
zabgame:Create3DWorld("world", 800, 600)
zabgame:CreateBlock("world", 0, 0, 10, 1)
zabgame:RenderWorld("world", "myCanvas")
```

---

## 🖼️ GUI & Canvas

```zaba
local form = window:CreateNewForm("My App")
form.size = "800,600"

local btn = window:CreateButton("Click me")
btn.pos = "100,100"
btn:OnClick [
    pring "Clicked!"
]

local canvas = window:CreateCanvas(800, 600)
canvas:DrawLine(0, 0, 100, 100, "white")
canvas:FillRect(50, 50, 100, 100, "blue")
canvas:Clear()
```

---

## 🔌 Plugin System

Drop a `.dll` into your project's `Plugins/` folder. Plugins implement `IZabaPlugin` (C#) with `Initialize`, `RegisterCommands`, and `Cleanup`. Browse community plugins via the **Plugin Marketplace** in the IDE.

---

## 🏗️ Build & Export

- **Run:** ▶️ button in the IDE
- **Export to EXE:** Build → Export to EXE (Windows only)
- **Clean:** Build → Clean

Project structure:
```
MyProject/
├── MyProject.zab+
├── player.png
└── Plugins/
```

---

## 📄 More Info

- Full syntax reference and examples → **Release Notes**
- Bug reports & features → GitHub Issues
- Community plugins → Plugin Marketplace

*Made with ❤️ by the Zaba+ community* 🐸
