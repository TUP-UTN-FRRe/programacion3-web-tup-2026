var titulo1 = document.getElementById("titulo1");
        var img1 = document.getElementById("img1");

        //Codigo no intrusivo
        img1.addEventListener("click", function() {
            accion1();
        });

         img1.addEventListener("mousemove", function() {
            accion1();
        });

function accion1() {
    var dateTime = new Date();
            titulo1.innerHTML = "Programacion III - "+dateTime.getHours() + ":" + dateTime.getMinutes() + ":" + dateTime.getSeconds() + ":" + dateTime.getMilliseconds();
}

        