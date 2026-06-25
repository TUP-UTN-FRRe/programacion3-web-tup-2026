# Ejemplo de Vulnerabilidad XSS Reflejada

Este proyecto contiene ejemplos educativos que demuestran vulnerabilidades XSS (Cross-Site Scripting) y cómo prevenirlas.

## ⚠️ ADVERTENCIA IMPORTANTE

Este código contiene vulnerabilidades **INTENCIONALMENTE** para fines educativos. **NO uses este código en aplicaciones reales.**

## Archivos del Proyecto

### 1. `index.html` - Versión Vulnerable 🚨
Contiene un ejemplo de vulnerabilidad XSS reflejada donde:
- El input del usuario se inserta directamente en el DOM usando `innerHTML`
- No hay sanitización ni validación
- Permite la ejecución de código JavaScript malicioso

### 2. `secure-version.html` - Versión Segura ✅
Muestra cómo implementar la misma funcionalidad de forma segura:
- Usa `textContent` en lugar de `innerHTML`
- Implementa validación de entrada
- Incluye métodos de sanitización

## Cómo Probar la Vulnerabilidad XSS

### Payloads de prueba para `index.html`:

1. **Alert básico:**
   ```html
   <script>alert('XSS Vulnerable!')</script>
   ```

2. **XSS con imagen:**
   ```html
   <img src="x" onerror="alert('XSS con imagen!')">
   ```

3. **XSS con SVG:**
   ```html
   <svg onload="alert('XSS con SVG!')"></svg>
   ```

4. **XSS más complejo:**
   ```html
   <script>document.body.style.backgroundColor='red'; alert('Página comprometida!');</script>
   ```

5. **XSS con iframe a pantalla completa (MUY PELIGROSO):**
   ```html
   <iframe src="https://google.com" style="position:fixed;top:0;left:0;width:100%;height:100%;z-index:9999;border:none;"></iframe>
   ```

### ⚠️ Sobre el payload del iframe:

Este último ejemplo es **especialmente peligroso** porque:
- **Ocultación total**: El iframe ocupa toda la pantalla, ocultando completamente la página original
- **Simulación convincente**: Parece que el usuario fue redirigido a Google
- **Potencial de phishing**: Un atacante podría crear una página falsa de login que se vea idéntica a la real
- **Captura de datos**: Podría interceptar credenciales, información personal, etc.
- **Persistencia**: El iframe permanece hasta que se recarga la página

### Qué sucede cuando pruebas estos payloads:

- **En `index.html`**: Los scripts se ejecutarán y verás las alertas
  - Los primeros 4 payloads mostrarán alertas o cambiarán estilos
  - **El payload del iframe cargará Google.com ocupando toda la pantalla**
- **En `secure-version.html`**: Los payloads se mostrarán como texto plano sin ejecutarse

## Conceptos Clave

### ¿Qué es XSS Reflejada?
XSS reflejada ocurre cuando una aplicación web toma datos del usuario y los devuelve inmediatamente en la respuesta sin validación o sanitización adecuada.

### ¿Por qué es peligroso?
- Permite a atacantes ejecutar código JavaScript en el navegador de la víctima
- Puede robar cookies, tokens de sesión, credenciales
- Puede modificar el contenido de la página
- Puede redirigir a sitios maliciosos
- **Con iframes**: Puede superponer páginas completas para ataques de phishing sofisticados

### Casos de uso malicioso del iframe XSS:
1. **Phishing avanzado**: Mostrar una página de login falsa que parece legítima
2. **Clickjacking**: Superponer elementos invisibles para capturar clicks
3. **Robo de sesiones**: Cargar páginas que extraen cookies o tokens
4. **Desorientación del usuario**: Hacer creer que están en un sitio diferente

### Cómo Prevenir XSS

1. **Validación de entrada:**
   - Validar todos los datos de entrada del usuario
   - Rechazar entradas que contengan caracteres sospechosos

2. **Codificación/Escape de salida:**
   - Codificar caracteres especiales antes de mostrarlos
   - Usar `textContent` en lugar de `innerHTML` cuando sea posible

3. **Sanitización:**
   - Usar librerías especializadas como DOMPurify
   - Implementar listas blancas de elementos HTML permitidos

4. **Content Security Policy (CSP):**
   - Implementar CSP headers para restringir la ejecución de scripts

## Métodos de Protección Implementados

### En `secure-version.html`:

```javascript
// ❌ Vulnerable:
outputDiv.innerHTML = `<h2>¡Hola, ${nombreUsuario}!</h2>`;

// ✅ Seguro:
outputDiv.textContent = `¡Hola, ${nombreUsuario}! Bienvenido/a.`;
```

### Sanitización manual:
```javascript
function sanitizarEntrada(input) {
    return input
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#x27;')
        .replace(/\//g, '&#x2F;');
}
```

### Creación segura de elementos DOM:
```javascript
// Crear elementos programáticamente es más seguro
const elemento = document.createElement('div');
elemento.textContent = textoDelUsuario; // Seguro
outputDiv.appendChild(elemento);
```

## Instrucciones de Uso

1. Abre ambos archivos HTML en tu navegador
2. Prueba ingresar texto normal en ambos
3. Luego prueba los payloads XSS listados arriba
4. Observa las diferencias en comportamiento

## Recursos Adicionales

- [OWASP XSS Prevention Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Cross_Site_Scripting_Prevention_Cheat_Sheet.html)
- [MDN Web Security](https://developer.mozilla.org/en-US/docs/Web/Security)
- [DOMPurify Library](https://github.com/cure53/DOMPurify)

## Licencia

Este código es para fines educativos únicamente. Úsalo responsablemente.
