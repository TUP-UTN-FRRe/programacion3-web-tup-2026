const API_URL = 'https://localhost:7213/api/jedi';

const btnCargar  = document.getElementById('btn-cargar');
const listaJedis = document.getElementById('lista-jedis');
const errorMsg   = document.getElementById('error-msg');
const loader     = document.getElementById('loader');

function mostrarLoader() {
    loader.classList.remove('oculto');
    btnCargar.disabled = true;
}

function ocultarLoader() {
    loader.classList.add('oculto');
    btnCargar.disabled = false;
}

btnCargar.addEventListener('click', function () {
    listaJedis.innerHTML = '';
    errorMsg.textContent = '';
    mostrarLoader();

    fetch(API_URL)
        .then(function (response) {
            if (!response.ok) {
                throw new Error('Error al conectar con la API: ' + response.status);
            }
            return response.json();
        })
        .then(function (jedis) {
            jedis.forEach(function (jedi) {
                var card = document.createElement('div');
                card.className = 'jedi-card';

                var idSpan = document.createElement('span');
                idSpan.className = 'jedi-id';
                idSpan.textContent = '#' + jedi.jediId;

                var nombre = document.createTextNode(jedi.nombre);

                card.appendChild(idSpan);
                card.appendChild(nombre);
                listaJedis.appendChild(card);
            });
        })
        .catch(function (error) {
            errorMsg.textContent = error.message;
        })
        .finally(function () {
            ocultarLoader();
        });
});
