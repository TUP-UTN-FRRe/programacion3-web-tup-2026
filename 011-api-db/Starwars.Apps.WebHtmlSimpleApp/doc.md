# Consulta a una API REST con JavaScript puro y CSS

## Estructura de archivos

```
Starwars.Apps.WebHtmlSimpleApp/
├── index.html     ← Estructura HTML de la página
├── styles.css     ← Estilos visuales
├── app.js         ← Lógica JavaScript
└── doc.md         ← Este archivo
```

---

## Paso a paso

### 1. HTML (`index.html`)

El HTML define la estructura de la página. Los elementos clave son:

- **`<link rel="stylesheet" href="styles.css">`** — vincula el archivo CSS externo.
- **`<button id="btn-cargar">`** — botón que el usuario presiona para disparar la consulta.
- **`<div id="lista-jedis">`** — contenedor vacío donde se insertarán dinámicamente las tarjetas.
- **`<p id="error-msg">`** — párrafo para mostrar errores al usuario.
- **`<script src="app.js">`** — se coloca al final del `<body>` para que el DOM ya esté cargado cuando el script se ejecute.

```html
<button id="btn-cargar">Cargar Jedis</button>
<div id="lista-jedis"></div>
<p id="error-msg"></p>
<script src="app.js"></script>
```

---

### 2. JavaScript (`app.js`)

#### 2.1 Selección de elementos del DOM

```js
const btnCargar  = document.getElementById('btn-cargar');
const listaJedis = document.getElementById('lista-jedis');
const errorMsg   = document.getElementById('error-msg');
```

`document.getElementById` localiza un elemento HTML por su atributo `id` y devuelve una referencia a ese nodo del DOM.

---

#### 2.2 Escuchar el evento `click`

```js
btnCargar.addEventListener('click', function () {
    // código que se ejecuta cuando el botón es presionado
});
```

`addEventListener` registra una función (llamada *callback* o *manejador de eventos*) que se invoca cada vez que ocurre el evento indicado (en este caso `'click'`).

---

#### 2.3 Limpieza antes de cada consulta

```js
listaJedis.innerHTML = '';
errorMsg.textContent = '';
```

Se vacía el contenedor y el mensaje de error antes de hacer una nueva solicitud, para evitar duplicados si el usuario presiona el botón más de una vez.

---

#### 2.4 `fetch` — consulta a la API

```js
fetch(API_URL)
    .then(function (response) { ... })
    .then(function (jedis) { ... })
    .catch(function (error) { ... });
```

`fetch` es una función nativa del navegador que realiza solicitudes HTTP de forma **asíncrona**.  
Devuelve una **Promise** (promesa): un objeto que representa una operación que aún no terminó.

| Método     | ¿Cuándo se ejecuta?                            |
|------------|------------------------------------------------|
| `.then()`  | Cuando la promesa se resuelve con éxito        |
| `.catch()` | Cuando ocurre un error (red, servidor, etc.)   |

**Primera `.then`** — verificar que la respuesta HTTP sea exitosa:

```js
.then(function (response) {
    if (!response.ok) {
        throw new Error('Error: ' + response.status);
    }
    return response.json(); // convierte el body JSON a un objeto JS
})
```

`response.ok` es `true` cuando el código HTTP está entre 200 y 299.  
`response.json()` devuelve otra Promise que, al resolverse, entrega el array de objetos JavaScript.

**Segunda `.then`** — recorrer el array y crear las tarjetas:

```js
.then(function (jedis) {
    jedis.forEach(function (jedi) {
        var card = document.createElement('div');
        card.className = 'jedi-card';
        // ...
        listaJedis.appendChild(card);
    });
})
```

- `forEach` itera sobre cada elemento del array.
- `document.createElement('div')` crea un nuevo nodo `<div>` en memoria (todavía no visible).
- `appendChild` lo inserta como hijo del contenedor, haciéndolo visible en pantalla.

---

#### 2.5 Manejo de errores

```js
.catch(function (error) {
    errorMsg.textContent = error.message;
});
```

Si la API no responde, la URL es incorrecta o el servidor devuelve un error, el `.catch` captura la excepción y muestra el mensaje al usuario.

---

### 3. CSS (`styles.css`)

El CSS es **puro** (sin frameworks). Puntos importantes:

| Selector / Propiedad | Qué hace |
|---|---|
| `body { display: flex; flex-direction: column; align-items: center; }` | Centra todo el contenido horizontalmente usando Flexbox |
| `#btn-cargar { transition: ... }` | Agrega una animación suave al hover y al click |
| `.jedi-card { border: 1px solid #ffe81f; }` | Cada tarjeta tiene borde amarillo Star Wars |
| `box-shadow` en `.jedi-card` | Efecto de brillo sutil alrededor de cada tarjeta |

---

## Conceptos clave

### DOM (Document Object Model)
El navegador convierte el HTML en un árbol de objetos llamado DOM. JavaScript puede leer y modificar ese árbol en tiempo real sin recargar la página.

### Evento
Una acción del usuario (click, tecla, scroll) o del sistema (carga de página). `addEventListener` permite reaccionar a esas acciones.

### Promise y programación asíncrona
Una operación asíncrona (como una llamada a red) no bloquea el resto del código. La Promise actúa como un "ticket": cuando la operación termina, ejecuta la función del `.then()` correspondiente.

### fetch API
Herramienta nativa del navegador (sin librerías) para hacer peticiones HTTP. Reemplaza al antiguo `XMLHttpRequest` con una sintaxis más limpia basada en Promises.

### Separación de responsabilidades
| Archivo | Responsabilidad |
|---|---|
| `index.html` | Estructura semántica de la página |
| `styles.css`  | Presentación visual |
| `app.js`      | Comportamiento e interacción |

Esta separación es una buena práctica fundamental del desarrollo web.
