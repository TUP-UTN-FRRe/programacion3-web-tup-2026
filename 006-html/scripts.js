var titulo1 = document.getElementById("titulo1");
var miimagen = document.getElementById("miimagen");

        //Codigo no intrusivo
        miimagen.addEventListener("click", function() {
            accion1();
        });

         miimagen.addEventListener("mousemove", function() {
            accion1();
        });

function accion1() {
    var dateTime = new Date();
    titulo1.innerHTML = "Programacion III - "+dateTime.getHours() + ":" + dateTime.getMinutes() + ":" + dateTime.getSeconds() + ":" + dateTime.getMilliseconds();
}

        