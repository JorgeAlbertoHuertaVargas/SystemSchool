
$(".ButtnSearch").click(function () {
    console.log("Ingreso ...")
    var DNItext = $('#ConsultDNI').val();
    if (DNItext.length == 0) {
        return Swal.fire("Mensaje De Advertencia", "Ingrese numero DNI", "warning");
    }

    if (DNItext.length > 8 || DNItext.length < 8) {
        return Swal.fire("Mensaje De Advertencia", "Ingrese un DNI valido!!", "warning");
    }

    $.ajax({

        "url": "Consulta_DNI",
        type: 'POST',
        data: {
            DNItext: DNItext
        }
    }).done(function (result) {

        if (result[0] == 'T') {
            var cadenaCorregida = result.substring(2, result.length - 1);
            var authHeader = cadenaCorregida.replace(/,/g, " ");
            var split = authHeader.split(' ');
            $("#inputApellidoP").val(split[0]);
            $("#inputApellidoM").val(split[1]);
            $("#inputNombre").val(split[2]);
        }
        else {
            Swal.fire(
                'The Internet?',
                'That thing is ' + result + ' still around?',
                'question'
            )
        }

    }).fail(function (xhr, status, error) {

    });
});


function Verificar_JNE() {
    var DNItext = $('#textDeni').val();
    if (DNItext.length == 0) {
        return Swal.fire("Mensaje De Advertencia", "Ingrese numero DNI", "warning");
    }

    if (DNItext.length > 8 || DNItext.length < 8) {
        return Swal.fire("Mensaje De Advertencia", "Ingrese un DNI valido!!", "warning");
    }

    $.ajax({
        
        "url": "API/Consulta_JNE",

        type: 'POST',
        data: {
            DNItext: DNItext
        }
    }).done(function (result) {
        if (result[0] == 'T') {
            Swal.fire(
                'Ups?',
                ' ' + result + ', ',
                ''
            )
        }
        else {
            var cadenaCorregida = result.substring(9, result.length - 4);
            var authHeader = cadenaCorregida.replace(/,/g, " ");
            var split = authHeader.split(' ');
            $("#apellidopater").val(split[0]);
            $("#textApellm").val(split[1]);
            $("#textName").val(split[2]);


        }
    })
        .fail(function (xhr, status, error) {

        });
}
