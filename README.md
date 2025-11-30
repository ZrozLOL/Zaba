# Zaba+ Programming Language 🐸

**Version:** Beta 2.0

A beginner-friendly programming language for creating interactive applications, games, and GUI programs with minimal syntax. Features a custom IDE with syntax highlighting, real-time execution, and powerful built-in modules.

---

## 🎯 Overview

Zaba+ is an interpreted language built in C# that focuses on **simplicity and rapid prototyping**. Perfect for:
- Educational programming courses
- Game development beginners
- Rapid GUI application prototyping
- Creative coding experiments

---

## 🖥️ Integrated Development Environment

The Zaba+ IDE includes:

| Feature | Description |
|---------|-------------|
| **Syntax Highlighting** | Color-coded keywords, strings, numbers, and comments |
| **Variable Detection** | Automatic highlighting of `let` (global) and `local` (scoped) variables |
| **Real-time Console** | Live output with status indicators (✔/❌/🛑) |
| **Code Search** | Find and navigate through your code with Ctrl+F |
| **Project System** | Save/load `.zab+` project files with asset management |
| **Build to EXE** | Export standalone executables (Windows) |
| **Plugin Marketplace** | Extend functionality with community plugins |

---

## ✨ Key Features

### Language Features
- **Simple Syntax** - Easy-to-read code designed for beginners
- **Dynamic Typing** - No complex type declarations
- **Event-Driven** - Responsive callbacks for UI, keyboard, and collisions
- **Real-time Execution** - Immediate feedback and live updates

### Built-in Modules
- `window` - GUI creation (forms, buttons, labels, textboxes)
- `zabgame` - Game engine (physics, collisions, sprites)
- `texturemodule` - Graphics and texture management
- `soundservice` - Audio playback with looping

### Advanced Features
- **Canvas Drawing** - Lines, rectangles, custom graphics
- **3D World Renderer** - Basic voxel-style 3D graphics
- **Custom Functions** - Define reusable code blocks with parameters
- **Plugin System** - Extend language with C# DLL plugins

---

## 📚 Language Syntax

### Comments
```zaba
// Single-line comments
// Everything after // is ignored
```

### Variables
```zaba
let score = 0           // Global variable (accessible everywhere)
local name = "Player"   // Local scope variable (function/block only)
```

### Output
```zaba
pring "Hello World"     // Print to console
pring score             // Print variable value
pring "Score: " + score // String concatenation
```

---

## 🎛️ Control Flow

### If/Else Statement
```zaba
if score > 100 [
    pring "You win!"
] else [
    pring "Keep trying"
]
```

### While Loop
```zaba
let counter = 0
while counter < 10 [
    pring counter
    counter = counter + 1
]
```

### Comparison Operators
```zaba
==  // Equal to
!=  // Not equal to
>   // Greater than
<   // Less than
>=  // Greater or equal
<=  // Less or equal
```

### Math Operators
```zaba
+   // Addition
-   // Subtraction
*   // Multiplication
/   // Division
@   // Grouping (like parentheses)

let result = @ 5 + 3 @ * 2  // result = 16
```

---

## ⏱️ Timers & Delays

### Repeating Timer (tick)
```zaba
tick(1000) [
    pring "This runs every second"
]
```

### One-time Delay (waiting)
```zaba
pring "Starting..."
waiting(3)  // Pause for 3 seconds
pring "Done!"
```

---

## 🔧 Functions

### Defining Functions
```zaba
function greet(name) [
    pring "Hello, " + name
]

function add(a, b) [
    let result = a + b
    pring result
]
```

### Calling Functions
```zaba
greet("Alice")    // Output: Hello, Alice
add(5, 3)         // Output: 8
```

---

## 🧮 Math Functions

```zaba
cos(angle)    // Cosine
sin(angle)    // Sine
tan(angle)    // Tangent
sqrt(number)  // Square root
abs(number)   // Absolute value
floor(number) // Round down
pi            // Pi constant (3.14159...)
```

### Random Numbers
```zaba
let dice = random(1-6)      // Random number 1-6
let color = random(0-255)   // Random 0-255
```

---

## 🪟 Module: `window` - GUI Creation

### Import
```zaba
import window
```

### Creating Windows
```zaba
local form = window:CreateNewForm("My Application")
form.size = "800,600"         // Width, Height
form.bg = "lightblue"         // Background color
form.background = "#FF5733"   // Hex color
form.text = "New Title"       // Window title
```

### Creating Buttons
```zaba
local button = window:CreateButton("Click Me!")
button.pos = "100,50"         // X, Y position
button.size = "150,40"        // Width, Height
button.text = "Start Game"    // Button text
button.textcolor = "white"    // Text color
button.bg = "green"           // Background color
button.font = "Arial"         // Font family
button.fontsize = "14"        // Font size
```

### Creating Labels
```zaba
local label = window:CreateLabel("Score: 0")
label.pos = "20,20"
label.text = "Score: 100"
label.textcolor = "black"
label.textbg = "transparent"  // Background (transparent or color)
label.font = "Courier New"
label.fontsize = "16"
```

### Creating Textboxes
```zaba
local input = window:CreateTextbox("Enter name...", "")
input.pos = "50,50"
input.size = "200,30"
input.textcolor = "black"
input.bg = "white"
```

### Event Handling
```zaba
button:OnClick [
    label.text = "Button was clicked!"
    pring "Click event fired"
]

input:TextChanged [
    pring "User typed: " + input.text
]
```

### Removing Objects
```zaba
button:Remove  // Remove from window
```

---

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
player.speed = 7         // Movement speed
player.health = 100      // Health points
player.pos = "100,200"   // Position
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

---

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
circle.color = "yellow"   // Change color
```

### Applying Textures
```zaba
circle:SetTexture(playerTexture)  // Apply texture to shape
circle:RemoveTexture              // Remove texture (show color)
```

---

## 🎨 Canvas Drawing

### Creating Canvas
```zaba
local canvas = window:CreateCanvas(800, 600)
canvas.pos = "0,0"
```

### Drawing Commands
```zaba
// Draw line
canvas:DrawLine(50, 50, 200, 200, "white")

// Draw rectangle outline
canvas:DrawRect(100, 100, 150, 80, "red")

// Draw filled rectangle
canvas:FillRect(300, 100, 150, 80, "blue")

// Clear canvas
canvas:Clear()
```

---

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
bgMusic.volume = 80   // Volume level (0-100)
```

### Playback Control
```zaba
bgMusic:StartPlay()   // Start playing
bgMusic:StopPlay()    // Stop playing
```

---

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

**Supported Keys:** `W`, `A`, `S`, `D`, `Space`, `Escape`, `Enter`, `Left`, `Right`, `Up`, `Down`, and more.

---

## 🖱️ Mouse Events

```zaba
onmouse(leftclick) [
    pring "Clicked at: " + mouseX + ", " + mouseY
]

onmouse(rightclick) [
    pring "Right click detected"
]
```

---

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

### 4. Drawing App
```zaba
import window

local form = window:CreateNewForm("Paint")
form.size = "800,600"

local canvas = window:CreateCanvas(800, 600)

let drawing = false
let lastX = 0
let lastY = 0

onmouse(leftclick) [
    drawing = true
    lastX = mouseX
    lastY = mouseY
]

tick(10) [
    if drawing == true [
        canvas:DrawLine(lastX, lastY, mouseX, mouseY, "white")
        lastX = mouseX
        lastY = mouseY
    ]
]
```

---

## 🏗️ Technical Architecture

### 1. **Lexer** (`Lexer.cs`)
- Tokenizes source code into keywords, operators, literals
- Tracks line/column numbers for error reporting
- Supports comments (`//`)

### 2. **Parser** (`Parser.cs`)
- Recursive descent parser
- Builds Abstract Syntax Tree (AST)
- Handles operator precedence
- Parses module-specific syntax

### 3. **AST** (`AST.cs`)
- Defines node types for statements and expressions
- Statement nodes: `LetStmt`, `IfStmt`, `WhileStmt`, `FunctionDeclStmt`
- Expression nodes: `NumberExpr`, `BinaryExpr`, `FunctionCallExpr`

### 4. **Interpreter** (`ZabkaInterpreter.cs`)
- Executes AST nodes
- Manages variable environments (global/local scopes)
- Handles UI thread synchronization for GUI operations
- Event system (clicks, keys, collisions, timers)
- Resource management (textures, sounds, game objects)

### 5. **Plugin System** (`PluginManager.cs`)
- Loads C# DLL plugins from `Plugins/` folder
- Interface: `IZabaPlugin`
- Plugins can add custom commands and functionality

---

## 🚀 Getting Started

1. **Download** the Zaba+ IDE from releases
2. **Open** the IDE
3. **Write** your code in the editor
4. **Click** the run button (▶️) to execute
5. **See** results in the console and GUI windows

---

## 📝 File Structure

```
YourProject/
│
├── main.zab+        # Your main code file
├── player.png       # Texture files
├── enemy.png
├── background.wav   # Sound files
└── click.wav
```

When you save a project, all assets (images, sounds) should be in the same folder as your `.zab+` file.

---

## 🛠️ Build to Executable

1. **Save** your project (File → Save Project)
2. **Export** (File → Export to EXE)
3. Find your `.exe` in the `build/` folder
4. **Share** the entire `build/` folder (includes runtime and assets)

---

## 🔌 Plugin Development

Create custom Zaba+ plugins in C#:

```csharp
using Zaba_.PluginBase;

public class MyPlugin : IZabaPlugin
{
    public string Name => "myplugin";
    public string Version => "1.0.0";
    public string Author => "Your Name";
    public string Description => "My custom plugin";

    private ZabkaInterpreter interpreter;

    public void Initialize(ZabkaInterpreter interp)
    {
        interpreter = interp;
    }

    public void RegisterCommands()
    {
        // Your custom commands here
    }

    public void Cleanup()
    {
        // Cleanup resources
    }

    // Custom methods callable from Zaba+
    public void MyCustomMethod(string arg)
    {
        interpreter.AppendOutput("Plugin says: " + arg + "\n");
    }
}
```

**Usage in Zaba+:**
```zaba
import myplugin
myplugin:MyCustomMethod("Hello!")
```

---

## 🎯 Current Status (Beta 2.0)

### ✅ Working Features
- Complete syntax highlighting with variable detection
- Variable declarations (`let`, `local`) with proper scoping
- Arithmetic, logical, and comparison operations
- Control flow (`if`/`else`, `while` loops)
- Custom functions with parameters
- GUI creation and management (`window` module)
- Event handling (clicks, keyboard, mouse, collisions)
- Game objects with physics and gravity
- Collision detection system
- Texture loading and rendering
- Sound playback with looping support
- Timer-based execution (`tick`)
- Canvas drawing (lines, rectangles, shapes)
- 3D voxel world renderer
- Arrays and array access
- Math functions (sin, cos, sqrt, etc.)
- Random number generation
- Plugin system for extensibility
- Export to standalone `.exe`

### 🔧 Known Limitations
- No file I/O operations yet
- No networking capabilities
- Single-threaded execution
- Limited 3D rendering (voxel-based only)
- No debugger with breakpoints

---

## 🗺️ Roadmap

- [ ] **File I/O** - Read/write text files
- [ ] **Lists/Collections** - Dynamic arrays with methods
- [ ] **String Methods** - Split, substring, replace, etc.
- [ ] **Better Error Messages** - Stack traces and line highlighting
- [ ] **Debugger** - Breakpoints and step-through execution
- [ ] **Code Completion** - IntelliSense-style autocomplete
- [ ] **More Physics** - Velocity, forces, friction
- [ ] **Particle Systems** - Visual effects
- [ ] **Animation System** - Sprite animation support
- [ ] **Networking** - HTTP requests and WebSocket support
- [ ] **Database** - SQLite integration

---

## 🤝 Contributing

Contributions are welcome! You can:

- **Report bugs** - Open an issue on GitHub
- **Suggest features** - Share your ideas
- **Submit pull requests** - Improve code or documentation
- **Create plugins** - Extend Zaba+ functionality
- **Share projects** - Showcase what you've built

---

## 📖 Documentation

### Error Messages
- `❌ Module 'X' not imported` - Add `import X` at the top
- `❌ Object 'X' not found` - Check variable/object name spelling
- `❌ Expected X, got Y` - Syntax error, check brackets/operators
- `❌ Undefined var X` - Variable not declared with `let` or `local`

### Best Practices
1. Use `local` for temporary variables inside functions
2. Use `let` for global game state (score, health, etc.)
3. Place `import` statements at the top of your file
4. Test with small code snippets before building large projects
5. Use descriptive variable names

---

## 🌟 Showcase

Share your Zaba+ creations!  
Tag them with **#ZabaPlus** or **#ZabaProgramming**

---

## 📄 License

Zaba+ is open-source software. Check the repository for license details.

---

## 💬 Community

- **GitHub Issues** - Report bugs and request features
- **Discussions** - Ask questions and share ideas
- **Plugin Marketplace** - Browse and install community plugins

---

**Made with 🐸 and ❤️**

*Zaba+ - Programming made simple and fun!*
