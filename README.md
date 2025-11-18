# Zaba+ Programming Language - Complete Documentation

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
let price = 99.99
local count = 0
```

### Strings
```zaba
let name = "Zabka"
let message = "Score: "
pring "Hello, " + name  // Concatenation
```

### Type Conversion
```zaba
let score = 100
pring "Your score: " + score  // Automatic conversion to string
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
pring @10 + 5@ * 2      // Result: 30 (grouping with @...@)
pring 10 + 5 * 2        // Result: 20 (standard precedence)
```

**Operator Precedence:**
1. `@...@` (grouping)
2. `*`, `/` (multiplication, division)
3. `+`, `-` (addition, subtraction)
4. `>`, `<`, `==`, `!=`, `>=`, `<=` (comparison)

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

// Nested conditions
if score > 50 [
    if score > 100 [
        pring "Excellent!"
    ] else [
        pring "Good job!"
    ]
]
```

**Syntax Rules:**
- Condition must evaluate to number (0 = false, non-zero = true)
- Use `[` and `]` for code blocks
- `else` is optional

### Loops
```zaba
// While loop
while score < 100 [
    score = score + 1
    pring score
]

// Infinite loop (use stop:Program to exit)
while 1 [
    pring "Running..."
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
tick(1000) [            // Execute every 1000ms (1 second)
    pring "Tick!"
    score = score + 1
]
```

**Multiple Timers:**
```zaba
tick(1000) [
    pring "Every second"
]

tick(5000) [
    pring "Every 5 seconds"
]
```

### Program Control
```zaba
stop:Program        // Stop execution and close all windows
clear:Console       // Clear console output
```

---

## 🖼️ GUI Module (`window`)

### Import and Setup
```zaba
import window

// Create main form
local myForm = window:CreateNewForm("My Application")
```

### Creating Controls

#### Forms (Windows)
```zaba
local form1 = window:CreateNewForm("Main Window")
local form2 = window:CreateNewForm("Settings")
```

**Default Properties:**
- Size: 600×400 pixels
- Position: System default
- Background: System default color

#### Buttons
```zaba
local btn1 = window:CreateButton("Click me!")
local btn2 = window:CreateButton("Start Game")
```

**Default Properties:**
- Size: 100×40 pixels
- Position: (10, 10)
- Text: From parameter

#### Labels
```zaba
local lbl1 = window:CreateLabel("Score: 0")
local lbl2 = window:CreateLabel("Player name")
```

**Default Properties:**
- Position: (10, 60)
- Auto-resize based on text
- Background: Transparent

---

## 🎨 Control Properties

### Position (`pos`)
```zaba
btn.pos = "100,50"       // x=100, y=50 (from top-left corner)
lbl.pos = "200,100"      // x=200, y=100
```

### Size (`size`)
```zaba
btn.size = "120,40"      // width=120, height=40
form.size = "800,600"    // width=800, height=600
```

### Text (`text`)
```zaba
btn.text = "Start Game"
lbl.text = "Score: 0"
form.text = "My App v1.0"  // Window title

// Dynamic text
local score = 0
lbl.text = "Score: " + score
```

### Background Color (`bg`)
```zaba
// Named colors
myForm.bg = "lightblue"
myForm.bg = "red"
myForm.bg = "white"

// Hex colors
myForm.bg = "#FF5733"    // Orange-red
myForm.bg = "#00AAFF"    // Light blue
myForm.bg = "#FFFFFF"    // White
```

**Supported Named Colors:**
- `red`, `blue`, `green`, `yellow`, `orange`, `purple`, `pink`
- `black`, `white`, `gray`, `lightgray`, `darkgray`
- `lightblue`, `darkblue`, `lightgreen`, `darkgreen`
- And all standard .NET color names

### Font Properties
```zaba
// Font family
btn.font = "Arial"
lbl.font = "Courier New"
lbl.font = "Times New Roman"

// Font size
lbl.fontsize = "14"
btn.fontsize = "16"
lbl.fontsize = "20"
```

**Common Fonts:**
- Arial, Calibri, Verdana (sans-serif)
- Times New Roman, Georgia (serif)
- Courier New, Consolas (monospace)

---

## 🎯 Events

### Button Click Events
```zaba
local btn = window:CreateButton("Click me")
local count = 0

btn:OnClick [
    count = count + 1
    pring "Clicked " + count + " times"
]
```

**Event Syntax:**
```zaba
objectName:OnClick [
    // Code to execute on click
]
```

### Keyboard Events
```zaba
// Single key
onkey("W") [
    pring "W pressed"
]

// Arrow keys
onkey("ArrowLeft") [
    pring "Left arrow pressed"
]

onkey("ArrowRight") [
    pring "Right arrow pressed"
]

// Special keys
onkey("Space") [
    pring "Space pressed"
]

onkey("Enter") [
    pring "Enter pressed"
]
```

**Available Keys:**
- Letters: `"A"`, `"B"`, `"C"`, ..., `"Z"`
- Arrows: `"ArrowUp"`, `"ArrowDown"`, `"ArrowLeft"`, `"ArrowRight"`
- Numbers: `"D0"`, `"D1"`, ..., `"D9"`
- Special: `"Space"`, `"Enter"`, `"Escape"`, `"Tab"`
- Function: `"F1"`, `"F2"`, ..., `"F12"`

**Important:** Keys are case-insensitive but stored in uppercase

### Event Context
```zaba
local score = 0
local lbl = window:CreateLabel("Score: 0")
local btn = window:CreateButton("Add Point")

btn:OnClick [
    score = score + 1
    lbl.text = "Score: " + score
    
    if score > 10 [
        btn.text = "You won!"
    ]
]
```

---

## 🎨 Graphics Module (`part`)

### Creating Shapes
```zaba
import window

local myForm = window:CreateNewForm("Shapes Demo")

// Create shapes
part circle1 = shape("circle", "red", 100, 100)
part rect1 = shape("rectangle", "blue", 150, 80)
part tri1 = shape("triangle", "#00FF00", 120, 120)
```

**Syntax:**
```zaba
part variableName = shape("shapeType", "color", width, height)
```

**Supported Shapes:**
- `"circle"` — circle (circular shape)
- `"rectangle"` — rectangle (rectangular shape)
- `"triangle"` — triangle (triangular shape, points up)

### Shape Properties

#### Position
```zaba
circle1.pos = "200,150"    // x=200, y=150
rect1.pos = "100,100"
```

#### Size
```zaba
circle1.size = "150,150"   // width=150, height=150
rect1.size = "200,100"     // width=200, height=100
```

**Note:** For circles, width and height should be equal for perfect circle

#### Color
```zaba
// Named colors
circle1.color = "yellow"
rect1.color = "blue"
tri1.color = "green"

// Hex colors
circle1.color = "#FF5733"
rect1.color = "#00AAFF"
```

### Dynamic Shape Changes
```zaba
local score = 0
part indicator = shape("circle", "red", 50, 50)
indicator.pos = "300,200"

tick(1000) [
    score = score + 1
    
    if score > 5 [
        indicator.color = "green"
        indicator.size = "80,80"
    ]
]
```

### Removing Shapes
```zaba
circle1:Remove    // Removes the shape from the form
```

---

## 🎮 Game Module (`zabgame`) - *Planned Feature*

```zaba
import zabgame

// Create game entities
zabgame:CreatePlayer("Hero")
zabgame:CreateEnemy("250", "250")

// Movement controls
ArrowLeft:OnKey [
    move Hero left "10"
]

ArrowRight:OnKey [
    move Hero right "10"
]

// Collision detection
if collide(Hero, Enemy) [
    pring "Game Over!"
]
```

**Status:** This module is planned for future releases

---

## 💡 Complete Examples

### Example 1: Counter App
```zaba
import window

// Create form
local form = window:CreateNewForm("Counter App")
form.bg = "lightgray"

// Create label
local lbl = window:CreateLabel("Count: 0")
lbl.pos = "50,30"
lbl.fontsize = "16"

// Create button
local btn = window:CreateButton("Increment")
btn.pos = "50,80"
btn.size = "100,40"

// Counter logic
local count = 0

btn:OnClick [
    count = count + 1
    lbl.text = "Count: " + count
    pring "Count is now: " + count
]

// Visual indicator
part circle = shape("circle", "blue", 80, 80)
circle.pos = "200,80"

// Change color when count > 5
tick(2000) [
    if count > 5 [
        circle.color = "green"
    ]
]
```

### Example 2: Color Changer
```zaba
import window

local form = window:CreateNewForm("Color Changer")
form.bg = "white"

local btnRed = window:CreateButton("Red")
btnRed.pos = "50,50"

local btnBlue = window:CreateButton("Blue")
btnBlue.pos = "50,100"

local btnGreen = window:CreateButton("Green")
btnGreen.pos = "50,150"

btnRed:OnClick [
    form.bg = "red"
]

btnBlue:OnClick [
    form.bg = "blue"
]

btnGreen:OnClick [
    form.bg = "green"
]
```

### Example 3: Shape Movement (Keyboard)
```zaba
import window

local form = window:CreateNewForm("Move Shape")
form.bg = "lightblue"

part player = shape("circle", "red", 50, 50)
player.pos = "250,200"

local x = 250
local y = 200

onkey("W") [
    y = y - 10
    player.pos = x + "," + y
]

onkey("S") [
    y = y + 10
    player.pos = x + "," + y
]

onkey("A") [
    x = x - 10
    player.pos = x + "," + y
]

onkey("D") [
    x = x + 10
    player.pos = x + "," + y
]

local instructions = window:CreateLabel("Use WASD to move")
instructions.pos = "200,350"
instructions.fontsize = "12"
```

### Example 4: Timer Game
```zaba
import window

local form = window:CreateNewForm("Reaction Timer")
form.bg = "white"

local lbl = window:CreateLabel("Click when green!")
lbl.pos = "100,50"
lbl.fontsize = "14"

local btn = window:CreateButton("Wait...")
btn.pos = "100,100"
btn.size = "200,80"
btn.bg = "red"

local score = 0
local ready = 0

// Timer to change button color
tick(3000) [
    ready = 1
    btn.bg = "green"
    btn.text = "CLICK NOW!"
]

btn:OnClick [
    if ready == 1 [
        score = score + 1
        lbl.text = "Score: " + score
        ready = 0
        btn.bg = "red"
        btn.text = "Wait..."
    ] else [
        lbl.text = "Too early!"
    ]
]
```

### Example 5: Multiple Shapes Animation
```zaba
import window

local form = window:CreateNewForm("Shape Animation")
form.bg = "#1a1a1a"

part circle1 = shape("circle", "#FF5733", 60, 60)
circle1.pos = "100,150"

part rect1 = shape("rectangle", "#00AAFF", 80, 80)
rect1.pos = "250,150"

part tri1 = shape("triangle", "#00FF00", 70, 70)
tri1.pos = "400,150"

local timer = 0

tick(500) [
    timer = timer + 1
    
    // Cycle colors
    if timer == 1 [
        circle1.color = "#00AAFF"
        rect1.color = "#00FF00"
        tri1.color = "#FF5733"
    ]
    
    if timer == 2 [
        circle1.color = "#00FF00"
        rect1.color = "#FF5733"
        tri1.color = "#00AAFF"
    ]
    
    if timer == 3 [
        circle1.color = "#FF5733"
        rect1.color = "#00AAFF"
        tri1.color = "#00FF00"
        timer = 0
    ]
]
```

---

## 🔍 Language Implementation Details

### AST (Abstract Syntax Tree) Structure

**Statement Types:**
- `ProgramNode` — Root node containing list of statements
- `AssignStmt` — Variable assignment (`name = value`)
- `LocalStmt` — Local variable declaration (`local name = value`)
- `LetStmt` — Global variable declaration (`let name = value`)
- `PringStmt` — Console output (`pring value`)
- `IfStmt` — Conditional statement with optional else
- `WhileStmt` — Loop statement
- `WaitingStmt` — Delay execution
- `TickStmt` — Repeating timer
- `StopStmt` — Program termination
- `ClearStmt` — Console clear
- `ImportStmt` — Module import
- `CreateFormStmt` — Window creation
- `CreateButtonStmt` — Button creation
- `CreateLabelStmt` — Label creation
- `PropertyAssignStmt` — Object property assignment (`obj.prop = value`)
- `OnClickStmt` — Click event handler
- `OnKeyStmt` — Keyboard event handler
- `RemoveStmt` — Control removal
- `CreatePartStmt` — Shape creation
- `ExprStmt` — Expression statement

**Expression Types:**
- `NumberExpr` — Numeric literal
- `StringExpr` — String literal
- `VarExpr` — Variable reference
- `BinaryExpr` — Binary operation (left operator right)
- `MethodCallExpr` — Method invocation

### Token Types
- `ID` — Identifier (variable/function names)
- `NUM` — Number literal
- `STRING` — String literal (enclosed in `"`)
- `LET`, `LOCAL`, `PRING`, `IF`, `ELSE`, `WHILE`, `WAITING`, `TICK`, `STOP`, `CLEAR`, `IMPORT`, `PART`, `ONKEY` — Keywords
- `+`, `-`, `*`, `/` — Arithmetic operators
- `==`, `!=`, `>`, `<`, `>=`, `<=` — Comparison operators
- `=` — Assignment
- `(`, `)`, `[`, `]` — Delimiters
- `.`, `:` — Member/method access
- `@` — Grouping operator
- `//` — Comment marker

### Lexer Features
- Line and column tracking for error reporting
- Comment support (`//`)
- Multi-character operators (`==`, `!=`, `>=`, `<=`)
- String parsing with escape handling
- Whitespace skipping

### Parser Features
- Recursive descent parsing
- Operator precedence handling
- Expression grouping with `@...@`
- Block parsing with `[...]`
- Event handler parsing
- Property access parsing (`object.property`)
- Method call parsing (`object:method()`)

### Interpreter Features
- Dynamic typing
- Automatic type conversion
- Environment (variable storage)
- UI synchronization context
- Timer management
- Event handler registration
- Shape rendering system
- Keyboard input handling
- Thread-safe console output

---

## 🔧 Advanced Topics

### Variable Scope
```zaba
let globalVar = 10      // Global - accessible everywhere

local localVar = 20     // Local - accessible in current scope

if globalVar > 5 [
    local innerVar = 30  // Only accessible in this block
    pring innerVar       // Works
]

pring innerVar          // Error: undefined variable
```

### Error Handling
```zaba
// Division by zero
let result = 10 / 0     // Error: "Division by zero"

// Undefined variable
pring unknownVar        // Error: "Undefined var unknownVar"

// Invalid color
myForm.bg = "notacolor" // Warning + fallback to black
```

### Best Practices

1. **Always import modules before use:**
```zaba
import window
local form = window:CreateNewForm("App")
```

2. **Use meaningful variable names:**
```zaba
// Good
local playerScore = 0
local btnStart = window:CreateButton("Start")

// Bad
local x = 0
local b = window:CreateButton("Start")
```

3. **Initialize variables before use:**
```zaba
local score = 0         // Initialize
score = score + 1       // Use
```

4. **Group related code:**
```zaba
// UI Creation
local form = window:CreateNewForm("App")
local btn = window:CreateButton("Click")

// Event Handlers
btn:OnClick [
    pring "Clicked"
]
```

5. **Use comments for complex logic:**
```zaba
// Calculate final score with bonus
local finalScore = score * 2 + bonus
```

---

## 🔍 Notes for AI Code Generation

1. **Module Import:** Always use `import window` before creating GUI elements
2. **Control Creation:** Use `local varName = window:CreateType("text")` pattern
3. **Property Assignment:** Use `object.property = value` syntax
4. **Event Handlers:** Use `object:EventName [...]` syntax
5. **Shape Creation:** Use `part name = shape("type", "color", width, height)`
6. **Color Support:** Both named colors (`"red"`) and hex (`"#FF5733"`) are supported
7. **Position/Size:** Always use string format `"x,y"` or `"width,height"`
8. **Comments:** Use `//` for single-line comments
9. **Grouping:** Use `@...@` for expression grouping instead of parentheses
10. **Event Bodies:** Must be enclosed in `[...]` brackets
11. **Timers:** `tick()` creates persistent timers that run until program stops
12. **Keyboard:** `onkey()` requires form to be active and `KeyPreview = true` (handled automatically)

---

## 📚 Quick Reference

### Keywords
`let`, `local`, `pring`, `if`, `else`, `while`, `waiting`, `tick`, `stop`, `clear`, `import`, `part`, `onkey`

### Operators
`+`, `-`, `*`, `/`, `>`, `<`, `==`, `!=`, `>=`, `<=`, `=`, `@...@`

### Built-in Modules
- `window` — GUI controls
- `zabgame` — Game engine (planned)

### Control Methods
- `window:CreateNewForm(title)`
- `window:CreateButton(text)`
- `window:CreateLabel(text)`
- `shape(type, color, width, height)`

### Control Properties
- `pos` — Position ("x,y")
- `size` — Size ("width,height")
- `text` — Text content
- `bg` — Background color
- `color` — Shape color
- `font` — Font family
- `fontsize` — Font size

### Events
- `objectName:OnClick [...]` — Button click
- `onkey("key") [...]` — Keyboard press
- `objectName:Remove` — Remove control

### Utility
- `stop:Program` — Stop execution
- `clear:Console` — Clear output
- `waiting(seconds)` — Delay
- `tick(milliseconds) [...]` — Repeating timer

**Version:** 1.0  
**Last Updated:** 2025  
**Language Designer:** Zaba+ Team
