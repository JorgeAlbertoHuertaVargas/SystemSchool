
function ListarCursos() {
    $("#loader").show();
    $.ajax({
        "url": "Courses/GetCursosLista",
        type: 'GET'
    }).done(function (resp) {
        $("#loader").hide();
        if (resp.length != 0) {
            var cont = 1;
            var template = '';
            resp.forEach(valor => {
                template += `
                         <tr guardarId="${valor.idCourse}" >
                         <td>${cont}</td>
                         <td>${valor.courseName}</td>
                         <td>${fecha(valor.courseDateCreated)}</td>
                         <td>
                          <button class='btn btn-info' onclick = 'EditarCorse(this)' style=' font-size:13px;'> <i class='fa fa-edit' style=' font-size:13px;'></button></i>&nbsp;
                         <button class='btn' onclick = 'EliminarCurso(this)' style=' font-size:13px; Background:#e4007c'> <i class='fa fa-trash'style=' font-size:13px;color:#FBF8EF'></button></i>
                         </td>
                         </tr>
                      `
                cont++;
            })
            $('#tablaCursos').html(template);
        } else {
            $('#tablaCursos').html('NO HAY REGISTRO');
        }
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });
}

function fecha(fechaSelec) {
    var f = new Date(fechaSelec);
    var options = { year: 'numeric', month: 'long', day: 'numeric' };
    var selectFecha = (f.toLocaleDateString("es-ES", options));
    return selectFecha;
}

function EditarCorse(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var Idcourse = $(tr).attr('guardarId');
    $.ajax({
        "url": "Courses/ShowCurso",
        type: "POST",
        data: {
            Idcourse: Idcourse
        },
    }).done(function (result) {
       
        if (result != null) {
            HidenShowButtonTitle();
            $("#IdCourse").val(result.idCourse);
            $("#CourseName").val(result.courseName);
            $("#CourseDateCreated").val(result.courseDateCreated);
        } else { Mensajeria(result); }
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });

}

function RegistrarCursos() {
    var IdCourse = $("#IdCourse").val();
    var IdCourse = 0;
    $.ajax({
        url: "Courses/RegistrarCursos",
        data: {
            IdCourse: IdCourse,
            CourseName: $("#CourseName").val(),
            CourseDateCreated: $("#CourseDateCreated").val()
        },
        type: "post"
    }).done(function (result) {
        Mensajeria(result);
    })
        .fail(function (XMLHttpRequest, status, error) {
            SaveExcepciones(XMLHttpRequest, status, error);
        });
}

function ActualizarCursos() {
    $.ajax({
        url: "Courses/UpdateCurso",
        data: {
            IdCourse: $("#IdCourse").val(),
            CourseName: $("#CourseName").val(),
            CourseDateCreated: $("#CourseDateCreated").val()
        },
        type: "post"
    }).done(function (result) {
        Mensajeria(result);
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });
}
function EliminarCurso(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var Idcourse = $(tr).attr('guardarId');
    $.ajax({
        url: "Courses/CursoDelete",
        data: {
            Idcourse: Idcourse
        },
        type: "post"
    }).done(function (result) {
        Mensajeria(result);
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });
}


function Mensajeria(result) {

    if (result == true) {
        $("#Chekname").show("slow").delay(2000).hide("slow");
        return;
    }

    if (result == false) {
        $("#NoAction").show("slow").delay(2000).hide("slow");
        return;
    }

    if (result == null) {

        $("#LLeneCmpVacio").show("slow").delay(2000).hide("slow");
        return;
    }

    if (result > 0) {
        $("#ButtCreat").show();
        $("#ButtUpdate").hide();
        $("#titlenew").show();
        $("#titleEdit").hide();
        $("#ButtLipiar").hide();
        LimpiarInput();
        ListarCursos();
        $("#ExitoAlert").show("slow").delay(2000).hide("slow");
        return;

    }
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

//FUNCIONES ADICIONALES

function HidenShowButtonTitle() {
    $("#ButtCreat").hide();
    $("#ButtUpdate").show();
    $("#titlenew").hide();
    $("#titleEdit").show();
    $("#ButtLipiar").show();
}
function ButtCancelar() {
    LimpiarInput();
    $("#titlenew").show();
    $("#titleEdit").hide();
    $("#ButtCreat").show();
    $("#ButtUpdate").hide();
    $("#ButtLipiar").hide();
}

function fechaCreate() {
    var f = new Date();
    var fecha = f.getFullYear() + "-" + (f.getMonth() + 1) + "-" + f.getDate();
    $("#CourseDateCreated").val(fecha);

}

function LimpiarInput() {
    $("#CourseName").val('');
    $("#CourseDateCreated").val('');
    fechaCreate();
}


var con = 0;
function Actibarbuscador() {
    if (con == 0) {
        $("#BuscadorFilter").show();
        con++;
    } else {
        $("#BuscadorFilter").hide();
        con = 0;
    }
}

function Buscar() {
    var tabla = document.getElementById('htmlTable');
    var busqueda = document.getElementById('BuscadorFilter').value.toLowerCase();
    var cellsOfRow = "";
    var found = false;
    var compareWith = "";
    for (var i = 1; i < tabla.rows.length; i++) {
        cellsOfRow = tabla.rows[i].getElementsByTagName('td');
        found = false;
        for (var j = 0; j < cellsOfRow.length && !found; j++) {
            compareWith = cellsOfRow[j].innerHTML.toLowerCase(); if (busqueda.length == 0 || (compareWith.indexOf(busqueda) > -1)) {
                found = true;
            }
        }
        if (found) {
            tabla.rows[i].style.display = '';
        } else {
            tabla.rows[i].style.display = 'none';
        }
    }
}

