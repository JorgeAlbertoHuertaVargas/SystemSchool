
function VerificarUsuario() {
    var Codigo = $("#Codigo").val();
    var Pass = $("#Pass").val();
    var IdRoles = $("#IdRoles").val();
    if (Codigo.length == 0 || Pass.length == 0 || IdRoles.length == 0) {
        $("#llenecamp").show();
        return;
    }
    $('.loader').show();
    $.ajax({
        url: "Login/Validation",
        type: 'POST',
        data: {
            Codigo: Codigo,
            Pass: Pass,
            IdRoles: IdRoles
        },
    }).done(function (result) {
        if (result != null) {
            $('#Codigo').val(result["userName"]);
            //aqui notificar usuario y contra
            //aqui notificar estado
            var Role = (result['role']);
            Crearsesion(result, Role);
      }
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });
}

function Crearsesion(result, Role) {
    $.ajax({
        url: "Login/SetCrearSesion",
        type: 'POST',
        data: {
            UserName: (result['userName']),
            Codigo: (result['codigo']),
            RoleName: (Role['roleName'])
        }
    }).done(function (resp) {
        $('.loader').hide();
        if (resp == true) {
           location.reload();
        }
    })
           
}

function SaveExcepciones(XMLHttpRequest, status, error) {
    if (XMLHttpRequest.status == 401) {
        $("#ErrorAlert").show("slow").delay(2000).hide("slow");
        $('#Mensenger').html('petición HTTP Fallido:' + xhr.status + ' Not authorized');
        $("#loader").hide();
        return;
    }
    if (XMLHttpRequest.status == 404) {
        $("#ErrorAlert").show("slow").delay(2000).hide("slow");
        $('#Mensenger').html('Código de estado:' + XMLHttpRequest.status + '  the route does not exist!');
        $("#loader").hide();
        return;
    }

    if (XMLHttpRequest.status == 500) {
        $("#ErrorAlert").show("slow").delay(2000).hide("slow");
        $('#Mensenger').html('Código de estado:' + XMLHttpRequest.status + ' Error Interno del Servidor');
        $("#loader").hide();
        console.log(XMLHttpRequest);
        return;
    }
    Swal.fire(
        '' + XMLHttpRequest.statusText + '',
        'That thing is ' + XMLHttpRequest.responseText + ' still around?',
        'error'
    )
}