# Zaba+ Programming Language 🐸

**Version:** Beta 1.9

A simple, beginner-friendly programming language designed for creating interactive applications, games, and GUI programs with minimal syntax complexity. Features a custom IDE for writing and running Zaba+ code.

## 🎯 Overview

Zaba+ is an interpreted programming language built in C# that focuses on simplicity and ease of learning. It provides built-in modules for creating windows, graphics, games, and handling multimedia, making it perfect for educational purposes, game development, and rapid prototyping.

## 🖥️ IDE

Zaba+ comes with its own integrated development environment featuring:
- **Syntax Highlighting** - Color-coded keywords and syntax
- **Real-time Console** - See output as your program runs
- **Project System** - Organize your code files
- **Built-in Runner** - Execute code with one click

## ✨ Key Features

- **Simple Syntax** - Easy-to-understand code structure designed for beginners
- **GUI Module** - Built-in window creation and UI components
- **Game Development** - Complete game engine with physics and collision detection
- **Graphics System** - Shape rendering with textures and colors
- **Multimedia Support** - Audio playback with looping
- **Event-Driven** - Responsive event handling system
- **Real-time Execution** - Live updates and animations

## 📚 Language Syntax

### Comments
```zaba
// Single-line comment
// Everything after // is ignored
```

### Variables
```zaba
let score = 0           // Global variable
local name = "Player"   // Local scope variable
```

### Output
```zaba
pring "Hello World"     // Print to console
pring score             // Print variable value
pring "Score: " + score // Concatenation
```

### Control Flow

**If Statement:**
```zaba
if score > 100 [
    pring "You win!"
] else [
    pring "Keep trying"
]
```

**While Loop:**
```zaba
let counter = 0
while counter < 10 [
    pring counter
    counter = counter + 1
]
```

### Operators

**Arithmetic:**
- `+` Addition
- `-` Subtraction
- `*` Multiplication
- `/` Division

**Comparison:**
- `==` Equal to
- `!=` Not equal to
- `>` Greater than
- `<` Less than
- `>=` Greater or equal
- `<=` Less or equal

**Grouping:**
```zaba
let result = @ 5 + 3 @ * 2  // @ @ for grouping expressions
```

### Timers
```zaba
tick(1000) [
    pring "This runs every second"
]

waiting(3)  // Pause for 3 seconds
```

### Program Control
```zaba
stop:Program  // Stop execution
clear:Console // Clear console output
```

## 📦 Module: `window` - GUI Creation

### Import
```zaba
import window
```

### Creating Windows
```zaba
local form = window:CreateNewForm("My Application")
```

### Creating Buttons
```zaba
local button = window:CreateButton("Click Me!")
```

### Creating Labels
```zaba
local label = window:CreateLabel("Score: 0")
```

### Window Properties
```zaba
form.size = "800,600"        // Width, Height
form.bg = "lightblue"        // Background color
form.background = "#FF5733"  // Hex color
form.text = "New Title"      // Window title
```

### Button Properties
```zaba
button.pos = "100,50"        // X, Y position
button.size = "150,40"       // Width, Height
button.text = "Start Game"   // Button text
button.textcolor = "white"   // Text color
button.bg = "green"          // Background color
button.font = "Arial"        // Font family
button.fontsize = "14"       // Font size
```

### Label Properties
```zaba
label.pos = "20,20"
label.text = "Score: 100"
label.textcolor = "black"
label.textbg = "transparent" // Background (transparent or color)
label.font = "Courier New"
label.fontsize = "16"
```

### Event Handling
```zaba
button:OnClick [
    label.text = "Button was clicked!"
    pring "Click event fired"
]
```

### Removing Objects
```zaba
button:Remove  // Remove from window
```

## 🎮 Module: `zabgame` - Game Development

### Import
```zaba
import zabgame
```

### Creating Player
```zaba
zabgame:CreatePlayer("player", "player.png", 50, 50)
// Parameters: name, texture_file, width, height
```

### Creating Enemies
```zaba
zabgame:CreateEnemy("enemy", "enemy.png", 40, 40)
```

### Creating Platforms
```zaba
zabgame:CreatePlatform("ground", 0, 400, 800, 50)
// Parameters: name, x, y, width, height
```

### Movement Controls
```zaba
zabgame:EnableMovement("player", "arrows")  // Arrow keys
zabgame:EnableMovement("player", "wasd")    // WASD keys
```

### Physics
```zaba
zabgame:EnableGravity("player")  // Apply gravity to object
```

### Game Object Properties
```zaba
player.speed = 7        // Movement speed
player.health = 100     // Health points
player.pos = "100,200"  // Position
```

### Collision Detection
```zaba
zabgame:OnCollision("player", "enemy") [
    player.health = player.health - 10
    pring "Hit! Health: " + player.health
    
    if player.health <= 0 [
        pring "Game Over!"
        stop:Program
    ]
]
```

## 🎨 Module: `texturemodule` - Graphics & Textures

### Import
```zaba
import texturemodule
```

### Loading Textures
```zaba
local playerTexture = texturemodule.Texture("sprite.png")
```

### Creating Shapes
```zaba
part circle = shape("circle", "red", 100, 100)
part box = shape("rectangle", "blue", 150, 80)
part triangle = shape("triangle", "#00FF00", 120, 120)
// Parameters: shape_type, color, width, height
```

### Shape Properties
```zaba
circle.pos = "200,100"    // Position
circle.size = "150,150"   // Size
circle.color = "yellow"   // Color change
```

### Applying Textures
```zaba
circle:SetTexture(playerTexture)  // Apply texture to shape
circle:RemoveTexture              // Remove texture (show color)
```

## 🔊 Module: `soundservice` - Audio

### Import
```zaba
import soundservice
```

### Loading Sounds
```zaba
local bgMusic = soundservice.Sound("background.wav")
local clickSound = soundservice.Sound("click.wav")
```

### Sound Properties
```zaba
bgMusic.loop = true   // Enable looping
bgMusic.volume = 80   // Volume level
```

### Playback Control
```zaba
bgMusic:StartPlay()   // Start playing
bgMusic:StopPlay()    // Stop playing
```

## ⌨️ Keyboard Events

```zaba
onkey("Space") [
    pring "Space pressed!"
]

onkey("W") [
    player.pos = player.pos + ",5"
]

onkey("Escape") [
    stop:Program
]
```

**Supported Keys:** `W`, `A`, `S`, `D`, `Space`, `Escape`, `Enter`, arrow keys, and more.

## 💡 Complete Examples

### 1. Clicker Game
```zaba
// ZABA+ CLICKER GAME
import window

// Create UI
local form = window:CreateNewForm("ZABA+ CLICKER PRO")
local mainBtn = window:CreateButton("CLICK!")
local scoreLabel = window:CreateLabel("Score: 0")
local powerLabel = window:CreateLabel("Power: 1")
local upgradeBtn = window:CreateButton("Upgrade +1")
local megaBtn = window:CreateButton("MEGA +10")

// Setup window
form.size = "400,500"

// Setup positions
scoreLabel.pos = "20,20"
scoreLabel.font = "Arial"
scoreLabel.fontsize = "16"

powerLabel.pos = "20,50"
powerLabel.font = "Arial"
powerLabel.fontsize = "14"

mainBtn.pos = "100,100"
mainBtn.size = "200,80"
mainBtn.font = "Arial"
mainBtn.fontsize = "18"

upgradeBtn.pos = "50,250"
upgradeBtn.size = "150,50"

megaBtn.pos = "220,250"
megaBtn.size = "150,50"

// Game variables
let score = 0
let power = 1

// Main click handler
mainBtn:OnClick [
    score = score + power
    scoreLabel.text = "Score: " + score
]

// Upgrade handlers
upgradeBtn:OnClick [
    if score >= 10 [
        score = score - 10
        power = power + 1
        scoreLabel.text = "Score: " + score
        powerLabel.text = "Power: " + power
    ]
]

megaBtn:OnClick [
    if score >= 100 [
        score = score - 100
        power = power + 10
        scoreLabel.text = "Score: " + score
        powerLabel.text = "Power: " + power
    ]
]
```

### 2. Platform Game
```zaba
// PLATFORMER GAME
import window
import zabgame
import texturemodule
import soundservice

// Create game window
local form = window:CreateNewForm("Platform Adventure")
form.size = "800,600"
form.bg = "skyblue"

// Load assets
local playerTex = texturemodule.Texture("player.png")
local enemyTex = texturemodule.Texture("enemy.png")
local jumpSound = soundservice.Sound("jump.wav")

// Create game objects
zabgame:CreatePlayer("hero", "player.png", 50, 50)
zabgame:EnableMovement("hero", "arrows")
zabgame:EnableGravity("hero")

zabgame:CreateEnemy("monster", "enemy.png", 40, 40)
zabgame:CreatePlatform("ground", 0, 550, 800, 50)
zabgame:CreatePlatform("platform1", 200, 400, 150, 20)
zabgame:CreatePlatform("platform2", 500, 300, 150, 20)

// Set initial properties
hero.speed = 5
hero.health = 100
monster.pos = "600,500"

// Jump on space
onkey("Space") [
    jumpSound:StartPlay()
]

// Collision handling
zabgame:OnCollision("hero", "monster") [
    hero.health = hero.health - 25
    pring "Ouch! Health: " + hero.health
    
    if hero.health <= 0 [
        pring "GAME OVER"
        stop:Program
    ]
]
```

### 3. Animation Demo
```zaba
// ANIMATED SHAPES
import window

local form = window:CreateNewForm("Animation")
form.size = "600,400"
form.bg = "black"

part ball = shape("circle", "yellow", 50, 50)
ball.pos = "0,175"

let x = 0
let direction = 1

tick(16) [
    x = x + @ direction * 3 @
    
    if x > 550 [
        direction = -1
        ball.color = "red"
    ]
    
    if x < 0 [
        direction = 1
        ball.color = "yellow"
    ]
    
    ball.pos = x + ",175"
]
```

## 🏗️ Technical Architecture

### 1. **Lexer** (`Lexer.cs`)
- Tokenizes source code into tokens
- Tracks line and column numbers for error reporting
- Recognizes keywords, operators, literals, and identifiers
- Supports single-line comments (`//`)

### 2. **AST** (`AST.cs`)
- Defines Abstract Syntax Tree node types
- Statement nodes: `LetStmt`, `IfStmt`, `WhileStmt`, `TickStmt`, etc.
- Expression nodes: `NumberExpr`, `StringExpr`, `BinaryExpr`, `VarExpr`
- Game-specific nodes: `CreatePlayerStmt`, `OnCollisionStmt`, etc.

### 3. **Parser** (`Parser.cs`)
- Recursive descent parser
- Operator precedence handling
- Module-specific syntax parsing
- Property and method call parsing
- Block structure with `[` `]`

### 4. **Interpreter** (`ZabkaInterpreter.cs`)
- AST execution engine
- Variable environment management
- UI thread synchronization for GUI operations
- Event system (clicks, keys, collisions, timers)
- Resource management (textures, sounds, game objects)
- Physics simulation for game objects

## 🚀 Getting Started

1. **Download** the Zaba+ IDE from the [releases page](your-github-link)
2. **Open** the IDE
3. **Write** your code in the editor
4. **Click** the run button (▶️) to execute
5. **See** results in the console and GUI windows

## 📝 File Structure

```
YourProject/
│
├── main.zaba        # Your main code file
├── player.png       # Texture files
├── enemy.png
├── background.wav   # Sound files
└── click.wav
```

## 🛠️ Current Status (Beta 1.9)

**Working Features:**
- ✅ Complete syntax highlighting
- ✅ Variable declarations and assignments
- ✅ Arithmetic and logical operations
- ✅ Control flow (if/else, while loops)
- ✅ GUI creation and management
- ✅ Event handling (clicks, keyboard)
- ✅ Game objects with physics
- ✅ Collision detection system
- ✅ Texture loading and rendering
- ✅ Sound playback with looping
- ✅ Timer-based execution
- ✅ Shape rendering

**Known Limitations:**
- No custom functions/procedures yet
- No arrays or complex data structures
- Limited file I/O operations
- No networking capabilities
- Single-threaded execution

## 🎯 Roadmap

- [ ] User-defined functions
- [ ] Arrays and lists
- [ ] File reading/writing
- [ ] More physics features (velocity, forces)
- [ ] Particle systems
- [ ] Animation system
- [ ] Better error messages with stack traces
- [ ] Debugger with breakpoints
- [ ] Code completion in IDE
- [ ] More built-in shapes and effects

## 🤝 Contributing

Contributions are welcome! Feel free to:
- Report bugs
- Suggest features
- Submit pull requests
- Improve documentation
- Share your Zaba+ projects


## 🌟 Showcase

Share your Zaba+ creations! Tag them with `#ZabaPlus` or `#ZabaProgramming`

---

**Made with 🐸 and ❤️**

*Zaba+ - Programming made simple and fun!*
