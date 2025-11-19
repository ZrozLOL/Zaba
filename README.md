# Zaba+ Programming Language - Complete Documentation v2.0

**Zaba+** is a simple, beginner-friendly programming language with syntax optimized for creating GUI applications and games.

---

## 📌 Basic Syntax

### Output to Console
```zaba
pring "Hello frog!"
pring 2 * 56
pring x + y
```
- Outputs text or expressions to console
- Supports strings, numbers, and arithmetic
- Automatically adds newline after each output

### Variables
```zaba
local score = 0        // Local variable (function scope)
let name = "Zabka"     // Global variable
score = score + 10     // Assignment (updates existing variable)
```

**Variable Rules:**
- `local` creates a new variable in current scope
- `let` creates a global variable
- Variable names must start with a letter
- Can contain letters and numbers (e.g., `score1`, `playerX`)

### Comments
```zaba
// This is a single-line comment
pring "Hello"  // Comment after code
```

---

## 🔢 Data Types

### Numbers
```zaba
let age = 25
local count = 0
```

### Strings
```zaba
let name = "Zabka"
let message = "Score: "
pring "Hello, " + name  // Concatenation
```

### Boolean Values
```zaba
let isReady = true
let isGameOver = false
```

---

## 📐 Operators

### Arithmetic Operators
```zaba
pring 10 + 5      // 15 (addition)
pring 10 - 5      // 5 (subtraction)
pring 10 * 5      // 50 (multiplication)
pring 10 / 5      // 2 (division)
```

### Comparison Operators
```zaba
pring 10 > 5      // 1 (true)
pring 10 < 5      // 0 (false)
pring 10 == 10    // 1 (equal)
pring 10 != 5     // 1 (not equal)
pring 10 >= 10    // 1 (greater or equal)
pring 5 <= 10     // 1 (less or equal)
```

**Note:** In Zaba+, `1` = true, `0` = false

### Grouping with `@...@`
```zaba
pring @10 + 5@ * 2      // Result: 30
pring 10 + 5 * 2        // Result: 20
```

---

## 🔀 Control Flow

### Conditionals
```zaba
if score > 100 [
    pring "You won!"
]

if score > 100 [
    pring "You won!"
] else [
    pring "Keep trying"
]
```

### Loops
```zaba
while score < 100 [
    score = score + 1
    pring score
]
```

---

## ⏱️ Timing & Control

### Waiting
```zaba
pring "Starting..."
waiting(3)              // Wait 3 seconds
pring "Done!"
```

### Timers (Tick)
```zaba
tick(1000) [            // Execute every 1000ms
    pring "Tick!"
]
```

### Program Control
```zaba
stop:Program        // Stop execution
clear:Console       // Clear console output
```

---

## 🖼️ GUI Module (`window`)

### Import and Setup
```zaba
import window

local myForm = window:CreateNewForm("My Application")
```

### Creating Controls

#### Forms
```zaba
local form1 = window:CreateNewForm("Main Window")
```

#### Buttons
```zaba
local btn1 = window:CreateButton("Click me!")
```

#### Labels
```zaba
local lbl1 = window:CreateLabel("Score: 0")
```

---

## 🎨 Control Properties

### Position (`pos`)
```zaba
btn.pos = "100,50"       // x=100, y=50
```

### Size (`size`)
```zaba
btn.size = "120,40"      // width=120, height=40
```

### Text (`text`)
```zaba
btn.text = "Start Game"
lbl.text = "Score: " + score
```

### Background Color (`bg`)
```zaba
myForm.bg = "lightblue"
myForm.bg = "#FF5733"    // Hex color
```

### Font Properties
```zaba
btn.font = "Arial"
lbl.fontsize = "14"
```

### Text Styling (NEW!)
```zaba
// Text color
lbl.textcolor = "red"
lbl.textcolor = "#FF5733"
lbl.textcolor = "Transparent"  // Invisible text

// Text background
lbl.textbg = "yellow"
lbl.textbg = "#FFFF00"
lbl.textbg = "Transparent"     // Transparent background
```

---

## 🎯 Events

### Button Click Events
```zaba
btn:OnClick [
    score = score + 1
    pring "Clicked!"
]
```

### Keyboard Events
```zaba
onkey("W") [
    pring "W pressed"
]

onkey("Space") [
    pring "Space pressed"
]
```

**Available Keys:** A-Z, Space, Enter, ArrowUp, ArrowDown, ArrowLeft, ArrowRight, F1-F12

---

## 🎨 Graphics Module (`part`)

### Creating Shapes
```zaba
import window

local myForm = window:CreateNewForm("Shapes Demo")

part circle1 = shape("circle", "red", 100, 100)
part rect1 = shape("rectangle", "blue", 150, 80)
part tri1 = shape("triangle", "#00FF00", 120, 120)
```

**Supported Shapes:**
- `"circle"` — круг
- `"rectangle"` — прямокутник
- `"triangle"` — трикутник

### Shape Properties

```zaba
circle1.pos = "200,150"
circle1.size = "150,150"
circle1.color = "yellow"
```

### Removing Shapes
```zaba
circle1:Remove
```

---

## 🎨 Texture Module (`texturemodule`) - NEW!

### Import Module
```zaba
import texturemodule
```

### Loading Textures
```zaba
// Load texture from project folder
local playerTex = texturemodule.Texture("player.png")
local bgTex = texturemodule.Texture("background.jpg")
```

**Supported Formats:** `.png`, `.jpg`, `.jpeg`, `.bmp`

### Applying Textures to Shapes
```zaba
part player = shape("rectangle", "white", 80, 80)
player.pos = "100,100"

// Apply texture
player:SetTexture(playerTex)
```

### Texture Properties
```zaba
// Size (optional - for reference only)
playerTex.size = "80,80"

// Position (optional - for reference only)
playerTex.pos = "100,100"
```

**Note:** Texture automatically stretches to fill the shape

### Removing Textures
```zaba
player:RemoveTexture()  // Remove texture, show shape color
```

### Complete Texture Example
```zaba
import window
import texturemodule

local form = window:CreateNewForm("Texture Demo")

// Create shape
part sprite = shape("rectangle", "white", 64, 64)
sprite.pos = "200,200"

// Load and apply texture
local tex = texturemodule.Texture("sprite.png")
sprite:SetTexture(tex)

// Change texture on click
local btn = window:CreateButton("Change")
btn:OnClick [
    local newTex = texturemodule.Texture("sprite2.png")
    sprite:SetTexture(newTex)
]
```

---

## 🔊 Sound Module (`soundservice`) - NEW!

### Import Module
```zaba
import soundservice
```

### Loading Sounds
```zaba
// Load sound from project folder
local bgMusic = soundservice.Sound("music.wav")
local jumpSound = soundservice.Sound("jump.wav")
```

**Supported Formats:** `.wav` (recommended), `.mp3`

### Playing Sounds
```zaba
// Play once
jumpSound:StartPlay()

// Stop sound
bgMusic:StopPlay()
```

### Sound Properties

#### Loop
```zaba
// Enable looping
bgMusic.loop = true
bgMusic:StartPlay()  // Will play forever

// Disable looping
bgMusic.loop = false
```

#### Volume
```zaba
// Set volume (0-100)
bgMusic.volume = "50"
jumpSound.volume = "80"
```

**Note:** Volume control has limited support with current audio system

### Complete Sound Example
```zaba
import window
import soundservice

local form = window:CreateNewForm("Sound Demo")

// Load sounds
local music = soundservice.Sound("background.wav")
local click = soundservice.Sound("click.wav")

// Setup background music
music.loop = true
music.volume = "30"
music:StartPlay()

// Button with click sound
local btn = window:CreateButton("Click Me")
btn:OnClick [
    click:StartPlay()
]

// Stop music button
local btnStop = window:CreateButton("Stop Music")
btnStop:OnClick [
    music:StopPlay()
]
```

---

## 📁 Project System

### Project Structure

All files are in ONE folder (no subfolders):

```
ZabaPlus.exe
Projects/
├── MyGame/
│   ├── MyGame.zab+
│   ├── player.png
│   ├── enemy.png
│   ├── music.wav
│   └── jump.wav
└── Calculator/
    └── Calculator.zab+
```

### Creating Projects

1. Click **File → Save**
2. Enter project name (e.g., "MyGame")
3. Folder `Projects/MyGame/` is created automatically
4. File saved as `MyGame.zab+` inside

### Adding Assets

Simply copy texture and sound files into your project folder:
- Textures: `player.png`, `background.jpg`, etc.
- Sounds: `music.wav`, `jump.wav`, etc.

### Loading Projects

1. Click **File → Load**
2. Navigate to `Projects/YourProject/`
3. Select `.zab+` file
4. Project loads with access to all assets in that folder

---

## 💡 Complete Examples

### Example 1: Textured Game Character

```zaba
import window
import texturemodule
import soundservice

local form = window:CreateNewForm("Character Demo")
form.bg = "#87CEEB"

// Create player with texture
part player = shape("rectangle", "white", 64, 64)
player.pos = "250,300"

local playerTex = texturemodule.Texture("player.png")
player:SetTexture(playerTex)

// Load jump sound
local jumpSound = soundservice.Sound("jump.wav")

// Movement
local playerX = 250
local playerY = 300

onkey("A") [
    playerX = playerX - 10
    player.pos = playerX + "," + playerY
]

onkey("D") [
    playerX = playerX + 10
    player.pos = playerX + "," + playerY
]

onkey("Space") [
    jumpSound:StartPlay()
    playerY = playerY - 50
    player.pos = playerX + "," + playerY
    
    waiting(1)
    
    playerY = playerY + 50
    player.pos = playerX + "," + playerY
]

pring "Use A/D to move, Space to jump!"
```

### Example 2: Music Player

```zaba
import window
import soundservice

local form = window:CreateNewForm("Music Player")
form.bg = "#2c3e50"

// Title
local lblTitle = window:CreateLabel("MUSIC PLAYER")
lblTitle.pos = "150,30"
lblTitle.fontsize = "24"
lblTitle.textcolor = "#ecf0f1"
lblTitle.textbg = "Transparent"

// Load music
local music = soundservice.Sound("song.wav")
music.volume = "50"

// Play button
local btnPlay = window:CreateButton("▶ Play")
btnPlay.pos = "100,100"
btnPlay.size = "100,40"
btnPlay.bg = "#27ae60"

btnPlay:OnClick [
    music.loop = true
    music:StartPlay()
    pring "Music playing..."
]

// Stop button
local btnStop = window:CreateButton("■ Stop")
btnStop.pos = "220,100"
btnStop.size = "100,40"
btnStop.bg = "#e74c3c"

btnStop:OnClick [
    music:StopPlay()
    pring "Music stopped"
]

// Status
local lblStatus = window:CreateLabel("Ready")
lblStatus.pos = "150,160"
lblStatus.textcolor = "#95a5a6"
lblStatus.textbg = "Transparent"
```

### Example 3: Horror Effect

```zaba
import window

local form = window:CreateNewForm("Horror")
form.bg = "black"

// Hidden text
local lblScary = window:CreateLabel("BOO!")
lblScary.pos = "250,200"
lblScary.fontsize = "48"
lblScary.textcolor = "Transparent"
lblScary.textbg = "Transparent"

// Fade in effect
local step = 0

tick(500) [
    step = step + 1
    
    if step == 1 [
        lblScary.textcolor = "Transparent"
    ]
    
    if step == 2 [
        lblScary.textcolor = "#330000"
    ]
    
    if step == 3 [
        lblScary.textcolor = "#660000"
    ]
    
    if step == 4 [
        lblScary.textcolor = "#990000"
    ]
    
    if step == 5 [
        lblScary.textcolor = "red"
    ]
    
    if step == 6 [
        lblScary.textcolor = "Transparent"
    ]
    
    if step == 7 [
        lblScary.textcolor = "red"
        step = 5
    ]
]
```

### Example 4: Full Game Demo

```zaba
import window
import texturemodule
import soundservice

local form = window:CreateNewForm("Mini Game")
form.bg = "#1a1a1a"

// Background music
local bgMusic = soundservice.Sound("music.wav")
bgMusic.loop = true
bgMusic.volume = "20"
bgMusic:StartPlay()

// Player
part player = shape("circle", "white", 50, 50)
player.pos = "100,300"

local playerTex = texturemodule.Texture("player.png")
player:SetTexture(playerTex)

// Coin
part coin = shape("circle", "white", 30, 30)
coin.pos = "400,300"

local coinTex = texturemodule.Texture("coin.png")
coin:SetTexture(coinTex)

// Sounds
local coinSound = soundservice.Sound("coin.wav")
local winSound = soundservice.Sound("win.wav")

// UI
local lblScore = window:CreateLabel("Score: 0")
lblScore.pos = "20,20"
lblScore.fontsize = "18"
lblScore.textcolor = "#FFD700"
lblScore.textbg = "black"

local score = 0

// Movement
local playerX = 100

onkey("A") [
    playerX = playerX - 15
    player.pos = playerX + ",300"
]

onkey("D") [
    playerX = playerX + 15
    player.pos = playerX + ",300"
]

// Collect coin
local btnCollect = window:CreateButton("Collect Coin")
btnCollect.pos = "20,60"

btnCollect:OnClick [
    score = score + 1
    lblScore.text = "Score: " + score
    coinSound:StartPlay()
    
    if score == 10 [
        bgMusic:StopPlay()
        winSound:StartPlay()
        lblScore.text = "YOU WIN!"
        lblScore.textcolor = "red"
    ]
]

pring "Game started! Collect 10 coins to win!"
```

---

## 🔍 Language Implementation

### AST (Abstract Syntax Tree)

**New Statement Types (v2.0):**
- `LoadTextureStmt` — Texture loading
- `SetTextureStmt` — Apply texture to shape
- `RemoveTextureStmt` — Remove texture from shape
- `LoadSoundStmt` — Sound loading
- `PlaySoundStmt` — Play sound
- `StopSoundStmt` — Stop sound

**New Expression Types (v2.0):**
- `BoolExpr` — Boolean values (true/false)

### Lexer Features

**New Tokens (v2.0):**
- `TRUE`, `FALSE` — Boolean literals

### Parser Features

**New Parsing (v2.0):**
- Method calls with `.` operator (`texturemodule.Texture()`)
- Texture/sound method parsing (`:SetTexture()`, `:StartPlay()`, `:StopPlay()`)
- Boolean expression parsing

### Interpreter Features

**New Functionality (v2.0):**
- Project path management (`SetProjectPath()`)
- Texture dictionary and rendering
- Sound player dictionary with loop support
- Enhanced error handling (`StopProgramByError()`)
- Texture application to `ShapePanel`
- Sound loop implementation
- Text color and background styling

---

## 🔧 Best Practices

1. **Always set project path when loading:**
```csharp
interp.SetProjectPath(projectFolder);
```

2. **Keep assets in project folder:** All `.png`, `.jpg`, `.wav` files together with `.zab+`

3. **Use textures for better visuals:** Shapes with textures look more professional

4. **Add sound effects:** Makes games feel more interactive

5. **Loop background music:** Set `loop = true` for music

6. **Use transparent text:** Great for fade-in/fade-out effects

---

## 🐛 Common Issues

**Problem:** `❌ Texture file not found`
**Solution:** Make sure file is in project folder and name matches exactly

**Problem:** `❌ Sound file not found`
**Solution:** Check file name and format (`.wav` recommended)

**Problem:** Sound doesn't loop
**Solution:** Set `sound.loop = true` **before** calling `:StartPlay()`

**Problem:** Text is invisible
**Solution:** Check if `textcolor` is set to `"Transparent"`

---

## 📚 Quick Reference

### Modules
- `window` — GUI controls
- `texturemodule` — Image loading
- `soundservice` — Audio playback

### Texture Methods
- `texturemodule.Texture("file.png")` — Load texture
- `shape:SetTexture(texture)` — Apply texture
- `shape:RemoveTexture()` — Remove texture

### Sound Methods
- `soundservice.Sound("file.wav")` — Load sound
- `sound:StartPlay()` — Play sound
- `sound:StopPlay()` — Stop sound
- `sound.loop = true/false` — Enable/disable loop
- `sound.volume = "0-100"` — Set volume

### Text Styling
- `label.textcolor` — Text color
- `label.textbg` — Text background
- Both support: named colors, hex colors, `"Transparent"`

---

**Version:** 2.0  
**New Features:** Projects, Textures, Sounds, Text Styling  
**Last Updated:** November 2025  
**Language Designer:** Zaba+ Team 🐸
