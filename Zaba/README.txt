
# Zaba+ Programming Language Documentation

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

### Variables
```zaba
local score = 0        // Local variable (function scope)
let name = "Zabka"     // Global variable
score = score + 10     // Assignment
```

### Conditionals
```zaba
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

### Timing
```zaba
waiting(5)              // Wait 5 seconds
tick(1000) [            // Execute every 1000ms
    pring "Tick!"
]
```

---

## 🖼️ GUI Module (`window`)

### Import and Setup
```zaba
import window

local myForm = window:CreateNewForm("My Application")
```

### Creating Controls
```zaba
local btn = window:CreateButton("Click me!")
local lbl = window:CreateLabel("Score: 0")
```

### Setting Properties
```zaba
myForm.bg = "lightblue"          // Background color
myForm.bg = "#FF5733"            // Hex color

btn.pos = "100,50"               // Position (x,y)
btn.size = "120,40"              // Size (width,height)
btn.text = "Start Game"          // Button text
btn.font = "Arial"               // Font family
btn.fontsize = "14"              // Font size

lbl.text = "Score: " + score     // Dynamic text
```

### Events
```zaba
btn:OnClick [
    score = score + 1
    lbl.text = "Score: " + score
    pring "Button clicked!"
]
```

### Removing Controls
```zaba
btn:Remove
```

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

### Positioning and Styling
```zaba
circle1.pos = "200,150"
circle1.size = "150,150"
circle1.color = "yellow"
```

### Colors
```zaba
// Named colors
myForm.bg = "red"
circle1.color = "blue"

// Hex colors
rect1.color = "#FF5733"
tri1.color = "#00AAFF"
```

---

## 🎮 Game Module (`zabgame`) - *Planned*

```zaba
import zabgame

zabgame:CreatePlayer("Hero")
zabgame:CreateEnemy("250", "250")

ArrowLeft:OnKey [
    move Hero left "10"
]
```

---

## 🛠️ Utility Commands

### Program Control
```zaba
stop:Program        // Stop execution
clear:Console       // Clear console output
```

### Functions *(Planned)*
```zaba
func greet(name) [
    pring "Hello, " + name
    return name + " greeted"
]

let result = greet("Zabka")
```

---

## 📐 Operators

### Arithmetic
- `+` — addition / concatenation
- `-` — subtraction
- `*` — multiplication
- `/` — division

### Comparison
- `==` — equality
- `!=` — inequality
- `>` — greater
- `<` — less
- `>=`, `<=` — greater/less than or equal to

### Grouping
```zaba
pring @10 + 5@ * 2    // Result: 30 (grouping with @...@)
```

---

## 💡 Complete Example

```zaba
import window

local form = window:CreateNewForm("Counter App")
form.bg = "lightgray"

local lbl = window:CreateLabel("Count: 0")
lbl.pos = "50,30"
lbl.fontsize = "16"

local btn = window:CreateButton("Increment")
btn.pos = "50,80"
btn.size = "100,40"

local count = 0

btn:OnClick [
    count = count + 1
    lbl.text = "Count: " + count
    pring "Count is now: " + count
]

part circle = shape("circle", "blue", 80, 80)
circle.pos = "200,80"

tick(2000) [
    if count > 5 [
        circle.color = "green"
    ]
]
```

---

## 🔍 Notes for AI Code Generation

1. **Always use `import window`** before creating GUI elements
2. **Use `local`** for UI controls: `local btn = window:CreateButton("...")`
3. **Property assignment syntax:** `object.property = value`
4. **Event syntax:** `object:OnClick [ ... ]`
5. **Shapes require:** `part name = shape("type", "color", width, height)`
6. **Colors:** support named colors (`"red"`) and hex (`"#FF5733"`)
7. **Position/Size format:** `"x,y"` or `"width,height"` as strings
8. **Comments:** use `//` for single-line comments

